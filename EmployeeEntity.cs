using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Entitites;

internal class EmployeeEntity
{
    
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
}
