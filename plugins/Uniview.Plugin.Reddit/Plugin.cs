using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Uniview.Core;
using Uniview.Core.Types;

namespace Uniview.Plugin.Reddit {
	public class Plugin : IPlugin {
		public string Id { get => "reddit"; set => throw new NotImplementedException(); }
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<Route> Routes { get; set; } = new List<Route>() { new PropRoute() {
			Prop = "r",
			Trailing = true
		}};

		public async Task Load() {
			System.Console.WriteLine("reddit load");
		}

		public Task Unload() {
			throw new NotImplementedException();
		}
	}
}
