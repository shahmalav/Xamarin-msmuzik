using System;
using Android.Views;
using Android.Content;
using Android.Widget;

namespace msmuzik
{
	public class GestureDetection : GestureDetector.IOnGestureListener
	{
	//	float x1,x2;
	//	float y1, y2;
		Context context;

		public bool OnDown(MotionEvent e)
		{
			return false;
		}
		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			//Toast.makeText(context, String.Format("Fling velocity: {0} x {1}", velocityX, velocityY), ToastLength.Short).show();
			Toast.MakeText(context," You touched! ",ToastLength.Long).Show();
			return true;

		}
		public void OnLongPress(MotionEvent e) 
		{
			
		}

		public bool OnTouchEvent(MotionEvent e)
		{
			return false;
		}

		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}
		public void OnShowPress(MotionEvent e) 
		{
			
		}
		public bool OnSingleTapUp(MotionEvent e)
		{
			return false;
		}
	
		public GestureDetection(Context applicationContext)
		{
			this.context = applicationContext;
		}

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		public IntPtr Handle {
			get {
				throw new NotImplementedException ();
			}
		}
	}
}

