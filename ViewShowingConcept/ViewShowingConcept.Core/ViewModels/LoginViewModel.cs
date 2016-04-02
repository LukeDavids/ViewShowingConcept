using System.Diagnostics;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class LoginViewModel
        : BaseViewModel
    {
        public LoginViewModel() {
            Debug.WriteLine(" -----------------------------------login view model ");
            Username = "user";
            Password = "password";
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public ICommand ShowLoginViewCommand
        {
            get
            {
                return new MvxCommand(ShowLoginView);
            }
        }

        public void ShowLoginView()
        {
            Debug.WriteLine("======================================== show login command");
            if (Username.Equals("user") && Password.Equals("password"))
            {
                ShowSubView(SubViewType.CustomerList);
            }
        }

        public bool IsMenuVisible { get; set; }
        public MvxFragment Fragment { get; set; }
    }
}
