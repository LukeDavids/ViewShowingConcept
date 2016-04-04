using System.Threading.Tasks;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public CustomerViewModel() {
            StringPassedAsParameter = "nothing yet!";
        }
        private string _customerName;
        public string CustomerName {
            get { return _customerName; }
            set {
                _customerName = value;
                RaisePropertyChanged(() => CustomerName);
            }
        }

        private string _stringParam;
        public string StringPassedAsParameter {
            get { return _stringParam; }
            set {
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
