using System.Threading.Tasks;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerSplitViewModel : BaseViewModel
    {
        public CustomerSplitViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
        }

        private string _stringParam;

		private static CustomerSplitViewModel _instance = null;	

		public static CustomerSplitViewModel Instance {
			get{
				return getInstance ();
			}
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
			
		public static CustomerSplitViewModel getInstance()
		{
			if (_instance == null)
				_instance = new CustomerSplitViewModel ();

			return _instance;
		}

        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }
    }
}
