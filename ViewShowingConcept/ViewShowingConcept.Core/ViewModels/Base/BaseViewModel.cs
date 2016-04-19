using System.Threading.Tasks;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        private bool _isBusy;
		private static BaseViewModel _baseinstance = null;
        public ContainerViewModel ContainerViewModel => Mvx.Resolve<ContainerViewModel>();

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }
			
		public static BaseViewModel BaseInstance
		{
			get{ 
				return getBaseInstance ();
			}
		}
			
		private static BaseViewModel getBaseInstance()
		{
			if (_baseinstance == null)
				_baseinstance = new BaseViewModel ();

			return _baseinstance;
		}

        public void ShowView(ViewType viewType, ViewFrame viewFrame, string parameter)
        {
            ContainerViewModel.ShowViewEvent = new ShowViewEvent(viewType, viewFrame, parameter);
        }

        public void ShowView(ViewType viewType, ViewFrame viewFrame)
        {
            ShowView(viewType, viewFrame, "none");
        }

        public IMvxCommand InitialiseCommand => new MvxAsyncCommand<ShowViewEvent>(Initialise);

		public virtual async Task Initialise(ShowViewEvent viewEvent)
        {
            if (ContainerViewModel == null || ContainerViewModel.ViewModels == null) return;
			await Task.Run(() => ContainerViewModel.ViewModels[viewEvent.ViewType].InitialiseCommand.Execute(viewEvent));
        }

        public static void ShowViewModel<T>(dynamic parameter) where T : IMvxViewModel
        {
            var viewDispatcher = Mvx.Resolve<IMvxViewDispatcher>();
            var request = MvxViewModelRequest.GetDefaultRequest(typeof (T));
            request.ParameterValues = ((object) parameter).ToSimplePropertyDictionary();
            viewDispatcher.ShowViewModel(request);
        }
    }
}