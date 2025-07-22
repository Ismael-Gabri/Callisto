using Callisto.Domain.Entities;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Infra.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CallistoContext _context;
        public CompanyRepository(CallistoContext context)
        {
            _context = context;
        }

        public List<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company GetCompanyById(int companyId)
        {
            return _context.Companies.FirstOrDefault(n => n.Id == companyId);
        }

        public void Save(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }

        public void DeleteCompanyById(int companyId) //Não é possível deletar caso tenham usuários vinculados com a company
        {
            var company = _context.Companies.Find(companyId);

            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
        }
    }
}
