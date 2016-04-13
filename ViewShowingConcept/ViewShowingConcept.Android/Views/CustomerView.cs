using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.CustomerView")]
    public class CustomerView : BaseView<CustomerViewModel>
    {

        public CustomerView()
        {
            ViewType = ViewType.CustomerView;
            ViewTag = ViewType.ToString();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.CustomerView;

            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            Activity.SetTitle(Resource.String.CustomerView);
        }

    }
}
