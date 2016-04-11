using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
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

            Mvx.RegisterSingleton(new ContainerViewModel());
            RegisterAppStart<ContainerViewModel>();
        }
    }
}
