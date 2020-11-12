using System;
using System.Collections.Generic;

namespace Uniview.Core {
	public class Route {
		public bool Trailing { get; set; }
		public string[] Query { get; set; }
		public Route[] Subroutes { get; set; }
	}

	public class PropRoute : Route {
		public string Prop { get; set; }
	}

	public class PathRoute : Route {
		public string Path { get; set; }
	}

	public class Router {
		public Route Route { get; set; }
		public Route FindRoute(string path) {
			var currRoute = this.Route;
			var pathArray = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

			var trailing = new List<string>();
			var parameters = new Dictionary<string, string>();

			foreach (var pathPart in pathArray) {
				if (currRoute.Subroutes == null || currRoute.Subroutes.Length == 0) {
					if (currRoute.Trailing) {
						trailing.Add(pathPart);
						continue;
					} else {
						throw new Exception("peepoGladException: no subroutes");
					}
				}

				bool found = false;
				foreach (var route in currRoute.Subroutes) {
					if (route is PathRoute) {
						var r = (PathRoute)route;
						if (r.Path == pathPart) {
							currRoute = route;
							found = true;
							continue;
						}
					} else if (route is PropRoute) {
						var r = (PropRoute)route;
						parameters[r.Prop] = pathPart;
						currRoute = route;
						found = true;
						continue;
					}
					throw new Exception("peepoGladException: peepoGlad");
				}

				if (!found) {
					throw new Exception("peepoGladException: route not found");
				}
			}

			return currRoute;
		}
	}
}
