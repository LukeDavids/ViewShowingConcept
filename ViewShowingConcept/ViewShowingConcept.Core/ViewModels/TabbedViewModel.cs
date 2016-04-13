using System.Threading.Tasks;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class TabbedViewModel : BaseViewModel
    {
        private string _stringParam;

        public DummyTab1ViewModel DummyTab1 { get; } = Mvx.Resolve<DummyTab1ViewModel>();
        public DummyTab2ViewModel DummyTab2 { get; } = Mvx.Resolve<DummyTab2ViewModel>();
        public DummyTab3ViewModel DummyTab3 { get; } = Mvx.Resolve<DummyTab3ViewModel>();

        public TabbedViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
        }

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

        //Used to Init new ViewModel
        public void ShowViewModel()
        {
            ShowViewModel<TabbedViewModel>(new {});
        }
    }
}
