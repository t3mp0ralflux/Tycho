using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        // Handles instantiation of classes.
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            // WindowManager is the handling of windows, EventAggregator is the event raiser.
            // Singleton is just one instance of the class for the scope of the entire application.  If ShellViewModel asks for the aggregator, it gets back the first one ever created.
            // If a different viewmodel asks, it gets the same one.  One instance to handle everything.  Kinda like a static class, but not quite.
            // Singleton's are a 'use-as-last-resort' type deal due to memory issues.  Only use it if you really have no other options, which Caliburn kinda forces.
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            // Small performance hit for this reflection, but it's cool as it only happens once on load and then never again.
            // Get all types of current assembly where the type is a class and ends with ViewModel (ShellViewModel for example)
            // Put them in a list and for each of those, add them to the container's registerperrequest.
            // This is to not have to make an interface, but might need to expand to one for unit testing later.
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
