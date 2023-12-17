using DB_Assignment.Contexts;
using DB_Assignment.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Repositories
{
    internal class EmployeeRepository : Repo<EmployeeEntity>
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
           return await _context.Employee.Include(x => x.Address).ToListAsync();
        }
    }
}
