using Android;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Android.Views
{
    [Register("ViewShowingConcept.android.views.CustomerEditFragment")]
    public class CustomerEditFragment : BaseView
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SubViewType = SubView.CustomerEdit;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerEditView, null);
        }
    }
}
