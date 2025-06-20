﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_9_s29109.Models;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string LastName  { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string Email  { get; set; } = null!;
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}