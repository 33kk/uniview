using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using Uniview.Core.Types;

namespace Uniview.Core {
	public class PluginManager : Router {
		public List<IPlugin> Plugins { get; set; } = new List<IPlugin>();
		public async Task Load() {
			var files = Directory.GetFiles(Path.Join(AppContext.BaseDirectory, "plugins"));
			foreach (var file in files) {
				var assEmbly = Assembly.LoadFile(file);
				var type = assEmbly.GetTypes().Single(t => t.Name == "Plugin");
				var plug = (IPlugin)Activator.CreateInstance(type);
				Plugins.Add(plug);
				Route.Subroutes.Add(new PathRoute() {
					Path = plug.Id,
					Subroutes = plug.Routes
				});
				await plug.Load();
			}
		}
	}
}
