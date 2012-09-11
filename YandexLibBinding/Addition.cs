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

	public struct YMK_CAPI {
		[DllImport ("__Internal")]
		static extern string NSStringFromMapDegrees(YMKMapDegrees degrees);

		[DllImport ("__Internal")]
		static extern YMKMapDegrees YMKMapDegreesFromString(string str);

		[DllImport ("__Internal")]
		static extern YMKMapCoordinate YMKMapCoordinateMake(YMKMapDegrees latitude, YMKMapDegrees longitude);

		[DllImport ("__Internal")]
		static extern bool YMKMapCoordinateEqualToMapCoordinate(YMKMapCoordinate ll1, YMKMapCoordinate ll2);

		[DllImport ("__Internal")]
		static extern bool YMKMapCoordinateIsZero(YMKMapCoordinate ll);

		[DllImport ("__Internal")]
		static extern bool YMKMapCoordinateIsValid(YMKMapCoordinate ll);

		[DllImport ("__Internal")]
		static extern NSDictionary NSDictionaryFromMapCoordinate(YMKMapCoordinate ll);

		[DllImport ("__Internal")]
		static extern YMKMapCoordinate YMKMapCoordinateFromDictionary(NSDictionary dict);

		[DllImport ("__Internal")]
		static extern string NSStringFromMapCoordinate(YMKMapCoordinate ll);

		[DllImport ("__Internal")]
		static extern YMKMapCoordinate YMKMapCoordinateFromString(string st);

		[DllImport ("__Internal")]
		static extern string NSHumanReadableStringFromMapCoordinate(YMKMapCoordinate ll);

		[DllImport ("__Internal")]
		static extern YMKCoordinateComponents YMKCoordinateComponentsFromMapDegrees(YMKMapDegrees degrees);

		[DllImport ("__Internal")]
		static extern string NSStringFromCoordinateComponents(YMKCoordinateComponents components);

		/*
		extern YMKMapRegionSize YMKMapRegionSizeMake(YMKMapDegrees latitudeDelta, YMKMapDegrees longitudeDelta);
		extern BOOL YMKMapRegionSizeEqualToMapRegionSize(YMKMapRegionSize s1, YMKMapRegionSize s2); 
		extern BOOL YMKMapRegionSizeIsZero(YMKMapRegionSize size);
		extern BOOL YMKMapRegionSizeIsValid(YMKMapRegionSize size);
		extern NSDictionary * NSDictionaryFromMapRegionSize(YMKMapRegionSize size);
		extern YMKMapRegionSize YMKMapRegionSizeFromDictionary(NSDictionary * dict);
		extern YMKMapRegion YMKMapRegionMake(YMKMapCoordinate center, YMKMapRegionSize span);
		extern BOOL YMKMapRegionEqualToMapRegion(YMKMapRegion r1, YMKMapRegion r2); 
		extern BOOL YMKMapRegionIsZero(YMKMapRegion region);
		extern BOOL YMKMapRegionIsValid(YMKMapRegion region);
		extern BOOL YMKMapRegionContainsMapCoordinate(YMKMapRegion region, YMKMapCoordinate ll);
		extern BOOL YMKMapRegionContainsMapRegion(YMKMapRegion r1, YMKMapRegion r2);
		extern YMKMapCoordinate YMKMapRegionGetTopLeftCoordinate(YMKMapRegion region);
		extern YMKMapCoordinate YMKMapRegionGetBottomRightCoordinate(YMKMapRegion region);
		extern NSDictionary * NSDictionaryFromMapRegion(YMKMapRegion region);
		extern YMKMapRegion YMKMapRegionFromDictionary(NSDictionary * dict);
		extern YMKMapRect YMKMapRectFromMapRegion(YMKMapRegion region);
		extern YMKMapRect YMKMapRectMake(YMKMapCoordinate topLeft, YMKMapCoordinate bottomRight);
		extern BOOL YMKMapRectEqualToMapRect(YMKMapRect r1, YMKMapRect r2);
		extern BOOL YMKMapRectIsZero(YMKMapRect rect);
		extern BOOL YMKMapRectIsValid(YMKMapRect rect);
		extern BOOL YMKMapRectContainsMapCoordinate(YMKMapRect rect, YMKMapCoordinate ll);
		extern BOOL YMKMapRectContainsMapRect(YMKMapRect r1, YMKMapRect r2);
		extern BOOL YMKMapRectIntersectsMapRect(YMKMapRect r1, YMKMapRect r2);
		extern NSDictionary * NSDictionaryFromMapRect(YMKMapRect rect);
		extern YMKMapRect YMKMapRectFromDictionary(NSDictionary * dict);
		extern NSString * NSStringFromMapRect(YMKMapRect rect);
		extern YMKMapRect YMKMapRectFromString(NSString *string);
		extern YMKMapRegion YMKMapRegionFromMapRect(YMKMapRect rect);
		extern YMKMapRect YMKMapRectMakeWithCenterAndMeters(YMKMapCoordinate center, long long int meters);
		extern YMKMapCoordinate YMKMapRectGetCenterCoordinate(YMKMapRect rect);
		extern YMKMapRect YMKMapRectNormalize(const YMKMapRect rect);
		extern YMKMapViewPort YMKMapViewPortMake(YMKMapRect rect, NSUInteger zoomLevel);
		extern BOOL YMKMapViewPortContainsViewPort(YMKMapViewPort viewPort, YMKMapViewPort subViewPort); 
		extern BOOL YMKMapViewPortEqualToViewPort(YMKMapViewPort a, YMKMapViewPort b);
		extern BOOL YMKMapViewPortIsZero(YMKMapViewPort rect);
		extern BOOL YMKMapViewPortIsValid(YMKMapViewPort viewPort);
		extern NSString * NSStringFromMapViewPort(YMKMapViewPort viewPort);
		extern YMKMapViewPort YMKMapViewPortFromString(NSString *string);
		extern NSDictionary * NSDictionaryFromMapViewPort(YMKMapViewPort viewPort);
		extern YMKMapViewPort YMKMapViewPortFromDictionary(NSDictionary * dict);
*/

	}
}
