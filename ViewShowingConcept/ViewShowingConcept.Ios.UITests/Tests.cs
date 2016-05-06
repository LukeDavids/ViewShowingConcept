using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace ViewShowingConcept.Ios.UITests
{
    [TestFixture]
    public class Tests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the iOS app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            /**
            app = ConfigureApp
                .iOS
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                .AppBundle ("../ViewShowingConcept.Ios/bin/iPhoneSimulator/Debug/ViewShowingConceptIos.app")
                .StartApp();
            */
            //Fill in Device Details here 
            //Only works for specific device
            const string simId = "89BB0F84-C51D-48E9-ABF1-9E352738F66B"; //iPhone ** (*.* Simulator)
            app = ConfigureApp.iOS.DeviceIdentifier(simId).StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.WaitForElement(c => c.Text("Show Tabs"));
            app.WaitForElement(c => c.Text("Edit"));
        }
    }
}

