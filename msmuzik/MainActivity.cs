using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace msmuzik
{
	[Activity (Label = "msmuzik", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, GestureDetector.IOnGestureListener
	{
		private GestureDetector _gestureDetector;
		Player player;
		RelativeLayout relLayout;
		TextView txtTitle, txtDuration;

	//	Parser parser;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			player = new Player(this);
			//parser = new Parser(this);
			_gestureDetector = new GestureDetector(this);


			txtTitle = FindViewById<TextView> (Resource.Id.txtTitle);
			txtDuration = FindViewById<TextView> (Resource.Id.txtDuration);
			relLayout = FindViewById<RelativeLayout> (Resource.Id.MainLayout);

		/*	relLayout.Click += delegate {
				Parser parser = new Parser();
				player.playTrack(parser.userurl);
			//	Toast.MakeText(ApplicationContext," You touched! ",ToastLength.Long).Show();
			};*/
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			_gestureDetector.OnTouchEvent(e);
			return false;
		}

		public bool OnDown(MotionEvent e)
		{
			return false;
		}

		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
				
			switch (getSlope(e1.GetX(), e1.GetY(), e2.GetX(), e2.GetY())) {
			case 1:
				Toast.MakeText(ApplicationContext,"Swipe Up",ToastLength.Long).Show();
				return true;
			case 2:
				Toast.MakeText (ApplicationContext, "Swipe left", ToastLength.Long).Show ();
				player.nextTrack ();
				txtTitle.Text = player.getTrackTitle ();
				return true;
			case 3:
				Toast.MakeText(ApplicationContext,"Swipe Down",ToastLength.Long).Show();
				return true;
			case 4:
				Toast.MakeText (ApplicationContext, "Swipe Right", ToastLength.Long).Show ();
				txtTitle.Text = player.getTrackTitle ();
				player.prevTrack ();
				return true;
			case 0:
				return true;
			}
			return false;

		}

		public void OnLongPress(MotionEvent e) {
			Toast.MakeText(ApplicationContext,"On Long Press",ToastLength.Long).Show();
		}

		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}

		public void OnShowPress(MotionEvent e) {}

		public bool OnSingleTapUp(MotionEvent e)
		{
			player.playTrack();
			txtTitle.Text = player.getTrackTitle ();
			Toast.MakeText(ApplicationContext,"On Single Tap Up",ToastLength.Long).Show();
			return false;
		}

		private int getSlope(float x1, float y1, float x2, float y2) {
			Double angle = getDegree(Math.Atan2(y1 - y2, x2 - x1));
			if (angle > 45 && angle <= 135)
				return 1;
			if (angle >= 135 && angle < 180 || angle < -135 && angle > -180)
				return 2;
			if (angle < -45 && angle>= -135)
				return 3;
			if (angle > -45 && angle <= 45)
				return 4;
			return 0;
		}

		private double getDegree(double radians)
		{
			return radians * 180 / Math.PI;
		}

	}


}


