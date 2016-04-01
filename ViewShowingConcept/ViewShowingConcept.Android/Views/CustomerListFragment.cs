using Android;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("ViewShowingConcept.android.views.CustomerListFragment")]
    public class CustomerListFragment : BaseView<CustomerListViewModel>, ISubView
    {
        public CustomerListFragment() {
            Fragment = this;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SubViewType = SubView.CustomerList;
            
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerListView, null);
        }

        public bool IsMenuVisible { get; set; }
        public MvxFragment Fragment { get; set; }
    }
}
