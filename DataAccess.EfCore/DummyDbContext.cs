using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.EfCore
{
    public class DummyDbContext : DbContext, IDataContext
    {
        private readonly IComponentContext _iocContext;
        private readonly IConfigurationRoot _configuration;

        public DummyDbContext()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<DataEntityModule>();
            containerBuilder.RegisterModule<DataAccessEfCoreModule>();

            _iocContext = containerBuilder.Build();
        }

        public DummyDbContext(IComponentContext iocContext, IConfigurationRoot configuration):base()
        {
            _iocContext = iocContext;
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr =_configuration.GetConnectionString("connstr");
            optionsBuilder.UseSqlServer(connstr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //var entityMethod = modelBuilder.GetType().GetMethod("Entity");

            var entityTypes = _iocContext.Resolve<IEnumerable<IEntity<int>>>();

            foreach (var entityType in entityTypes)
            {
                var type = entityType.GetType();
                modelBuilder.Entity(type);

                //entityMethod.MakeGenericMethod(type)
                //    .Invoke(modelBuilder, new object[] { });
            }
            base.OnModelCreating(modelBuilder);
        }

        public IList<DummyEntity1> GetAllDummyEntity1s()
        {
            return Set<DummyEntity1>().ToList();
        }

        public IList<DummyEntity2> GetAllDummyEntity2s()
        {
            return Set<DummyEntity2>().ToList();
        }
    }
}
