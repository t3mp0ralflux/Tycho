using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginVM;

        public ShellViewModel(LoginViewModel loginVm)
        {
            _loginVM = loginVm;
            ActivateItem(_loginVM);
        }
    }
}