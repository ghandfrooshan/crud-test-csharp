using Framework.Core.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Framework.Facade
{
    public abstract class FacadeCommandBase: Controller
    {
        protected FacadeCommandBase(ICommandBus commandBus)
        {
            CommandBus = commandBus;
            
        }


        protected ICommandBus CommandBus { get; private set; }
       
    }
}
