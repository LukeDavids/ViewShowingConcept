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
    [Register("ViewShowingConcept.android.views.CustomerEditFragment")]
    public class CustomerEditFragment : BaseView<CustomerEditViewModel>, ISubView
    {
        public CustomerEditFragment()
        {
            Fragment = this;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SubViewType = SubView.CustomerEdit;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerEditView, null);
        }

        public bool IsMenuVisible { get; set; }
        public MvxFragment Fragment { get; set; }
    }
}
