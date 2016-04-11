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
    [Register("viewshowingconcept.android.views.DummyTab2View")]
    public class DummyTab2View : BaseView<DummyTab2ViewModel>
    {

        public DummyTab2View()
        {
            ViewType = ViewType.DummyTab2View;
            ViewTag = ViewType.ToString();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.DummyTab2View;
            
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.DummyTab2View, null);
        }

        //public override void OnViewCreated(View view, Bundle savedInstanceState)
        //{
        //    Activity.SetTitle(Resource.String.CustomerView);
        //}

    }
}
