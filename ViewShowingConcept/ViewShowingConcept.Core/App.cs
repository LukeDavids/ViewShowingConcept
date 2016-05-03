using MvvmCross.Platform.IoC;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public static bool Tablet { get; set; }

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<ContainerViewModel>();
        }
    }
}
