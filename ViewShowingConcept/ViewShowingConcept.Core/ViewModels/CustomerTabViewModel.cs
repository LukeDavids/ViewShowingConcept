using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Droid.Support.V4;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerTabViewModel : BaseViewModel
    {
        public CustomerTabViewModel() 
        {
            StringPassedAsParameter = "Nothing yet!";
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
    }
}
