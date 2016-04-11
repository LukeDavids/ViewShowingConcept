using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Renderscripts;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;
using ViewShowingConcept.Android.Interfaces;
using ViewShowingConcept.Android.Views;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        //protected override IMvxAndroidViewPresenter CreateViewPresenter()
        //{
        //    var customPresenter = new CustomPresenter();
        //    Mvx.RegisterSingleton<ICustomPresenter>(customPresenter);
        //    return customPresenter;
        //}
    }
}
