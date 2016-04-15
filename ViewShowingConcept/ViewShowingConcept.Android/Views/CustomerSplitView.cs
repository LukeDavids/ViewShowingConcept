using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.CustomerSplitView")]
    public class CustomerSplitView : BaseView<CustomerSplitViewModel>
    {

        public CustomerSplitView()
        {
            ViewType = ViewType.CustomerSplit;
            ViewTag = ViewType.ToString();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.CustomerSplit;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerSplitView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState) {
            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.CustomerList, ViewFrame.HalfScreenTop, ""); // Here is where the problem is somehow, splitview isnt fully instantiated so Resource.Id.list_frame doesnt yet exist or is null
            Activity.SetTitle(Resource.String.CustomerListView);
        }
    }
}