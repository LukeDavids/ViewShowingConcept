using Android;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Android.Views
{
    [Register("ViewShowingConcept.android.views.LoginFragment")]
    public class LoginFragment : BaseView
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SubViewType = SubView.Login;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.LoginView, null);
        }
    }
}
