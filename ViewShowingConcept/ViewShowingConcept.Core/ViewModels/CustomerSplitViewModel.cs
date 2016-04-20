using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerSplitViewModel : BaseViewModel, ITab, IMasterDetail
    {
        public CustomerSplitViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
            
        }

        private string _stringParam;
        public string StringPassedAsParameter
        {
            get { return _stringParam; }
            set
            {
                _stringParam = value;
                RaisePropertyChanged(() => StringPassedAsParameter);
            }
        }

        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }

        public IMvxViewModel Page => this;
        private string _name = "Customers";
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }
        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; RaisePropertyChanged(() => Image); }
        }

        public IMvxViewModel Master { get; set; } = Mvx.Resolve<CustomerListViewModel>();

        public IMvxViewModel Detail { get; set; } = Mvx.Resolve<CustomerViewModel>();

        public void AlertViewModel()
        {
            ShowView(ViewType.CustomerSplit, ViewFrame.FullScreenTabs);
        }
    }
}
