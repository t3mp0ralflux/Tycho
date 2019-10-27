using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;

        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
                // Have to notify the other property
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
                // Have to notify the other property
            }
        }

        public bool CanLogIn
        {
            // It's a property!
            get
            {
                // They are null on startup, have to double check em
                var output = UserName?.Length > 0 && Password?.Length > 0;

                return output;
            }
        }

        public void LogIn()
        {
            // Just read the properties here
        }
    }
}