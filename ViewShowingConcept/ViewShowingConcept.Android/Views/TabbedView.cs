using System;
using System.Collections.Generic;
using System.Linq;
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
using ViewShowingConcept.Core.ViewModels.Container;
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
                        CurrentTab = Tabs.CustomersTab;
                        if (ContainerViewModel.CustomersBackStack.Count == 0)
                            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.CustomerSplit, ViewFrame.FullScreenTabs, "");
                        else {
                            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.CustomerSplit, ViewFrame.FullScreenTabs, "");
                            ContainerView.ShowViewEvent = ContainerViewModel.CustomersBackStack.Last();
                        }
                        break;
                    case 1:
                        ContainerView.SetupViews();
                        CurrentTab = Tabs.Dummy1Tab;
                        if (ContainerViewModel.DummyTab1BackStack.Count == 0)
                            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.DummyTab1View, ViewFrame.FullScreenTabs, "");
                        else
                            ContainerView.ShowViewEvent = ContainerViewModel.DummyTab1BackStack.Last();
                        break;
                    case 2:
                        ContainerView.SetupViews();
                        CurrentTab = Tabs.Dummy2Tab;
                        if (ContainerViewModel.DummyTab2BackStack.Count == 0)
                            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.DummyTab2View, ViewFrame.FullScreenTabs, "");
                        else
                            ContainerView.ShowViewEvent = ContainerViewModel.DummyTab2BackStack.Last();
                        break;
                    case 3:
                        ContainerView.SetupViews();
                        CurrentTab = Tabs.Dummy3Tab;
                        if (ContainerViewModel.DummyTab3BackStack.Count == 0)
                            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.DummyTab3View, ViewFrame.FullScreenTabs, "");
                        else
                            ContainerView.ShowViewEvent = ContainerViewModel.DummyTab3BackStack.Last();
                        break;
                }
            };

            //Set initial tab
            ContainerView.ShowViewEvent = new ShowViewEvent(ViewType.CustomerSplit, ViewFrame.FullScreenTabs, "");

            base.OnViewCreated(view, savedInstanceState);
        }
    }
}
