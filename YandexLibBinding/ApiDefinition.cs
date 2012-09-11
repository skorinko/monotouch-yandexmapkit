using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace YandexLibBinding
{
	using YMKMapCoordinate = MonoTouch.CoreLocation.CLLocationCoordinate2D;
	using YMKMapDegrees = System.Double;
	using YMKMapAccuracy = System.Double;
	using YMKMapSpeed = System.Double;
	using YMKMapDirection = System.Double;
	using YMKMapDistance = System.Double;
	
	//YMKRuler
	[BaseType (typeof (UIView))]
	public interface YMKRuler {
		[Export ("scale")] double Scale { get; set; }
	}
	
	//YMKMapLayerInfo
	[BaseType (typeof (NSObject))]
	public interface YMKMapLayerInfo {
		[Export ("identifier")] ulong identifier { get; set; }
		[Export ("localizedName")] string localizedName { get; set; }
		[Export ("auxiliary")] bool auxiliary { get; set; }
		[Export ("sizeInPixels")] ulong sizeInPixels { get; set; }
		[Export ("allowsNightMode")] bool allowsNightMode { get; set; }
	}

	//YMKMapLayersConfiguration
	[BaseType (typeof (NSObject))]
	public interface YMKMapLayersConfiguration {
		[Export ("infos")] NSArray infos { get; set; }
		[Export ("hasServiceLayer")] bool hasServiceLayer { get; set; }
		[Export ("serviceLayerInfo")][Static] YMKMapLayerInfo serviceLayerInfo { get; }
		[Export ("infoForLayerWithIdentifier:")]
		YMKMapLayerInfo infoForLayerWithIdentifier(ushort identifier);
	}

	//YMKConfiguration
	[BaseType (typeof (NSObject))]
	public interface YMKConfiguration {
		[Export ("apiKey")] string apiKey { get; set; }
		[Export ("sharedInstance")][Static] YMKConfiguration sharedInstance { get; }
		[Export ("mapLayers")][Static] YMKMapLayersConfiguration mapLayers { get; }
	}

	//YMKGeoObject
	[BaseType (typeof (NSObject))]
	[Model]
	public interface YMKGeoObject {
		[Export ("coordinate")] YMKMapCoordinate coordinate { get; }
	}

	//YMKAnnotation
	[BaseType (typeof (YMKGeoObject))]
	[Model]
	public interface YMKAnnotation {
		[Export ("title")] string title { get; set; }
		[Export ("subtitle")] string subtitle { get; set; }
	}

	//YMKAnnotationImage
	[BaseType (typeof (NSObject))]
	public interface YMKAnnotationImage {
		[Export ("centerOffset")] System.Drawing.PointF centerOffset { get; set; }
		[Export ("image")] UIImage image { get; set; }
		[Export ("blueAnnotationImage")] YMKAnnotationImage blueAnnotationImage { get; set; }
		[Export ("greenAnnotationImage")] YMKAnnotationImage greenAnnotationImage { get; set; }
		[Export ("initWithImage:centerOffset:")]
		IntPtr Constructor (UIImage image, System.Drawing.PointF centerOffset);
		[Export ("annotationImageWithImage:centerOffset:")]
		NSObject annotationImageWithImage(UIImage image, System.Drawing.PointF centerOffset);
	}

	//YMKTrafficInformer
	[BaseType (typeof (NSObject))]
	public interface YMKTrafficInformer {
		[Export ("coord")] YMKMapCoordinate coord { get; set; }
		[Export ("value")] uint value { get; set; }
		[Export ("color")] YMKTrafficInformerColor color { get; set; }
		[Export ("expirationDate")] NSDate expirationDate { get; set; }
	}

	//YMKUserLocation
	[BaseType (typeof (NSObject))]
	public interface YMKUserLocation : YMKAnnotation {
		[Export ("location")][Static] MonoTouch.CoreLocation.CLLocation location { get; }
		//[Export ("title")][Static] string title { get; }
		//[Export ("subtitle")] string subtitle { get; set; }
		[Export ("updating")][Static] bool updating { [Bind ("isUpdating")] get; }
	}

	//YMKDraggableAnnotation
	[BaseType (typeof (YMKAnnotation))]
	public interface YMKDraggableAnnotation {
		[Export ("coordinate")] YMKMapCoordinate coordinate { get; set; }
	}

	//YMKCalloutContentView
	[BaseType (typeof (NSObject))]
	public interface YMKCalloutContentView {
		[Export ("setHighlighted:")]
		void setHighlighted(bool highlighted);
	}

	//YMKCalloutViewDelegate
	[BaseType (typeof (NSObject))]
	[Model]
	public interface YMKCalloutViewDelegate {
		[Export ("calloutViewGotSingleTap:")]
		void calloutViewGotSingleTap(YMKCalloutView view);
		[Export ("calloutViewGotTapAtLeftAccessoryView:")]
		void calloutViewGotTapAtLeftAccessoryView(YMKCalloutView view);
		[Export ("calloutViewGotTapAtRightAccessoryView:")]
		void calloutViewGotTapAtRightAccessoryView(YMKCalloutView view);
	}

	//YMKCalloutView
	[BaseType (typeof (UIView))]
	public interface YMKCalloutView {
		[Export ("leftView")] UIView leftView  { get; set; }
		[Export ("rightView")] UIView rightView  { get; set; }
		[Export ("contentView")] /*UIView*/YMKCalloutContentView contentView { get; set; }
		[Export ("leftView")] System.Drawing.RectangleF nonTransformedFrame { get; set; }
		[Export ("highlighted")] bool highlighted { get; }
		[Export ("reuseIdentifier")] string reuseIdentifier { get; }

		[Export ("initWithReuseIdentifier:")]
		IntPtr Constructor (string aReuseIdentifier);
		[Export ("setAnchorPoint:boundaryRect:")]
		void setAnchorPoint(System.Drawing.Rectangle point, System.Drawing.Rectangle rect); // Point in points ({.5,.5} = center of superview). Rect in superview coordinates.
		[Export ("hide")]
		void hide();
		[Export ("showInView:")]
		void showInView(UIView view);
		[Export ("setLeftView:animated:")]
		void setLeftView(UIView newLeftView, bool animated);
		[Export ("setLeftView:animated:")]
		void setRightView(UIView newRightView, bool animated);
		[Export ("animateAppearance")]
		void animateAppearance();
		[Export ("minimumSidePadding")]
		float minimumSidePadding();
		[Export ("sizeWithContentView:leftView:rightView:boundaryRect:")]
		System.Drawing.SizeF sizeWithContentView(UIView contentView, UIView leftView, UIView rightView, System.Drawing.RectangleF rect);
		[Export ("prepareForReuse")]
		void prepareForReuse();

		[Wrap ("WeakDelegate")]
		YMKCalloutViewDelegate Delegate { get; set; }
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}

	//YMKAnnotationView
	[BaseType (typeof (UIView))]
	public interface YMKAnnotationView {
		[Export ("reuseIdentifier")] string reuseIdentifier { get; }
		[Export ("annotation")] /*NSObject*/YMKAnnotation annotation { get; set; }
		[Export ("centerOffset")] System.Drawing.PointF centerOffset { get; set; }
		[Export ("selected")] bool selected { [Bind ("isSelected")] get; set; }
		[Export ("image")] UIImage image { get; set; }
		[Export ("alignCenter")] bool alignCenter { get; set; }
		[Export ("zIndex")] int zIndex { get; set; }
		[Export ("canShowCallout")] bool canShowCallout { get; set; }
		[Export ("rightCalloutAccessoryView")] UIView rightCalloutAccessoryView { get; set; }
		[Export ("leftCalloutAccessoryView")] UIView leftCalloutAccessoryView { get; set; }
		[Export ("calloutOffset")] System.Drawing.PointF calloutOffset { get; set; }
		[Export ("minimumMargins")] UIEdgeInsets minimumMargins { get; }
		[Export ("calloutContentView")] /*UIView*/YMKCalloutContentView calloutContentView { get; set; } 

		[Export ("initWithAnnotation:reuseIdentifier:")]
		IntPtr Constructor (/*NSObject*/YMKAnnotation annotation, string reuseIdentifier);
		[Export ("prepareForReuse")]
		void prepareForReuse();
		[Export ("setSelected:animated:")]
		void setSelected(bool selected, bool animated);
		[Export ("setLeftCalloutAccessoryView:animated:")]
		void setLeftCalloutAccessoryView(UIView view, bool animated);
		[Export ("setRightCalloutAccessoryView:animated:")]
		void setRightCalloutAccessoryView(UIView view, bool animated);
	}

	//YMKPinAnnotationView
	[BaseType (typeof (YMKAnnotationView))]
	public interface YMKPinAnnotationView {
		[Export ("animatesDrop")] bool animatesDrop { get; set; }
		[Export ("pinColor")] YMKPinAnnotationColor pinColor { get; set; }
	}

	//YMKMapViewDelegate
	[BaseType (typeof (NSObject))]
	[Model]
	public interface YMKMapViewDelegate {
		[Export ("mapView:viewForAnnotation:")]
		YMKAnnotationView mapView(YMKMapView mapView, /*id*/YMKAnnotation annotation);
		[Export ("mapView:calloutViewForAnnotation:")]
		YMKCalloutView mapViewCalloutViewForAnnotation(YMKMapView view, /*id*/YMKAnnotation annotation); //original mapView
		[Export ("mapView:annotationView:calloutAccessoryControlTapped:")]
		void mapView(YMKMapView mapView, YMKAnnotationView view, UIControl control);
		[Export ("mapView:annotationViewCalloutTapped:")]
		void mapView(YMKMapView mapView, YMKAnnotationView view);
		[Export ("mapView:didAddAnnotationViews:")]
		void mapView(YMKMapView mapView, UIView [] views);
		[Export ("mapView:regionDidChangeAnimated:")]
		void mapView(YMKMapView mapView, bool animated);
		[Export ("mapView:regionWillChangeAnimated:")]
		void mapViewRegionWillChangeAnimated(YMKMapView mapView, bool animated);//XXX
		[Export ("mapViewWasDragged:")]
		void mapViewWasDragged(YMKMapView mapView);
		[Export ("mapViewShouldFollowUserLocation:")]
		bool mapViewShouldFollowUserLocation(YMKMapView mapView);
		[Export ("mapViewShouldDisplayHeadingCalibration:")]
		bool mapViewShouldDisplayHeadingCalibration(YMKMapView mapView);
		[Export ("mapView:locationManagerDidReceiveError:")]
		void mapView(YMKMapView mapView, NSError error);
		[Export ("mapView:gotSingleTapAtCoordinate:")]
		void mapView(YMKMapView mapView, YMKMapCoordinate coordinate);
		[Export ("mapView:gotTapAndHoldAtCoordinate:")]
		void mapViewGotTapAndHoldAtCoordinate(YMKMapView mapView, YMKMapCoordinate coordinate); //original mapView
		[Export ("mapViewDidResetRotationAngle:")]
		void mapViewDidResetRotationAngle(YMKMapView mapView);
		[Export ("mapViewVisibleRect:")]
		System.Drawing.RectangleF mapViewVisibleRect(YMKMapView mapView);
	}

	//YMKMapView
	[BaseType (typeof (UIView))]
	public partial interface YMKMapView {
		[Export ("visibleLayerIdentifier")] /*uint16_t*/uint visibleLayerIdentifier { get; set; }
		[Export ("region")] YMKMapRegion region { get; set; }
		[Export ("centerCoordinate")] YMKMapCoordinate centerCoordinate { get; set; }
		[Export ("centerMapPoint")] YMKMapPoint centerMapPoint { get; set; }
		[Export ("zoomLevel")] uint zoomLevel { get; }
		[Export ("annotations")] YMKAnnotation[] annotations { get; }
		[Export ("viewPort")] YMKMapViewPort viewPort { get; }
		[Export ("scale")] double scale { get; }
		[Export ("selectedAnnotation")] /*id*/YMKAnnotation selectedAnnotation { get; set; }
		[Export ("userLocation")] YMKUserLocation userLocation { get; }
		[Export ("userLocationVisible")] bool userLocationVisible { get; }
		[Export ("showsUserLocation")] bool showsUserLocation { get; set; }
		[Export ("tracksUserLocation")] bool tracksUserLocation { get; set; }
		[Export ("showTraffic")] bool showTraffic { get; set; }
		[Export ("trafficInformers")] YMKTrafficInformer[] trafficInformers { get; }
		[Export ("fetchingJams")] bool fetchingJams { get; }
		[Export ("showRoute")] bool showRoute { get; set; }
		[Export ("angle")] float angle { get; set; }
		[Export ("canUseCompass")] bool canUseCompass { get; set; }
		[Export ("nightMode")] bool nightMode { get; set; }

		[Export ("setCenterCoordinate:animated:")]
		void setCenterCoordinate(YMKMapCoordinate coordinate, bool animated);
		[Export ("setRegion:animated:")]
		void setRegion(YMKMapRegion region, bool animated);
		[Export ("setCenterCoordinate:atZoomLevel:animated:")]
		void setCenterCoordinate(YMKMapCoordinate coordinate, uint zoomLevel, bool animated);
		[Export ("dequeueReusableAnnotationViewWithIdentifier:")]
		NSObject dequeueReusableAnnotationViewWithIdentifier(string identifier);
		[Export ("dequeueReusableCalloutViewWithIdentifier:")]
		NSObject dequeueReusableCalloutViewWithIdentifier(string identifier);
		[Export ("addAnnotation:")]
		void addAnnotation(/*id*/YMKAnnotation annotation);
		[Export ("addAnnotations:")]
		void addAnnotations(YMKAnnotation [] annotations);
		[Export ("removeAnnotation:")]
		void removeAnnotation(/*id*/ YMKAnnotation annotation);
		[Export ("removeAnnotations:")]
		void removeAnnotations(YMKAnnotation [] annotations);
		[Export ("scrollToAnnotation:animated:")]
		void scrollToAnnotation(/*id*/ YMKAnnotation annotation, bool animated);
		[Export ("viewForAnnotation:")]
		YMKAnnotationView viewForAnnotation(/*id*/YMKAnnotation annotation);
		[Export ("convertLLToMapView:")]
		System.Drawing.PointF convertLLToMapView(YMKMapCoordinate coord);
		[Export ("convertMapViewPointToLL:")]
		YMKMapCoordinate convertMapViewPointToLL(System.Drawing.PointF point);
		[Export ("convertMapPointToMapView:")]
		System.Drawing.PointF convertMapPointToMapView(YMKMapPoint point);
		[Export ("convertMapViewPointToMapPoint:")]
		YMKMapPoint convertMapViewPointToMapPoint(System.Drawing.PointF point);
		[Export ("fitRegion:")]
		YMKMapRegion fitRegion(YMKMapRegion region);
		[Export ("setAngle:animated:")]
		void setAngle(float angle, bool animated);
		[Export ("dismissHeadingCalibrationDisplay")]
		void dismissHeadingCalibrationDisplay();
		[Export ("calculateCacheSize:")]
		ulong calculateCacheSize([NullAllowed] NSError error);
		[Export ("clearCache")]
		void clearCache();
		[Export ("zoomIn")]
		void zoomIn();
		[Export ("zoomOut")]
		void zoomOut();
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Wrap ("WeakDelegate")]
		YMKMapViewDelegate Delegate { get; set; }
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}

	[Static]
	public interface YMKConstants {
		[Field ("kYMKMapStructsComparisonAccuracy", "__Internal")] 
		System.Double kYMKMapStructsComparisonAccuracy { get; }
		
		[Field ("kYMKMapStructsCoordinateLatitudeMinValue", "__Internal")] 
		System.Double kYMKMapStructsCoordinateLatitudeMinValue { get; }
		
		[Field ("kYMKMapStructsCoordinateLatitudeMaxValue", "__Internal")] 
		System.Double kYMKMapStructsCoordinateLatitudeMaxValue { get; }
		
		[Field ("kYMKMapStructsCoordinateLongitudeMinValue", "__Internal")] 
		System.Double kYMKMapStructsCoordinateLongitudeMinValue { get; }
		
		[Field ("kYMKMapStructsCoordinateLongitudeMaxValue", "__Internal")] 
		System.Double kYMKMapStructsCoordinateLongitudeMaxValue { get; }
		
		[Field ("kYMKMapRegionSizeDeltaLatitudeMinValue", "__Internal")] 
		System.Double kYMKMapRegionSizeDeltaLatitudeMinValue { get; }
		
		[Field ("kYMKMapRegionSizeDeltaLatitudeMaxValue", "__Internal")] 
		System.Double kYMKMapRegionSizeDeltaLatitudeMaxValue { get; }
		
		[Field ("kYMKMapRegionSizeDeltaLongitudeMinValue", "__Internal")] 
		System.Double kYMKMapRegionSizeDeltaLongitudeMinValue { get; }
		
		[Field ("kYMKMapRegionSizeDeltaLongitudeMaxValue", "__Internal")] 
		System.Double kYMKMapRegionSizeDeltaLongitudeMaxValue { get; }
		
		[Field ("YMKMapDegreesInvalid", "__Internal")] 
		System.Double YMKMapDegreesInvalid { get; }

		[Field ("YMKUserLocationNeedsSubtitleNotification", "__Internal")]
		NSString YMKUserLocationNeedsSubtitleNotification { get; }
	}

	/*
	[Static]
	public interface YMKVariables 
	{
		[Field ("YMKConsoleLoggingEnabled", "__Internal")] 
		System.Int32 YMKConsoleLoggingEnabled { get; set; }
	}
	*/

}

