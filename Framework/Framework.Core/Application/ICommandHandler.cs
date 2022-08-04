using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Application
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}
