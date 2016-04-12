using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class DummyTab2ViewModel : BaseViewModel, ITab
    {
        public IMvxViewModel Page => this;
        private string _name = "Breaks";
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
        public DummyTab2ViewModel() {
            //StringPassedAsParameter = "nothing yet!";
            //ContainerViewModel.ShowViewEvent = new ShowViewEvent(ViewType.CustomerList, ViewFrame.HalfScreenTop, "");
        }
        public void AlertViewModel()
        {
            ShowView(ViewType.DummyTab2View, ViewFrame.FullScreenTabs);
        }

        private string _stringParam;
        public string StringPassedAsParameter {
            get { return _stringParam; }
            set {
                _stringParam = value;
                RaisePropertyChanged(() => StringPassedAsParameter);
            }
        }
        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                RaisePropertyChanged(() => Number);
            }
        }
        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }
    }
}
