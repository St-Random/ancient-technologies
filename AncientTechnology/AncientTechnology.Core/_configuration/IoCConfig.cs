﻿using AncientTechnology.Core.Control.Managers;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Configuration {
    public class IoCConfig : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterAssemblyTypes()
                   .Where(t => t.Namespace.Contains("Core.Entities")
                               && t.IsClass && !t.IsAbstract && !t.IsInterface)
                   .AsSelf()
                   .InstancePerDependency();

            builder.RegisterAssemblyTypes()
                   .Where(t => t.Name.EndsWith("Controller")
                               && t.IsClass && !t.IsAbstract && !t.IsInterface)
                   .AsSelf()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();


            builder.RegisterType<MainManager>()
                   .AsSelf()
                   .InstancePerLifetimeScope();


        }
    }
}
