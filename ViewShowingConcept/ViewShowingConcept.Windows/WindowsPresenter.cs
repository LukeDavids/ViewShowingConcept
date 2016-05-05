using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using MvvmCross.WindowsUWP.Views;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Windows.Interfaces;
using ViewShowingConcept.Windows.Views;

namespace ViewShowingConcept.Windows
{
    public class WindowsPresenter : MvxWindowsViewPresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;
        private Dictionary<MvxViewModelRequest, IWindowsView> _views = new Dictionary<MvxViewModelRequest, IWindowsView>(); 

        public WindowsPresenter(IMvxWindowsFrame rootFrame)
            : base(rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            base.ChangePresentation(hint);
        }

        public override void Show(MvxViewModelRequest request)
        {
            
            try
            {
                var view = CreateView(request);

                var converter = Mvx.Resolve<IMvxNavigationSerializer>();
                var requestText = converter.Serializer.SerializeObject(request);

                this._rootFrame.Navigate(view.GetType(), requestText); //Frame won't allow serialization of it's nav-state if it gets a non-simple type as a nav param
            }
            catch (Exception exception)
            {
                MvxTrace.Error("Error seen during navigation request to {0} - error {1}", request.ViewModelType.Name,
                               exception.ToLongString());
            }
        }

        private static IMvxWindowsView CreateView(MvxViewModelRequest request)
        {
            var container = Mvx.Resolve<IMvxViewsContainer>();
            var viewType = container.GetViewType(request.ViewModelType);
            if (viewType == null)
            {
                MvxTrace.Error("View Type not found for " + request.ViewModelType);
                return null;
            }
                
            var viewObject = Activator.CreateInstance(viewType);
            if (viewObject == null)
            {
                MvxTrace.Error("View not loaded for " + viewType);
                return null;
            }

            var view = viewObject as IMvxWindowsView;
            if (view == null)
            {
                MvxTrace.Error("Loaded View is not a IMvxWindowsView " + viewType);
                return null;
            }
            view.ViewModel = LoadViewModel(request);

            return view;
        }
        private static IMvxViewModel LoadViewModel(MvxViewModelRequest request)
        {
            // Load the viewModel
            var viewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();

            return viewModelLoader.LoadViewModel(request, null);
        }
    }
}
