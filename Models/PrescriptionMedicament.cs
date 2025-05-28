using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CW_9_s29109.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdPrescription),nameof(IdMedicament))]
public class PrescriptionMedicament
{
    public int IdPrescription { get; set; }
    
    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    public string Details { get; set; }

    [ForeignKey(nameof(IdMedicament))]
    public virtual Medicament Medicament { get; set; } = null!;
    
    [ForeignKey(nameof(IdPrescription))]
    public virtual Prescription Prescription { get; set; } = null!;
}
