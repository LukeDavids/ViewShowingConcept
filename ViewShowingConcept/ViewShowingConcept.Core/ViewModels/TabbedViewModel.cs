using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class TabbedViewModel : BaseViewModel
    {
        private string _stringParam;

        public DummyTab1ViewModel Tab1 { get; } = Mvx.Resolve<DummyTab1ViewModel>();
        public DummyTab2ViewModel Tab2 { get; } = Mvx.Resolve<DummyTab2ViewModel>();
        public CustomerSplitViewModel Tab3 { get; } = Mvx.Resolve<CustomerSplitViewModel>();
        public DummyTab3ViewModel Tab4 { get; } = Mvx.Resolve<DummyTab3ViewModel>();

        private ITab[] _tabs;
        public ITab[] Tabs
        {
            get { return _tabs; }
            set { _tabs = value; RaisePropertyChanged(() => Tabs); RaisePropertyChanged(() => NumTabs);}
        }

        //Resource paths
        private string[] _tabImages = 
            {
                "glyphicons-social-44-apple","glyphicons-282-bullets","glyphicons-4-user","glyphicons-506-piggy-bank",
            };

        public string[] TabImages 
        {
            get { return _tabImages; }
            set { _tabImages = value; RaisePropertyChanged(() => TabImages); }
        }
        
        public int NumTabs => _tabs.Length;


        public TabbedViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
            _tabs = new ITab[]
            {
                Tab1,Tab2,Tab3,Tab4
            };
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
