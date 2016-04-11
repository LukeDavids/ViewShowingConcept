using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core.ViewModels
{
    public class TabbedViewModel : BaseViewModel
    {
        public TabbedViewModel() 
        {
            StringPassedAsParameter = "Nothing yet!";
        }
        public CustomerSplitViewModel CustomerTabletTab { get; set; }
        public CustomerListViewModel CustomerTab { get; set; }
        public DummyTab1ViewModel DummyTab1 { get; set; }
        public DummyTab2ViewModel DummyTab2 { get; set; }
        

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
    }
}
