using Autofac;
using Autofac.Core;
using Common.Logging;
using System.Linq;

namespace TopshelfService.AutofacConfig
{
    public class LogConfig: Module
    {
        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Target.Activator.LimitType;
            e.Parameters = e.Parameters.Union(
            new[]
            {
                  new ResolvedParameter((p, i) => p.ParameterType == typeof(ILog),
                                        (p, i) => LogManager.GetLogger(t)),
            });
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            // Handle constructor parameters.
            registration.Preparing += OnComponentPreparing;
        }
    }
}
