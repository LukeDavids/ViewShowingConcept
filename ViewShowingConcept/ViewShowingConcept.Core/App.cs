using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using ViewShowingConcept.Core.Helpers;
using ViewShowingConcept.Core.Services;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //MvxSimpleIoCContainer.Instance.RegisterSingleton(() => new ContainerViewModel());
            //Mvx.RegisterSingleton(new ContainerViewModel());
            RegisterAppStart<ContainerViewModel>();
            
        }
    }
}
