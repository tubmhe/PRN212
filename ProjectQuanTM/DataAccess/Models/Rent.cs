using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Rent")]
public partial class Rent
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int RoomId { get; set; }

    [StringLength(50)]
    public string CustomerId { get; set; } = null!;

    public double Deposits { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Rents")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("RoomId")]
    [InverseProperty("Rents")]
    public virtual Room Room { get; set; } = null!;

    [InverseProperty("Rent")]
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
