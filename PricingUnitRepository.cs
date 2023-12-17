using DB_Assignment.Contexts;
using DB_Assignment.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Repositories;

internal class PricingUnitRepository : Repo<PricingUnitEntity>
{
    public PricingUnitRepository(DataContext context) : base(context)
    {
    }
}
