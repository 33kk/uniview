using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using Uniview.Core.Types;
using Uniview.Core.Types.Output;

namespace Uniview.Core {
	public class ResponseWithMime : Response {
		public string Mime { get; set; }
	}

	public class UniviewResponse : ResponseWithMime {
		public UniviewPage Data { get; set; }
	}

	public class StringResponse : ResponseWithMime {
		public string Data { get; set; }
	}

	public class StreamResponse : ResponseWithMime {
		public Stream Data { get; set; }
	}

	public interface IPluginManager : IRouter {
		public Task Load();
		public Task Unload();
		public List<IPlugin> Plugins { get; }
	}

	public class PluginManager : Router, IPluginManager {
		private string pluginsPath;
		
		public PluginManager() {
			pluginsPath = Path.Join(AppContext.BaseDirectory, "plugins");
		}

		public PluginManager(string pluginsPath) {
			this.pluginsPath = pluginsPath;
		}

		public List<IPlugin> Plugins { get; set; } = new List<IPlugin>();

		public async Task Load() {
			var dirs = Directory.GetDirectories(pluginsPath);
			foreach (var dir in dirs) {
				var assembly = Assembly.LoadFrom(Path.Join(dir, Path.GetFileName(dir) + ".dll"));
				var type = assembly.GetTypes().Single(t => t.Name == "Plugin");
				var plugin = (IPlugin)Activator.CreateInstance(type);

				Plugins.Add(plugin);
				Route.Subroutes.Add(new PathRoute() {
					Path = plugin.Id,
					Subroutes = plugin.Routes
				});

				await plugin.Load();
			}
		}

		public async Task Unload() {
			foreach (var plugin in Plugins) {
				await plugin.Unload();
				Plugins.Remove(plugin);
				Route.Subroutes.RemoveAll(r => {
					if (r is PathRoute) {
						var pr = (PathRoute)r;
						if (pr.Path == plugin.Id) {
							return true;
						}
					}
					return false;
				});
			}
		}
	}
}
