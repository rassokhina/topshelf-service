using Autofac;
using Autofac.Extras.Quartz;
using ServiceCore.Configuration;

namespace TopshelfService.AutofacConfig
{
    internal class Config
    {
        public static IContainer Configure()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<LogConfig>();
            containerBuilder.RegisterModule<UserConfiguration>();
            containerBuilder.RegisterModule<QuartzAutofacFactoryModule>();
            containerBuilder.RegisterModule(new QuartzAutofacJobsModule(typeof(Config).Assembly));
            return containerBuilder.Build();
        }
    }
}
