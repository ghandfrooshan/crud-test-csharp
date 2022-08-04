using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Application
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : Command;
    }
   
}
