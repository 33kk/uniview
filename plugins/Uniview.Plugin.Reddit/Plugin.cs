using System;
using System.Threading.Tasks;
using Uniview.Core;
using Uniview.Core.Types;

namespace Uniview.Plugin.Reddit {
	public class Plugin : IPlugin {
		public string Id { get => "reddit"; set => throw new NotImplementedException(); }
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Route Route { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Task Load() {
			throw new NotImplementedException();
		}

		public Task Unload() {
			throw new NotImplementedException();
		}
	}
}
