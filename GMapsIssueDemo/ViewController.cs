using System;
using Foundation;
using Google.Maps;
using UIKit;

namespace GMapsIssueDemo
{
	class GoogleMapsDelegate : MapViewDelegate
	{
		public override UIView MarkerInfoWindow(MapView mapView, Marker marker)
		{
			UIView toBeView = new UIView();
			//toBeView.AddSubview(iv);
			toBeView.BackgroundColor = UIColor.Blue;
			toBeView.Frame = new CoreGraphics.CGRect(0, 0, 100, 100);
			return toBeView;
		}
	}
	public partial class ViewController : UIViewController
	{
		MapView mapView;
		private GoogleMapsDelegate myDel;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			mapView = new MapView(this.View.Bounds);

			myDel = new GoogleMapsDelegate();
			CameraPosition camera = CameraPosition.FromCamera(new CoreLocation.CLLocationCoordinate2D(41.013792f, 28.971761f), 13);
			mapView.Camera = camera;
			mapView.MyLocationEnabled = true;
			mapView.Delegate = myDel;

			this.View.InsertSubview(mapView, 0);

			Marker aMarker = new Marker();

			aMarker.Position = new CoreLocation.CLLocationCoordinate2D(41.033672f, 28.976482f);
			//aMarker.Snippet = "Test Snippet";//(string)aLocation["name"];
			aMarker.AppearAnimation = MarkerAnimation.Pop;
			aMarker.Map = mapView;

		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			mapView.StartRendering();
		}

		public override void ViewWillDisappear(bool animated)
		{
			mapView.StopRendering();
			base.ViewWillDisappear(animated);
		}


	}
}
