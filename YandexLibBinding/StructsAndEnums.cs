using System;
using System.Drawing;
using System.Runtime.InteropServices;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace YandexLibBinding
{
	using YMKMapCoordinate = MonoTouch.CoreLocation.CLLocationCoordinate2D;
	using YMKMapDegrees = System.Double;
	using YMKMapAccuracy = System.Double;
	using YMKMapSpeed = System.Double;
	using YMKMapDirection = System.Double;
	using YMKMapDistance = System.Double;
	
	public enum YMKTrafficInformerColor {
		YMKTrafficInformerColorNo, 
		YMKTrafficInformerColorRed, 
		YMKTrafficInformerColorYellow, 
		YMKTrafficInformerColorGreen
	};

	public enum YMKPinAnnotationColor {
		YMKPinAnnotationColorBlue = 0,
		YMKPinAnnotationColorGreen,
		YMKPinAnnotationColorBlueCommercial
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct YMKCoordinateComponents {
		public short degrees;
		public ushort minutes;
		public float seconds;
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct YMKMapPoint {
		public long x;
		public long y;
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct YMKMapRegionSize {
		public YMKMapDegrees latitudeDelta;    /**< the vertical distance of the region */
		public YMKMapDegrees longitudeDelta;   /**< the horizontal distance of the region */
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct YMKMapRegion {
		public YMKMapCoordinate center;    /**< the coordinate of the region center */
		public YMKMapRegionSize span;      /**< the region size */
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct YMKMapRect {
		public YMKMapCoordinate topLeft;       /**< the coordinate of the top left corner of the rectangle  */
		public YMKMapCoordinate bottomRight;   /**< the coordinate of the bottom right corner of the rectangle */
	};
	
	[StructLayout(LayoutKind.Sequential)]
	public struct YMKMapViewPort {
		public YMKMapRect mapRect;     /**< current map rectangular area covered by view port */
		public uint zoomLevel;         /**< current map zoom level */        
	};



	/*
	[BaseType (typeof (NSObject))]
	interface YMKCoordinateComponents {
		[Export ("degrees")] short Degrees { get; set; }
		[Export ("minutes")] ushort minutes { get; set; }
		[Export ("seconds")] float Seconds { get; set; }
	}
	*/

	/*
	[Static, Export ("YMKMapCoordinateIsZero")]
	bool YMKMapCoordinateIsZero (YMKMapCoordinate ll);
	*/

	/*
	[Field ("YMKMapCoordinateZero", "__Internal")]
	YMKMapCoordinate const YMKMapCoordinateZero { get; }
	*/
	


	//static extern bool YMKMapCoordinateIsZero(YMKMapCoordinate ll);

}

