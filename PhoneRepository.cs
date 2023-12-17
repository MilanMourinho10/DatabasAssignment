using DB_Assignment.Contexts;
using DB_Assignment.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Repositories;

internal class PhoneRepository : Repo<PhoneEntity>
{
   private readonly DataContext _context;
    public PhoneRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<PhoneEntity>> GetAllAsync()
    {
        return await  _context.Phone
        .Include(x => x.PricingUnit)
        .Include(x => x.PhoneCategory)
        .ToListAsync();
    }
}
