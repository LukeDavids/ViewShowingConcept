using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.CustomerSplitView")]
    public class CustomerSplitView : BaseView<CustomerSplitViewModel>
    {
        bool IsViewCreated { get; set; }
        public CustomerSplitView()
        {
            ViewType = ViewType.CustomerSplit;
            ViewTag = ViewType.ToString();
            Mvx.RegisterSingleton(()=>this);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.CustomerSplit;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerSplitView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState) {
            
            IsViewCreated = true;
        }

        public override void OnResume()
        {
            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.CustomerList, ViewFrame.HalfScreenTop, "");
            base.OnResume();
        }
    }
}