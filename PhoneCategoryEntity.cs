using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DB_Assignment.Entitites;

public class PhoneCategoryEntity
{
    [Key]
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;
}
