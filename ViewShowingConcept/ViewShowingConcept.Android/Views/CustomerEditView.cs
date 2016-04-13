using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.CustomerEditFragment")]
    public class CustomerEditView : BaseView<CustomerEditViewModel>
    {
        public CustomerEditView()
        {
            ViewType = ViewType.CustomerEdit;
            ViewTag = ViewType.ToString();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.CustomerEdit;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerEditView, null);
        }

    }
}
