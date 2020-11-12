using System.Threading.Tasks;

namespace Uniview.Core.Types {
	public interface IPlugin {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Route Route { get; set; }
		public Task Load();
		public Task Unload();
	}
}
