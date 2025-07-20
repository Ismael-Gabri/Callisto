using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.User_Commands.Output
{
    public class CommandResult<T> : ICommandResult
    {
        public CommandResult(string message, T data)
        {
            Message = message;
            Data = data;
        }

        public string Message { get; set; }
        public T Data { get; set; }
    }
}
