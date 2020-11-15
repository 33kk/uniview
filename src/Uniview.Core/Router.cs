using System;
using System.Collections.Generic;

namespace Uniview.Core {
	public class RoutingException : Exception {
		public RoutingException() {}

		public RoutingException(string message) : base(message) {}

		public RoutingException(string message, Exception inner) : base(message, inner) {}
	}

	public class Route {
		public bool Trailing { get; set; }
		public string[] Query { get; set; }
		public List<Route> Subroutes { get; set; }
		public Func<Response> Handler { get; set; }
	}

	public class Response {}

	public class PropRoute : Route {
		public string Prop { get; set; }
	}

	public class PathRoute : Route {
		public string Path { get; set; }
	}

	public class Router {
		public Route Route { get; set; } = new PathRoute() {
			Path = "/",
			Subroutes = new List<Route>()
		};

		public Route FindRoute(string path) {
			if (this.Route == null)
				throw new RoutingException("No routes");

			var currRoute = this.Route;
			var pathArray = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

			var trailing = new List<string>();
			var parameters = new Dictionary<string, string>();

			foreach (var pathPart in pathArray) {
				if (currRoute.Subroutes == null || currRoute.Subroutes.Count == 0) {
					if (currRoute.Trailing) {
						trailing.Add(pathPart);
						continue;
					} else {
						throw new RoutingException("Subroute not found");
					}
				}

				bool found = false;
				foreach (var route in currRoute.Subroutes) {
					if (route is PathRoute) {
						var pathRoute = (PathRoute)route;
						if (pathRoute.Path == pathPart) {
							currRoute = route;
							found = true;
							continue;
						}
					} else if (route is PropRoute) {
						var propRoute = (PropRoute)route;
						parameters[propRoute.Prop] = pathPart;
						currRoute = route;
						found = true;
						continue;
					}
					throw new RoutingException("Unknown route type");
				}

				if (!found) {
					throw new RoutingException("Route not found");
				}
			}

			return currRoute;
		}
	}
}
