using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Helpers;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;
using static ViewShowingConcept.Core.Enums.ViewFrame;
using static ViewShowingConcept.Core.Enums.ViewType;

namespace ViewShowingConcept.Core.ViewModels.Container
{
    public class ContainerViewModel :MvxViewModel
    {

        public ContainerViewModel() 
        {
            RegisterViewModels();
            Test = " Test texct";
            //ShowViewEvent = new ShowViewEvent(CustomerView, FullScreen, "001");
            ContainerViewModelHelper.ContainerViewModel = this;
        }


        public Dictionary<ViewType, BaseViewModel> ViewModels { get; set; }

        private ShowViewEvent _showViewEvent;
        private string _test;

        public ShowViewEvent ShowViewEvent {
            get { return _showViewEvent; }
            set { _showViewEvent = value; RaisePropertyChanged(() => ShowViewEvent); }
        }
        public string Test
        {
            get
            {
                return _test;

            }
            set
            {
                _test = value;
                RaisePropertyChanged(() => Test);
            }
        }
        private void RegisterViewModels()
        {
            Mvx.LazyConstructAndRegisterSingleton(() => new BaseViewModel ());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerDetailViewModel ());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerEditViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerListViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerSplitViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new TabbedViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new DummyTab1ViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new DummyTab2ViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerTabViewModel());


            ViewModels = new Dictionary<ViewType, BaseViewModel>
            {
                {CustomerDetails,  Mvx.Resolve<CustomerDetailViewModel>()},
                {CustomerEdit,     Mvx.Resolve<CustomerEditViewModel>()},
                {CustomerList,     Mvx.Resolve<CustomerListViewModel>()},
                {CustomerView,     Mvx.Resolve<CustomerViewModel>()},
                {CustomerSplit,    Mvx.Resolve<CustomerSplitViewModel>()},
                {TabbedView,       Mvx.Resolve<TabbedViewModel>()},
                {DummyTab1View,    Mvx.Resolve<DummyTab1ViewModel>()},
                {DummyTab2View,    Mvx.Resolve<DummyTab2ViewModel>()},
                {CustomerTab,      Mvx.Resolve<CustomerTabViewModel>()}
            };
        }
    }
}
