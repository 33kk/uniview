using System;
using System.Collections.Generic;

namespace Uniview.Plugin.Reddit {
	public class Thing {
		public string Kind { get; set; }
	}

	public class Post : Thing {
		public PostData Data { get; set; }
	}

	public class PostData {

	}
}
