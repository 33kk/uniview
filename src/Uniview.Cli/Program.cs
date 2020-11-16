using System;
using System.Threading.Tasks;
using Uniview.Core;
using Newtonsoft.Json;

namespace Uniview.Cli {
	class Program {
		static async Task Main(string[] args) {
			var pm = new PluginManager();
			await pm.Load();
			var routed = pm.FindRoute("/reddit/r");
			var route = routed.route;
			if (route is PropRoute) {
				var propRoute = (PropRoute)route;
				Console.WriteLine(propRoute.Prop);
			}
			else if (route is PathRoute) {
				var pathRoute = (PathRoute)route;
				Console.WriteLine(pathRoute.Path);
				var r = await pathRoute.Handler();
				Console.WriteLine(JsonConvert.SerializeObject(r));
			}
		}
	}
}
