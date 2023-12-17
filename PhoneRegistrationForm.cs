using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Models;

internal class PhoneRegistrationForm
{
    public string PhoneName { get; set; } = null!;
    public string PhoneDescription { get; set; } = null!;
    public decimal PhonePrice { get; set; }
    public string Unit { get; set; } = null!;
    public string PhoneCategory { get; set; } = null!;
}
