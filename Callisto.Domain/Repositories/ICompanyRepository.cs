using Callisto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Repositories
{
    public interface ICompanyRepository
    {
        void Save(Company company);
        void Update(Company company);
        List<Company> GetAllCompanies();
        Company GetCompanyById(int companyId);
        void DeleteCompanyById(int companyId);
        void SaveChanges();
    }
}
