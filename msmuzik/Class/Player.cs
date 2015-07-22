using System;
using Android.Media;
using Android.Content;
using System.IO;
using System.Collections.Generic;

namespace msmuzik
{
	public class Player
	{
		MediaPlayer player;
		Context context;
		Parser parser;
		StreamReader reader;
		string json;
		Track[] myTracks;
		string currentURL;
		int currTrack=0;

		public Player (Context context)
		{
			this.context = context;
			reader = new StreamReader (context.Assets.Open ("playlist.json"));
			json = reader.ReadToEnd();
			parser = new Parser (json);
			myTracks = parser.getTracks ();
			try{
				currentURL = myTracks[currTrack].url;
			}catch(Exception e) {
				Console.WriteLine (e.Message);
			}
				this.player = new MediaPlayer ();
			this.player.SetAudioStreamType(Android.Media.Stream.Music);
			this.player.Reset();
			this.player.SetDataSource (currentURL);
			this.player.Prepare ();

		}

		public string getTrackTitle(){
			return myTracks [currTrack].title;
		}

		public void loadTrack()
		{
			try{
				currentURL = myTracks[currTrack].url;
			}catch(Exception e) {
				Console.WriteLine (e.Message);
			}
			this.player.Reset();
			this.player.SetDataSource (currentURL);
			this.player.Prepare ();
		}

		public void nextTrack()
		{
			currTrack++;
			loadTrack ();
			this.player.Start ();
		}

		public void prevTrack()
		{
			currTrack--;
			loadTrack ();
			this.player.Start ();
		}

		public void stopTrack()
		{
			this.player.Stop();
		}

		public void playTrack()
		{

			try{
			if (isPlaying ()) {
					this.player.Pause ();
			} else {
				this.player.Start ();
			}
			}catch(Exception ex){
				Console.WriteLine (ex.Message);
			}
		}

		public void pauseTrack()
		{
			this.player.Pause ();
		}

		public Boolean isPlaying()
		{			
			return this.player.IsPlaying;
		}
	}
}

