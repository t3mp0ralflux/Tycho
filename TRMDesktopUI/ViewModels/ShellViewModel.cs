using Caliburn.Micro;
using TRMDesktopUI.EventModels;
using System;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>        // Add more subscribers here and then add their handles below if needed
    // Conductor can only open one item at a time.
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;

            // Have to subscribe to have it listen.
            _events.Subscribe(this);

            // If you pass it in here fresh every time, then a new model is passed each time and accidental storage isn't kept.
            // Don't use it for sales and event as it will wipe carts out / lose events
            // .
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);

            // Gets new instance of the login VM and is clean and doesn't keep sensitive info.
            // Essentially, once you're logged in, no need to keep tokens and data.
            // Since the container already has the constructor for this, call that and use it.
            // _loginVM = _container.GetInstance<LoginViewModel>();
        }
    }
}