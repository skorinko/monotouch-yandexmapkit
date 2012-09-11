// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace YandexMonoTest
{
	[Register ("YandexMonoTestViewController")]
	partial class YandexMonoTestViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton plusButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton minusButton { get; set; }

		[Action ("plusButtonClick:")]
		partial void plusButtonClick (MonoTouch.Foundation.NSObject sender);

		[Action ("minusButtonClick:")]
		partial void minusButtonClick (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (plusButton != null) {
				plusButton.Dispose ();
				plusButton = null;
			}

			if (minusButton != null) {
				minusButton.Dispose ();
				minusButton = null;
			}
		}
	}
}
