using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace DataAccess.EfCore
{
    public class DataAccessEfCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
                
                var configuration = configBuilder.Build();

            builder.RegisterInstance(configuration)
                .AsImplementedInterfaces()
                .SingleInstance();


            builder.RegisterType<DummyDbContext>().AsImplementedInterfaces();

            base.Load(builder);

        }
    }
}
