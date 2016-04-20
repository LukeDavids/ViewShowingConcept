using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.TabbedView")]
    public class TabbedView : BaseView<TabbedViewModel>
    {
        public CoordinatorLayout CoordinatorLayout { get; set; }
        private static FragmentManager StaticFragmentManager { get; set; }
        public static ViewPager ViewPager { get; set; }
        public static TabLayout TabLayout { get; set; }
        public static Tabs CurrentTab { get; set; }

        public TabbedView()
        {
            CurrentTab = Tabs.CustomersTab;
            ViewType = ViewType.TabbedView;
            ViewTag = ViewType.ToString();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewType = ViewType.TabbedView;
            OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.TabbedView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            CoordinatorLayout = view.FindViewById<CoordinatorLayout>(Resource.Id.main_content);
            ViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            List<MvxFragmentPagerAdapter.FragmentInfo> _fragments;
            StaticFragmentManager = FragmentManager;
            _fragments = CreateTabs();

            ViewPager.PageSelected += (object sender, ViewPager.PageSelectedEventArgs e) =>
            {
                switch (e.Position)
                {
                    case 0:
                        CurrentTab = Tabs.CustomersTab;
                        break;
                    case 1:
                        CurrentTab = Tabs.Dummy1Tab;
                        ContainerView.PreviousFragment = ViewType.None;
                        FragmentManager.PopBackStack(null, FragmentManager.PopBackStackInclusive);
                        break;
                    case 2:
                        CurrentTab = Tabs.Dummy2Tab;
                        ContainerView.PreviousFragment = ViewType.None;
                        FragmentManager.PopBackStack(null, FragmentManager.PopBackStackInclusive);
                        break;
                    case 3:
                        CurrentTab = Tabs.Dummy3Tab;
                        ContainerView.PreviousFragment = ViewType.None;
                        FragmentManager.PopBackStack(null, FragmentManager.PopBackStackInclusive);
                        break;
                    default:
                        CurrentTab = Tabs.CustomersTab;
                        ContainerView.PreviousFragment = ViewType.None;
                        FragmentManager.PopBackStack(null, FragmentManager.PopBackStackInclusive);
                        break;
                }
            };

            TabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);
            TabLayout.SetTabTextColors(Color.Gray, Color.Black);
            TabLayout.SetSelectedTabIndicatorColor(Color.ParseColor("#BA77FF"));
            ViewPager.OffscreenPageLimit = _fragments.Count;
            TabLayout.SetupWithViewPager(ViewPager);
            Activity.SetTitle(Resource.String.CustomerView);
        }

        public static List<MvxFragmentPagerAdapter.FragmentInfo> CreateTabs()
        {
            if (ViewPager != null)
            {
                List<MvxFragmentPagerAdapter.FragmentInfo> _fragments = new List<MvxFragmentPagerAdapter.FragmentInfo>
                {
                    new MvxFragmentPagerAdapter.FragmentInfo("Customers", typeof (CustomerSplitView),
                        typeof (CustomerSplitViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Dummy Tab 1", typeof (DummyTab1View),
                        typeof (DummyTab1ViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Dummy Tab 2", typeof (DummyTab2View),
                        typeof (DummyTab2ViewModel)),
                    new MvxFragmentPagerAdapter.FragmentInfo("Dummy Tab 3", typeof (DummyTab3View),
                        typeof (DummyTab3ViewModel))
                };
                ViewPager.Adapter = new MvxFragmentPagerAdapter(Application.Context, StaticFragmentManager, _fragments);

                return _fragments;
            }
            return null;
        }
    }
}
