using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Service")]
public partial class Service
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int RentId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int OldNumber { get; set; }

    public int NewNumber { get; set; }

    public int Price { get; set; }

    public bool Status { get; set; }

    [ForeignKey("RentId")]
    [InverseProperty("Services")]
    public virtual Rent Rent { get; set; } = null!;
}
