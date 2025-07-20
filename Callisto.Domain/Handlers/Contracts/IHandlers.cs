using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers.Contracts
{
    public interface IHandlers<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
