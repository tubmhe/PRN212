using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    [Column("ID")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
