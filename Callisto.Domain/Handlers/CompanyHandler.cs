using Callisto.Domain.Commands.Company;
using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Commands.User_Commands.Output;
using Callisto.Domain.Entities;
using Callisto.Domain.Handlers.Contracts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers
{
    public class CompanyHandler : IHandlers<GetCompanyCommand>, IHandlers<CreateComapnyCommand>, IHandlers<UpdateCompanyCommand>, IHandlers<DeleteCompanyCommand>
    {
        ICompanyRepository _Repository;
        public CompanyHandler(ICompanyRepository repository)
        {
            _Repository = repository;
        }
        public Dictionary<string, string> Notifications { get; set; }
        public ICommandResult Handler(GetCompanyCommand command)
        {
            var companies = _Repository.GetAllCompanies();
            return new CommandResult<List<Company>>("Sucesso", companies);
        }

        public ICommandResult Handler(CreateComapnyCommand command)
        {
            if (!command.Validate())
                Notifications.Add("Command Validation", "Something is Wrong");

            var company = new Company(command.Name, command.Cnpj, command.Email, command.Phone, command.Address);

            _Repository.Save(company);
            return new CommandResult<Company>("Sucesso", company);
        }

        public ICommandResult Handler(UpdateCompanyCommand command)
        {
            if (!command.Validate()) //Verificar Validação
                Notifications.Add("Command Validation", "Something is Wrong");

            var company = _Repository.GetCompanyById(command.Id);

            if (!string.IsNullOrWhiteSpace(command.Name))
                company.ChangeName(command.Name);

            if (!string.IsNullOrWhiteSpace(command.Cnpj))
                company.ChangeCnpj(command.Cnpj);

            if (!string.IsNullOrWhiteSpace(command.Email))
                company.ChangeEmail(command.Email);

            if (!string.IsNullOrWhiteSpace(command.Phone))
                company.ChangePhone(command.Phone);

            if (!string.IsNullOrWhiteSpace(command.Address))
                company.ChangeAddress(command.Address);

            _Repository.Update(company);
            _Repository.SaveChanges();

            return new CommandResult<Company>("Campo alterado com sucesso!", company);
        }

        public ICommandResult Handler(DeleteCompanyCommand command)
        {
            if (!command.Validate()) //Verificar Validação
                Notifications.Add("Command Validation", "Something is Wrong");

            _Repository.DeleteCompanyById(command.Id);
            _Repository.SaveChanges();

            return new CommandResult<int>("Company deletada com sucesso!", command.Id);
        }
    }
}
