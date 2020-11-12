using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonSubTypes;

namespace Uniview.Core.Types.Output {
	[JsonConverter(typeof(JsonSubtypes), "Type")]
	public class UniviewPage {
		[JsonProperty("version")]
		public float Version { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("Description")]
		public string Description { get; set; }
		[JsonProperty("type")]
		public string Type { get; }
		[JsonProperty("users")]
		public Pagination<User[]> Users { get; set; }
		[JsonProperty("urls")]
		public Pagination<User[]> Urls { get; set; }
		[JsonProperty("icon")]
		public Attachment Icon { get; set; }
		[JsonProperty("banner")]
		public Attachment Banner { get; set; }
	}
	public class PostsPage : UniviewPage {
		[JsonProperty("type")]
		new public string Type { get; } = "posts";
		[JsonProperty("data")]
		public Pagination<Post[]> Data { get; set; }
	}
	public class PostPage : UniviewPage {
		[JsonProperty("type")]
		new public string Type { get; } = "post";
		[JsonProperty("data")]
		public Post Data { get; set; }
	}
	public class UsersPage : UniviewPage {
		[JsonProperty("type")]
		new public string Type { get; } = "users";
		[JsonProperty("data")]
		public Pagination<User[]> Data { get; set; }
	}
	public class UserPage : UniviewPage {
		[JsonProperty("type")]
		new public string Type { get; } = "user";
		[JsonProperty("data")]
		public User Data { get; set; }
	}
	public class CategoriesPage : UniviewPage {
		[JsonProperty("type")]
		new public string Type { get; } = "categories";
		[JsonProperty("data")]
		public Pagination<Group<Pagination<Post[]>>[]> Data { get; set; }
	}
	public class CategoryPage : UniviewPage {
		[JsonProperty("type")]
		new public string Type { get; } = "category";
		[JsonProperty("data")]
		public Group<Pagination<Post[]>> Data { get; set; }
	}
	public class Group<T> {
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("items")]
		public T Items { get; set; }
	}
	public class Post {
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("created")]
		public DateTime Created { get; set; }
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("updated")]
		public DateTime Updated { get; set; }
		[JsonProperty("authors")]
		public User[] Authors { get; set; }
		[JsonProperty("tags")]
		public Tag[] Tags { get; set; }
		[JsonProperty("likes")]
		public int Likes { get; set; }
		[JsonProperty("dislikes")]
		public int Dislikes { get; set; }
		[JsonProperty("views")]
		public int Views { get; set; }
		[JsonProperty("nsfw")]
		public bool Nsfw { get; set; }
		[JsonProperty("content_warning")]
		public string ContentWarning { get; set; }
		[JsonProperty("partial")]
		public bool Partial { get; set; }
		[JsonProperty("license")]
		public string License { get; set; }
		[JsonProperty("attachments")]
		public Attachment[] Attachments { get; set; }
		[JsonProperty("responses")]
		public Post[] Responses { get; set; }
	}
	public class User {
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("username")]
		public string Username { get; set; }
		[JsonProperty("fullname")]
		public string Fullname { get; set; }
		[JsonProperty("avatar")]
		public Attachment Avatar { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("created")]
		public DateTime Created { get; set; }
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("updated")]
		public DateTime Updated { get; set; }
		[JsonProperty("following")]
		public User Following { get; set; }
		[JsonProperty("followers")]
		public User Followers { get; set; }
		[JsonProperty("tags")]
		public Tag[] Tags { get; set; }
		[JsonProperty("likes")]
		public int Likes { get; set; }
		[JsonProperty("dislikes")]
		public int Dislikes { get; set; }
		[JsonProperty("views")]
		public int Views { get; set; }
		[JsonProperty("nsfw")]
		public bool Nsfw { get; set; }
		[JsonProperty("content_warning")]
		public string ContentWarning { get; set; }
		[JsonProperty("partial")]
		public bool Partial { get; set; }
		[JsonProperty("attachments")]
		public Attachment[] Attachments { get; set; }
	}
	// TODO: More properties for attachments (variants, etc...)
	[JsonConverter(typeof(JsonSubtypes))]
	[JsonSubtypes.KnownSubTypeWithProperty(typeof(UrlAttachment), "Url")]
	[JsonSubtypes.KnownSubTypeWithProperty(typeof(ContentAttachment), "Content")]
	public class Attachment {
		[JsonProperty("mime")]
		public string Mime { get; set; }
		[JsonProperty("live")]
		public bool Live { get; set; }
		[JsonProperty("size")]
		public int Size { get; set; }
		[JsonProperty("width")]
		public int Width { get; set; }
		[JsonProperty("height")]
		public int Height { get; set; }
		[JsonProperty("bitrate")]
		public int Bitrate { get; set; }
		[JsonProperty("duration")]
		public int Duration { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("nsfw")]
		public bool Nsfw { get; set; }
		[JsonProperty("content_warning")]
		public string ContentWarning { get; set; }
	}
	public class UrlAttachment : Attachment {
		[JsonProperty("url")]
		public string Url { get; set; }
	}
	public class ContentAttachment : Attachment {
		[JsonProperty("content")]
		public string Content { get; set; }
	}
	public class Pagination<T> {
		[JsonProperty("previous")]
		public string Previous { get; set; }
		[JsonProperty("next")]
		public string Next { get; set; }
		[JsonProperty("items")]
		public T Items { get; set; }
	}
	public class Tag {
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
