using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Core.Models
{
    public class ShowViewEvent
    {
        public ShowViewEvent(ViewType viewType, ViewFrame viewFrame, string parameter, object[] args)
        {
            ViewType = viewType;
            ViewFrame = viewFrame;
            Parameter = parameter;
            Args = args;
        }

        public ShowViewEvent(ViewType viewType, ViewFrame viewFrame, string parameter)
        {
            ViewType = viewType;
            ViewFrame = viewFrame;
            Parameter = parameter;
            Args = new object[0];
        }

        public ViewType ViewType { get; set; }
        public ViewFrame ViewFrame { get; set; }
        public string Parameter { get; set; }
        public object[] Args { get;  set; }


    }
}