using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class TabbedViewModel : BaseViewModel
    {
        public CustomerSplitViewModel CustomerTabletTab { get; set; }
        public CustomerListViewModel CustomerTab { get; set; }
        public DummyTab1ViewModel DummyTab1 { get; set; }
        public DummyTab2ViewModel DummyTab2 { get; set; }
    }
}
