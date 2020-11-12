using System;
using System.Threading.Tasks;
using Uniview.Core;

namespace Uniview.Cli {
	class Program {
		static async Task Main(string[] args) {
			var pm = new PluginManager();
			await pm.Load();
		}
	}
}
