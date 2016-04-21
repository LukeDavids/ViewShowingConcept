using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace ViewShowingConcept.Android.Views
{
    [Register("viewshowingconcept.android.views.TabbedView")]
    public class TabbedView : BaseView<TabbedViewModel>
    {

        TabLayout TabLayout;
        public static Tabs CurrentTab { get; set; }

        public TabbedView()
        {
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
            TabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);

            TabLayout.AddTab(TabLayout.NewTab().SetText("Customers"));
            TabLayout.AddTab(TabLayout.NewTab().SetText("Dummy Tab 1"));
            TabLayout.AddTab(TabLayout.NewTab().SetText("Dummy Tab 2"));
            TabLayout.AddTab(TabLayout.NewTab().SetText("Dummy Tab 3"));

            TabLayout.SetTabTextColors(Color.Gray, Color.Black);
            TabLayout.SetSelectedTabIndicatorColor(Color.Purple);


            TabLayout.TabSelected += (o, s) => {
                switch (TabLayout.SelectedTabPosition)
                {
                    case 0:
                        ContainerView.SetupViews();
                        ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.CustomerSplit, ViewFrame.FullScreenTabs, "");
                        CurrentTab = Tabs.CustomersTab;
                        break;
                    case 1:
                        ContainerView.SetupViews();
                        ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.DummyTab1View, ViewFrame.FullScreenTabs, "");
                        CurrentTab = Tabs.Dummy1Tab;
                        break;
                    case 2:
                        ContainerView.SetupViews();
                        ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.DummyTab2View, ViewFrame.FullScreenTabs, "");
                        CurrentTab = Tabs.Dummy2Tab;
                        break;
                    case 3:
                        ContainerView.SetupViews();
                        ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.DummyTab3View, ViewFrame.FullScreenTabs, "");
                        CurrentTab = Tabs.Dummy3Tab;
                        break;
                }
            };

            //Set initial tab
            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.CustomerSplit, ViewFrame.FullScreenTabs, "");

            base.OnViewCreated(view, savedInstanceState);
        }
    }
}
