using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Core.Models
{
    public class ViewDidShowEvent
    {
        public ViewType ViewType { get; set; }
        public ViewFrame ViewFrame { get; set; }
        public string Parameter { get; set; }
        public object[] Args { get; set; }

        public ViewDidShowEvent(ViewType viewType, ViewFrame viewFrame, string parameter, object[] args)
        {
            ViewType = viewType;
            ViewFrame = viewFrame;
            Parameter = parameter;
            Args = args;
        }

        public ViewDidShowEvent(ViewType viewType, ViewFrame viewFrame, string parameter)
        {
            ViewType = viewType;
            ViewFrame = viewFrame;
            Parameter = parameter;
            Args = new object[0];
        }

        public ViewDidShowEvent(ShowViewEvent showViewEvent)
        { 
            ViewType = showViewEvent.ViewType;
            ViewFrame = showViewEvent.ViewFrame;
            Parameter = showViewEvent.Parameter;
            Args = showViewEvent.Args;
        }
    }
    
}
