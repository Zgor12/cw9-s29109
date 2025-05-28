using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CW_9_s29109.DTOs;

namespace CW_9_s29109.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }


    [ForeignKey(nameof(IdPatient))] public virtual Patient Patient { get; set; } = null!;

    [ForeignKey(nameof(IdDoctor))] public virtual Doctor Doctor { get; set; } = null!;
    
    
    public virtual List<PrescriptionMedicamentDto> PrescriptionMedicaments { get; set; }
}