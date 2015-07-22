using System;
using Android.Views;
namespace msmuzik
{
	public class TouchController : View.IOnTouchListener
	{
		public TouchController ()
		{
			
		}

		#region IOnTouchListener implementation

		public bool OnTouch (View v, MotionEvent e)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IJavaObject implementation

		public IntPtr Handle {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

