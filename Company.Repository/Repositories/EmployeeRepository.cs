using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
            _context = context;
        }

        public Employee GetEmployeeByName(string name) => _context.Employees.FirstOrDefault(x => x.Name == name);

        public IEnumerable<Employee> GetEmployeesByAddress(string address) => _context.Employees.Where(x => x.Address == address);
    }
}
