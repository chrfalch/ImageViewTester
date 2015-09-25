using System;

using Xamarin.Forms;
using System.Reflection;

namespace ImageViewerTest
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Image Container:"
						},
						new ContentView{
							BackgroundColor = Color.Gray,
							Padding = 25,
							HeightRequest = 200,
							Content = new ImageViewer{
								Source = ImageSource.FromStream(() => {
									var assembly = this.GetType().GetTypeInfo().Assembly;
									return assembly.GetManifestResourceStream ("ImageViewerTest.myimage.jpg");
								}),
							}                           
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

