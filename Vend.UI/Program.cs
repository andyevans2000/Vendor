using Autofac;
using Logger;
using System;
using System.Windows.Forms;

namespace Vend.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //create the container and then use it to resolve the main form for the app - DI will flow automatically from this point
            var container = CreateDiContainer();
            log4net.Config.XmlConfigurator.Configure();
            Application.Run(container.Resolve<Form1>());
        }

        /// <summary>
        /// create the Autofac container
        /// </summary>
        /// <returns></returns>
        private static IContainer CreateDiContainer()
        {
            //associate interface with concrete types
            var builder = new ContainerBuilder();
            builder.RegisterModule<LoggingModule>(); //log4net module
            builder.RegisterType<CoinService>().As<ICoinService>();
            builder.RegisterType<HardcodedCoinProvider>().As<ICoinProvider>();
            builder.RegisterType<HardcodedProductProvider>().As<IProductProvider>();
            builder.RegisterType<VendingMachine>().As<IVendingMachine>().SingleInstance();
            builder.RegisterType<Form1>().As<Form1>();
            return builder.Build();
        }
    }
}
