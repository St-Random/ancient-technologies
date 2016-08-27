using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.UI.Configuration {
    class IoCConfig : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterModule<Core.Configuration.IoCConfig>();

            builder.RegisterType<Game>()
                   .AsSelf()
                   .InstancePerLifetimeScope();
        }
    }
}
