using Android;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [MvxFragment(typeof(LoginViewModel), Resource.Id.content_frame, true)]
    [Register("viewshowingconcept.android.views.LoginFragment")]
    public class LoginFragment : BaseView<LoginViewModel>, ISubView
    {
        //private EditText _usernameEditText;
        private string _username;

        public LoginFragment()
        {
            Fragment = this;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SubViewType = SubView.Login;
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.LoginView, null);

        }
        public MvxFragment Fragment { get; set; }
    }
}
