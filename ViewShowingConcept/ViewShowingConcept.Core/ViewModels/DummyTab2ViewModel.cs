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
			
		private static DummyTab2ViewModel _instance = null;	
		public static DummyTab2ViewModel Instance
		{
			get { return getInstance ();}
		}

        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; RaisePropertyChanged(() => Image); }
        }
        public DummyTab2ViewModel() {
            //StringPassedAsParameter = "nothing yet!";
        }
        public void AlertViewModel()
        {
            ShowView(ViewType.DummyTab2View, ViewFrame.FullScreenTabs);
        }
			
		private static DummyTab2ViewModel getInstance()
		{
			if (_instance == null)
				_instance = new DummyTab2ViewModel ();

			return _instance;
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
