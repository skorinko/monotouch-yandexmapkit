using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using YandexLibBinding;

namespace YandexMonoTest
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		YandexMonoTestViewController viewController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			
			YMKConfiguration.sharedInstance.apiKey = "gqGikdRyd-zIvilbcas1qNSK1kFuFoRyBi~rEYTEMDYcaa1lBDV1Y9Bts7oRqxf8Y8qYOU-msY2jNfUU17GjgSRz901aihl5qrHAl4ebciA=";
			//YMKVariables.YMKConsoleLoggingEnabled = true;

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new YandexMonoTestViewController ();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();

			
			return true;
		}
	}
}

