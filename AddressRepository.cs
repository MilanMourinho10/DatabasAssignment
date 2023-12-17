using DB_Assignment.Contexts;
using DB_Assignment.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
