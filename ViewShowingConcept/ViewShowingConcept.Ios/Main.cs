using System;
using System.Diagnostics;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;

namespace ViewShowingConcept.Ios
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ffs)
            {
                Mvx.Trace(MvxTraceLevel.Error, ffs.Message);
                Mvx.Error(ffs.Message,null);
                Debug.WriteLine(ffs.Message);
            }
        }
    }
}