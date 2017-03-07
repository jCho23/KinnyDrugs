using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace KinnyDrugs
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			//app.Tap(x => x.Class("android.widget.ImageView").Index(6));
			app.WaitForElement("Offers");
			app.Tap("Pharmacy");
			app.Screenshot("Tapped on Pharmacy Button");

			app.WaitForElement("Transfer Rx");
			app.Tap(x => x.Class("android.widget.TextView").Index(1));
			app.Screenshot("Tapped on 'Refill by Rx Number'");

			app.WaitForElement("Refill by Rx Number");
			app.Tap(x => x.Class("android.widget.TextView").Index(7));
			app.Screenshot("Tapped on Store Locator");


			app.Tap(x => x.Class("android.widget.EditText").Index(0));
			app.Screenshot("'Tapped on 'Enter Address or ZipCode'");

			app.EnterText("94111");
			app.Screenshot("Wrote in my ZipCode, 94111");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap(x => x.Class("android.widget.TextView").Index(1));
			app.Screenshot("Tapped on Search Button");

			app.ScrollDown();
			app.Screenshot("Scrolling Down to Kinney Drugs #63");

			app.Tap(x => x.Class("android.widget.TextView").Index(1));
			app.Screenshot("Tapped on Kinney Drugs #63");

			app.Tap("Back");
			app.Screenshot("Home Button disappeared, so I tapped Back button to return to Home");

			app.Tap("Back");
			app.Screenshot("Tapped Back button to return to Home");

			app.Tap(x => x.Class("android.widget.ImageView").Index(0));
			app.Screenshot("Home Button appeared again, tapped 'Home' button");
		}

	}
}
