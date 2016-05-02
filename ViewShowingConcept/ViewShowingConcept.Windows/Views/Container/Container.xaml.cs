using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MvvmCross.WindowsUWP.Views;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;
using ViewShowingConcept.Windows.Interfaces;


namespace ViewShowingConcept.Windows.Views.Container
{
    public sealed partial class ContainerView : MvxWindowsPage
    {

        public Dictionary<ViewType, IWindowsView> Views { get; } = new Dictionary<ViewType, IWindowsView>();

        private ShowViewEvent _showViewEvent;
        public ShowViewEvent ShowViewEvent
        {
            get { return _showViewEvent; }
            set
            {
                _showViewEvent = value;
            }
        }

        public ContainerView()
        {
            this.InitializeComponent();
        }

    }
}
