using System;
using System.Threading.Tasks;
using Uniview.Core;

namespace Uniview.Cli {
	class Program {
		static async Task Main(string[] args) {
			var pm = new PluginManager();
			await pm.Load();
			var route = pm.FindRoute("/reddit/r");
			if (route is PropRoute) {
				Console.WriteLine(((PropRoute)route).Prop);
			}
			else if (route is PathRoute) {
				Console.WriteLine(((PathRoute)route).Path);
			}
		}
	}
}
