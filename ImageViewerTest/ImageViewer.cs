using System;
using Xamarin.Forms;
using NControl.Abstractions;
using System.Linq;

namespace ImageViewerTest
{
	public class ImageViewer: NControlView
	{
		private Image _image;
		private NGraphics.Point _startPoint;

		public ImageViewer ()
		{
			IsClippedToBounds = true;

			_image = new Image ();
			_image.Scale = 2.0;	
			_image.InputTransparent = true;

			Content = _image;
		}

		public static BindableProperty SourceProperty = 
			BindableProperty.Create<ImageViewer, ImageSource> (p => p.Source, null,
				BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) => {
					var ctrl = (ImageViewer)bindable;
					ctrl.Source = newValue;
				});

		public ImageSource Source {
			get{ return (ImageSource)GetValue (SourceProperty); }
			set {
				SetValue (SourceProperty, value);
				_image.Source = value;
			}
		}

		public override bool TouchesBegan (System.Collections.Generic.IEnumerable<NGraphics.Point> points)
		{
			_startPoint = points.FirstOrDefault ();
			_startPoint.X -= _image.TranslationX;
			_startPoint.Y -= _image.TranslationY;
			return true;
		}

		public override bool TouchesMoved (System.Collections.Generic.IEnumerable<NGraphics.Point> points)
		{
			var newPoint = points.FirstOrDefault ();
			var diff = new NGraphics.Point (newPoint.X - _startPoint.X, newPoint.Y - _startPoint.Y);

			_image.TranslationX = diff.X;
			_image.TranslationY = diff.Y;

			return true;
		}

		public override bool TouchesCancelled (System.Collections.Generic.IEnumerable<NGraphics.Point> points)
		{           
			return true;
		}

		public override bool TouchesEnded (System.Collections.Generic.IEnumerable<NGraphics.Point> points)
		{           
			return true;
		}
	}
}

