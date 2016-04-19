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
        public DummyTab3ViewModel Tab3 { get; } = Mvx.Resolve<DummyTab3ViewModel>();

        private ITab[] _tabs;
        public ITab[] Tabs
        {
            get { return _tabs; }
            set { _tabs = value; RaisePropertyChanged(() => Tabs); RaisePropertyChanged(() => NumTabs);}
        }
        
        public int NumTabs => _tabs.Length;

		private static TabbedViewModel _instance = null;
		public static TabbedViewModel Instance
		{
			get{ return getInstance (); }
		}

        public TabbedViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
            _tabs = new ITab[]
            {
                Tab1,Tab2,Tab3,
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
			
		private static TabbedViewModel getInstance()
		{
			if (_instance == null)
				_instance = new TabbedViewModel ();

			return _instance;
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
