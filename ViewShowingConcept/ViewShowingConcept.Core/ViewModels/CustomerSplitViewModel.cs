using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerSplitViewModel : BaseViewModel, ITab
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

        public IMvxViewModel Page { get; }
        public string Name { get; set; }
        public string Image { get; set; }

        public void AlertViewModel()
        {
            ShowView(ViewType.CustomerSplit, ViewFrame.FullScreenTabs);
        }
    }
}
