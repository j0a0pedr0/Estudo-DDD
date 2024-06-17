using Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class CommandResult : ICommandResult
    {

        public CommandResult()
        {

        }

        public CommandResult(bool success, string message)
        {
            Sucess = success;
            Message = message;
        }


        public bool Sucess { get; set; }

        public string Message { get; set; }
    }
}
