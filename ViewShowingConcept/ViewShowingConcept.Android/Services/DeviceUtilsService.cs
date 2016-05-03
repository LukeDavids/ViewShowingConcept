using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Onsight.Android.Services
{
    public static class DeviceUtilsService
    {
        public static bool IsTabletDevice(Context context)
        {
            try
            {
                // Compute screen size
                DisplayMetrics dm = context.Resources.DisplayMetrics;
                float screenWidth = dm.WidthPixels / dm.Xdpi;
                float screenHeight = dm.HeightPixels / dm.Ydpi;
                double size = Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));

                // Tablet devices should have a screen size greater than 6.8 inches
                return size >= 6.8;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.HelpLink);
                return false;
            }
        }
    }
}