using Autofac;
using ServiceCore.Context;

namespace ServiceCore.Configuration
{
    public class UserConfiguration: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserContext>()
                .As<IUserContext>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
        }
    }
}
