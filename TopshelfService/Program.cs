using Autofac;
using Common.Logging;
using Quartz;
using Quartz.Spi;
using System;
using Topshelf;
using Topshelf.Autofac;
using Topshelf.Quartz;
using TopshelfService.AutofacConfig;
using TopshelfService.Jobs;
using TopshelfService.Properties;

namespace TopshelfService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configurator =>
            {
                configurator.UseLog4Net();

                configurator.SetDescription("Service for creating users every midnight");
                configurator.SetDisplayName("User Creation service");
                configurator.SetServiceName("User Creation service");
                configurator.StartAutomatically();
                configurator.RunAsLocalSystem();

                ILog log = LogManager.GetLogger(typeof(Program));
                try
                {
                    IContainer container = Config.Configure();
                    configurator.UseAutofacContainer(container);
                    configurator.UsingQuartzJobFactory(() => container.Resolve<IJobFactory>());

                    configurator.Service<JobsService>(serviceConfigurator =>
                    {
                        serviceConfigurator.ConstructUsing(name => new JobsService(log));
                        serviceConfigurator.WhenStarted((service, hostControl) => service.Start());
                        serviceConfigurator.WhenStopped((service, hostControl) => service.Stop());

                        serviceConfigurator.ScheduleQuartzJob(jobConfigurator =>
                            jobConfigurator.WithJob(() => JobBuilder.Create<UserCreationJob>().Build())
                                .AddTrigger(() => TriggerBuilder.Create()
                                    .WithCronSchedule(Settings.Default.MidnightCronExpression)
                                    .Build()));
                    });
                }
                catch (Exception ex)
                {
                    log.Fatal(m => m(ex.Message + Environment.NewLine +  ex.InnerException.Message));
                }

            });

        } 
    }
}
