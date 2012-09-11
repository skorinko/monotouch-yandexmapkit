using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using YandexLibBinding;

using YMKMapCoordinate = MonoTouch.CoreLocation.CLLocationCoordinate2D;

namespace YandexMonoTest
{
	public partial class YandexMonoTestViewController : UIViewController
	{
		YMKMapView mapView { get; set; }

		public YandexMonoTestViewController () : base ("YandexMonoTestViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			mapView = new YMKMapView(new RectangleF(0, 50, 480, 350));
			this.View.AddSubview(mapView);
			mapView.showsUserLocation = true;
			mapView.showTraffic = false;

			YMKMapCoordinate moscowCenter = new YMKMapCoordinate(55.757172, 37.55347);
			mapView.setCenterCoordinate(moscowCenter, 13, false);

		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();

			ReleaseDesignerOutlets ();

			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void plusButtonClick (MonoTouch.Foundation.NSObject sender)
		{
			//NSError error;
			mapView.zoomIn();
			Console.WriteLine("xxx");
			Console.WriteLine(mapView.zoomLevel);
		}

		partial void minusButtonClick (MonoTouch.Foundation.NSObject sender)
		{
			mapView.zoomOut();
			Console.WriteLine("yyy");
			Console.WriteLine(mapView.zoomLevel);
		}

	}
}

