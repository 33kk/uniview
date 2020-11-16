using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Uniview.Core;
using Uniview.Core.Types;
using Uniview.Core.Types.Output;

using Reddit;

namespace Uniview.Plugin.Reddit {
	public class Plugin : IPlugin {
		RedditClient client;
		public Plugin() {
			Routes = new List<Route>() {
				new PathRoute() {
					Path = "r",
					Handler = async () => {
						var posts = client.Subreddit("AskReddit").Posts.New;
						var uw = new PostsPage() {
							Version = 0.1f,
							Title = "r/all",
							Data = new Pagination<List<Post>>() {
								Items = (List<Post>)posts.Select((post, index) => {
									return new Post() {
										Id = post.Id,
										Title = post.Title,
										Nsfw = post.NSFW,
										Likes = post.UpVotes,
										Authors = new List<User>() {
											new User() {
												Username = post.Author,
											}
										}
									};
								})
							}
						};
						return new UniviewResponse() {
							Mime = "application/uniview+json",
							Data = uw
						};
					}
				}
			};
		}
		public string Id { get => "reddit"; }
		public string Name { get => throw new NotImplementedException(); }
		public string Description { get => throw new NotImplementedException(); }
		public List<Route> Routes { get; private set; }

		public async Task Load() {
			client = new RedditClient(userAgent: "Uniview/1.0");
			System.Console.WriteLine("reddit load");
		}

		public async Task Unload() {
			client = null;
			System.Console.WriteLine("reddit unload");
		}
	}
}
