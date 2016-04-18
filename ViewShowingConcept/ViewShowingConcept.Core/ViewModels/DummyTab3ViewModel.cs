using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class DummyTab3ViewModel : BaseViewModel, ITab
    {
        public IMvxViewModel Page => this;

		private static DummyTab3ViewModel _instance = null;
		public static DummyTab3ViewModel Instance
		{
			get{ return getInstance();}

		}

        private string _name = "Piggy";
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

        public DummyTab3ViewModel() {
            //StringPassedAsParameter = "nothing yet!";
        }
			
		public static DummyTab3ViewModel getInstance()
		{
			if (_instance == null)
				_instance = new DummyTab3ViewModel ();

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

        public void AlertViewModel()
        {
            ShowView(ViewType.DummyTab3View, ViewFrame.FullScreenTabs);
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
