using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Uniview.Core.Types;

namespace Uniview.Core {
	public class PluginManager : Router {
		public List<IPlugin> Plugins { get; set; }
		public async Task Load() {
			var files = Directory.GetFiles(Path.Join(AppContext.BaseDirectory, "plugins"));
			foreach (var file in files) {
				Console.WriteLine(file);
				var plug = (IPlugin)Activator.CreateInstance(Assembly.LoadFile(file).GetType("Uniview.Plugin.Reddit.Plugin"));
				Plugins.Add(plug);
				await plug.Load();
				Console.WriteLine(plug.Id);
			}
		}
	}
}
