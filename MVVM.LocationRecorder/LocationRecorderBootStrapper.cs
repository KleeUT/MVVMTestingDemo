﻿namespace MVVM.LocationRecorder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Reflection;
    using System.Windows;

    using Caliburn.Micro;

    using MVVM.LocationRecorder.Service;

    public class LocationRecorderBootStrapper : BootstrapperBase
    {
        private CompositionContainer container;

        public LocationRecorderBootStrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new CompositionContainer(new AssemblyCatalog(Assembly.GetAssembly(typeof(ShellViewModel))));

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            
            batch.AddExportedValue(container);
            container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            IoC.Get<InteractionCommandHandler>();
            DisplayRootViewFor<ShellViewModel>();
        }
    }

}
