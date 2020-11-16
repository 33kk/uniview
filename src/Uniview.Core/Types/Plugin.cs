using System.Collections.Generic;
using System.Threading.Tasks;

namespace Uniview.Core.Types {
	public interface IPlugin {
		public string Id { get; }
		public string Name { get; }
		public string Description { get; }
		public List<Route> Routes { get; }
		public Task Load();
		public Task Unload();
	}
}
