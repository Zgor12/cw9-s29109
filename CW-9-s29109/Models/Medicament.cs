﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_9_s29109.Models;

[Table("Medicament")]
public class Medicament
{
    [Key] 
    public int IdMedicament { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(100)] 
    public string Type { get; set; } = null!;
    
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

}