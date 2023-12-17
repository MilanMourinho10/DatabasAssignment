using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DB_Assignment.Entitites;

internal class PhoneEntity
{
    [Key]
    public int Id { get; set; }
    public string PhoneName { get; set; } = null!;
    public string PhoneDescription { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal PhonePrice { get; set; }
    public int PricingUnitId { get; set; }

    public PricingUnitEntity PricingUnit { get; set; } = null!;

    public int PhoneCategoryId { get; set; }
    public PhoneCategoryEntity PhoneCategory { get; set; } = null!;
}
    
    
    
