using System;
using Newtonsoft.Json;
using System.IO;
using Android.Content.Res;
using Android.App;
using Android.Content;
using System.Collections.Generic;

namespace msmuzik
{
	public class Parser
	{
		private string json;
		private Rootobject root;

		public Parser (string json)
		{
			this.json = json;
//			Console.WriteLine (JsonConvert.SerializeObject(deserializedProduct));
		}

		public Track[] getTracks(){
			try{				
			root = JsonConvert.DeserializeObject<Rootobject>(json);

				return root.playlist.album [0].tracks.track;
			}catch(Exception e){
				Console.WriteLine (e.Message);
			}
			return null;
		}
	}
}

