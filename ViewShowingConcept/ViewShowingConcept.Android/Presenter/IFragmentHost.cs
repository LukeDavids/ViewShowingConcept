using MvvmCross.Core.ViewModels;

namespace ViewShowingConcept.Android
{
    public interface IFragmentHost
    {
        bool Show(MvxViewModelRequest request);
    }
}
