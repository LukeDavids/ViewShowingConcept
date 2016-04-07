using System.Threading.Tasks;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerSplitViewModel : BaseViewModel
    {
        public CustomerSplitViewModel() {
            StringPassedAsParameter = "nothing yet!";
            //ContainerViewModel.ShowViewEvent = new ShowViewEvent(ViewType.CustomerList, ViewFrame.HalfScreenTop, "");
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
