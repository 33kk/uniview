using System.Collections.Generic;
using System.Threading.Tasks;

namespace Uniview.Core.Types {
	public interface IPlugin {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Route> Routes { get; set; }
		public Task Load();
		public Task Unload();
	}
}
