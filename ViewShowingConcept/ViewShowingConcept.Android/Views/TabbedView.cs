using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("ViewShowingConcept.android.views.TabbedView")]
    public class TabbedView : BaseView<TabbedViewModel>
    {
        public CoordinatorLayout _coordinatorLayout;
        private List<MvxFragmentPagerAdapter.FragmentInfo> _fragments;
        private ViewPager _viewPager;
        private ProgressDialog pd;
        private MvxFragment _customerListView;
        private Toolbar toolbar;

        public TabbedView()
        {
            ViewType = ViewType.TabbedView;
            ViewTag = ViewType.ToString();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.TabbedView;
            
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            //Check Device Type
            if (DeviceUtilsService.IsTabletDevice(ApplicationContext))
            {
                SetContentView(Resource.Layout.TabbedView);
                RequestedOrientation = ScreenOrientation.SensorLandscape;
            }
            else {
                SetContentView(Resource.Layout.TabbedView);
                RequestedOrientation = ScreenOrientation.Portrait;
            }

            toolbar = ignored.FindViewById<Toolbar>(Resource.Id.toolbar);
            _coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.main_content);
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            if (_viewPager != null)
            {
                _fragments = new List<MvxFragmentPagerAdapter.FragmentInfo>
                {
                    //new MvxFragmentPagerAdapter.FragmentInfo("Home", typeof (SyncView),
                    //    typeof (SyncViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Customers", typeof (CustomerListView),
                        typeof (CustomerListViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Products", typeof (ProductsView),
                        typeof (ProductsViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Orders", typeof (OrdersView),
                        typeof (OrdersViewModel))
                };
                _viewPager.Adapter = new MvxFragmentPagerAdapter(this, SupportFragmentManager, _fragments);
            }

            var tabLayout = (TabLayout) FindViewById(Resource.Id.tabs);
            tabLayout.SetTabTextColors(Color.Gray, Color.Black);
            tabLayout.SetSelectedTabIndicatorColor(Color.ParseColor("#BA77FF"));
            tabLayout.SetupWithViewPager(_viewPager);


            //Title settings
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Onsight";
            toolbar.SetTitleTextColor(Color.ParseColor("#424b54"));


            return this.BindingInflate(Resource.Layout.TabbedView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            Activity.SetTitle(Resource.String.CustomerView);
        }

    }
}
