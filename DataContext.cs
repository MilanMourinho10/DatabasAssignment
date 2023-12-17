using DB_Assignment.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    public DbSet<EmployeeEntity> Employee { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<PhoneEntity> Phone { get; set; }
    public DbSet<PhoneCategoryEntity> PhoneCategories { get; set; }
    public DbSet<PricingUnitEntity> PricingUnits { get; set; }
}
