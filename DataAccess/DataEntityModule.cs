using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace DataAccess
{
    public class DataEntityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DummyEntity1>().AsImplementedInterfaces();
            builder.RegisterType<DummyEntity2>().AsImplementedInterfaces();
            base.Load(builder);

        }
    }
}
