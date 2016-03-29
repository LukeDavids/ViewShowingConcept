using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;

namespace ViewShowingConcept.Android.Views
{
    [Activity(Label = "View for ContainerView")]
    public class ContainerView : MvxCachingFragmentCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContainerView);
        }
    }
}
