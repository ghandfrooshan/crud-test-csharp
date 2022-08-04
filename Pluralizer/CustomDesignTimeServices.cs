using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Pluralizer
{
    internal class CustomDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddSingleton<IPluralizer, CustomPluralizer>();
        }
    }
}
