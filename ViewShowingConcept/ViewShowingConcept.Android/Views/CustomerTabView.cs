using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.CustomerTabView")]
    public class CustomerTabView : BaseView<CustomerTabViewModel>
    {
        public CustomerTabView()
        {
            ViewType = ViewType.CustomerTab;
            ViewTag = ViewType.ToString();
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerTabView, null);
        }

    }
}
