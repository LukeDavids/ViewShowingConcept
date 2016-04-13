using System.Collections.Generic;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.TabbedView")]
    public class TabbedView : BaseView<TabbedViewModel>
    {
        public CoordinatorLayout _coordinatorLayout;
        private List<MvxFragmentPagerAdapter.FragmentInfo> _fragments;
        private ViewPager _viewPager;

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
            return this.BindingInflate(Resource.Layout.TabbedView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            _coordinatorLayout = view.FindViewById<CoordinatorLayout>(Resource.Id.main_content);
            _viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);

            if (_viewPager != null)
            {
                _fragments = new List<MvxFragmentPagerAdapter.FragmentInfo>
                {
                    new MvxFragmentPagerAdapter.FragmentInfo("Customers", typeof (CustomerListView),
                        typeof (CustomerListViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Dummy Tab 1", typeof (DummyTab1View),
                        typeof (DummyTab1ViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Dummy Tab 2", typeof (DummyTab2View),
                        typeof (DummyTab2ViewModel))
                };
                _viewPager.Adapter = new MvxFragmentPagerAdapter(Context, FragmentManager, _fragments);
            }

            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetTabTextColors(Color.Gray, Color.Black);
            tabLayout.SetSelectedTabIndicatorColor(Color.ParseColor("#BA77FF"));
            tabLayout.SetupWithViewPager(_viewPager);
            Activity.SetTitle(Resource.String.CustomerView);
        }
    }
}
