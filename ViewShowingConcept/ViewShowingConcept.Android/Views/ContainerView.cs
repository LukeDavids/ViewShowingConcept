using Android.App;
using Android.OS;
using Java.Lang;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Droid.Views;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Activity(Label = "View for ContainerView", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ContainerView : MvxCachingFragmentCompatActivity
    {

        private CustomerListFragment _customerListFragment;
        private CustomerDetailFragment _customerDetailFragment;
        private CustomerEditFragment _customerEditFragment;
        private LoginFragment _loginFragment;

        public ContainerViewModel ViewModel
        {
            get { return (ContainerViewModel) ViewModel; }
            set { ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContainerView);

            _customerListFragment = new CustomerListFragment
            {
                ViewModel = ViewModel
            };
            _customerDetailFragment = new CustomerDetailFragment
            {
                ViewModel = ViewModel.CustomerDetailViewModel
            };
            _customerEditFragment = new CustomerEditFragment
            {
                ViewModel = ViewModel.CustomerEditViewModel
            };
            _loginFragment = new LoginFragment
            {
                ViewModel = ViewModel.LoginViewModel
            };

            AddFragments();
            ShowFragment(_loginFragment, null, "customerList");
        }

        public void ShowFragment(MvxFragment fragment, Customer customer, string tag)
        {
            //FlushFragments();
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            FragmentManager.ExecutePendingTransactions();
            HideFragments();

            if (customer != null)
            {
            }

            try
            {
                fragmentTransaction.Replace(Resource.Id.content_frame, fragment, tag);
                fragment.SetMenuVisibility(true);
            }
            catch (Exception e)
            {
                AddFragments();
                fragmentTransaction.Replace(Resource.Id.content_frame, fragment, tag);
                fragment.SetMenuVisibility(true);
            }

            fragmentTransaction.Commit();
        }

        public void AddFragments()
        {
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();

            fragmentTransaction.Add(Resource.Id.content_frame, _customerListFragment, "customerListFragment");

            fragmentTransaction.Commit();
        }

        public void HideFragments()
        {
            _customerListFragment.SetMenuVisibility(false);
            _customerDetailFragment.SetMenuVisibility(false);
            _customerEditFragment.SetMenuVisibility(false);
            _loginFragment.SetMenuVisibility(false);
        }
    }
}
