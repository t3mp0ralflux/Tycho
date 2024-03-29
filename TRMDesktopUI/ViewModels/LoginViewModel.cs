﻿using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Helpers;
using TRMDesktopUI.Library.API;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private IAPIHelper _apiHelper;
        private string _errorMessage;
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
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
                var output = UserName?.Length > 0 && Password?.Length > 0 && !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);

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

                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                // Broadcast message to everyone listening to the LogOnEvent class.
                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}