using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Contexts;

internal class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\MilanDataBasTeknikUppgift\DB_Assignment\DB_Assignment\DB_Assignment\Contexts\assignment_db.mdf;Integrated Security=True;Connect Timeout=30");
             return new DataContext(optionsBuilder.Options);
    }
}
