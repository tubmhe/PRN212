using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Room")]
public partial class Room
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public int Price { get; set; }

    [InverseProperty("Room")]
    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
