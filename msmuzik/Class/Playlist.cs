using System;
using System.Collections.Generic;

namespace msmuzik
{

	public class Rootobject
	{
		public Playlist playlist { get; set; }
	}

	public class Playlist
	{
		public Album[] album { get; set; }
	}

	public class Album
	{
		public string Aname { get; set; }
		public string Aartist { get; set; }
		public Tracks tracks { get; set; }
	}

	public class Tracks
	{
		public Track[] track { get; set; }
	}

	public class Track
	{
		public string id { get; set; }
		public string title { get; set; }
		public string url { get; set; }
	}
}

