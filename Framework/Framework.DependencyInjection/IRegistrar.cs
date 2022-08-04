using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DependencyInjection
{
    public interface IRegistrar
    {
        void Register(IServiceCollection services, string connectionString);
    }
}
