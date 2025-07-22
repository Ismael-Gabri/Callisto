using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Handlers.Contracts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers
{
    public class TicketHandler //: IHandlers<CreateTicketCommand>
    {
        ITicketRepository _repository;
        IUserRepository _userRepository;
        public TicketHandler(ITicketRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        public Dictionary<string, string> Notifications { get; set; }

        public void Handler(CreateTicketCommand command) //ICommandResult
        {
            if (!command.Validate())
                Notifications.Add("Command Validation", "Something is Wrong");

            //Recuperar e validar o User
            var user = _userRepository.GetUserById(command.UserId);

            //Recuperar e validar o team

            //Recuperar e validar o company
        }
    }
}
