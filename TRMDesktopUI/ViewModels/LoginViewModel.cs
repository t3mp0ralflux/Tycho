using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.Helpers;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private IAPIHelper _apiHelper;
        private string _errorMessage;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

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

        public bool IsErrorVisible
        {
            get
            {
                var output = ErrorMessage?.Length > 0;
                return output;
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                // Always have the notify as the last.  Update first, then notify.
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public async Task LogIn()
        {
            try
            {
                // Continues if success
                ErrorMessage = string.Empty;
                var result = await _apiHelper.Authenticate(UserName, Password);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}