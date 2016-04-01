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
    [Register("ViewShowingConcept.android.views.CustomerDetailFragment")]
    public class CustomerDetailFragment : BaseView<CustomerDetailViewModel>, ISubView
    {
        public CustomerDetailFragment()
        {
            Fragment = this;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SubViewType = SubView.CustomerDetails;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerDetailView, null);
        }

        public bool IsMenuVisible { get; set; }
        public MvxFragment Fragment { get; set; }
    }
}
