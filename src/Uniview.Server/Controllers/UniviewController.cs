using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Uniview.Core;

namespace Uniview.Server.Controllers {
	[ApiController]
	[Route("/")]
	public class UniviewController : ControllerBase {
		private readonly ILogger<UniviewController> _logger;
		private readonly IPluginManager _pm;

		public UniviewController(ILogger<UniviewController> logger, IPluginManager pm) {
			_pm = pm;
			_logger = logger;
		}

		[HttpGet]
		[HttpPost]
		[Route("{**path}")]
		public async Task<object> Bruh(string path) {
			var r = _pm.FindRoute(path);
			var route = r.route;
			var resp = await route.Handler();
			if (resp is UniviewResponse) {
				return ((UniviewResponse)resp).Data;
			}
			return null;
		}
	}
}
