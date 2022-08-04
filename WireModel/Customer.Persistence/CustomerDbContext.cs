using Framework.AssemblyHelper;
using Framework.Domain;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Persistence
{
    public class CustomerDbContext : DbContextBase
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityMapping = DetectEntityMapping();

            entityMapping.ForEach(a => { modelBuilder.ApplyConfiguration(a); });

      

         

            var aggregateRoots = DetectEntityBase();
            aggregateRoots.ForEach(a => modelBuilder.HasSequence<long>(a, "Shared").StartsAt(1).IncrementsBy(1));
        }


        protected List<dynamic> DetectEntityMapping()
        {
            var assemblyHelper = new AssemblyHelper("CustomerContext.");
            return assemblyHelper.GetTypes(typeof(EntityMappingBase<>))
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();
        }


     


        protected List<string> DetectEntityBase()
        {
            var assemblyHelper = new AssemblyHelper("CustomerContext.");
            return assemblyHelper.GetTypes(typeof(EntityBase<>))
                .Where(a => a.BaseType != null)
                .Select(a => a.Name)
                .ToList();
        }
    
}
}
