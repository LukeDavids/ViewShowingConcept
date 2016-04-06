using Android;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.Fragging;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Android.Views
{
    [Register("ViewShowingConcept.android.views.CustomerListView")]
    public class CustomerListView : BaseView<CustomerListViewModel>
    {

        public CustomerListView()
        {
            ViewType = ViewType.CustomerList;
            ViewTag = ViewType.ToString();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.CustomerList;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerListView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState) {
            Activity.SetTitle(Resource.String.CustomerListView);
        }
    }
}
