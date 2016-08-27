using Autofac;
using System;

namespace AncientTechnology.UI {
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program {
        public static IContainer Container { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Configuration.IoCConfig>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope()) {
                var game = Container.Resolve<Game>();
                game.Run();
            }

        }
    }
#endif
}
