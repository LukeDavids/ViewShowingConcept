using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class LoginViewModel
        : BaseViewModel
    {
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
            if (Username.Equals("user") && Password.Equals("password"))
            {
                ShowSubView(SubView.CustomerList);
            }
        }
    }
}