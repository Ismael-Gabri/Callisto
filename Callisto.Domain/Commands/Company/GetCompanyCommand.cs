using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Company
{
    public class GetCompanyCommand : ICommand
    {
        public bool Validate()
        {
            return true;
        }
    }
}
