using System.ComponentModel.DataAnnotations;
using CW_9_s29109.Models;

namespace CW_9_s29109.DTOs;

public class PatientGetDetailsDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName  { get; set; } = null!;
    public DateTime Birthdate { get; set; }

    public List<PrescriptionGetDto>? Prescriptions { get; set; } = new();
}

public class PrescriptionGetDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public Doctor Doctor { get; set; } 
    
    public int IdPatient { get; set; }
    

    public ICollection<PrescriptionMedicamentDto> Medicaments { get; set; } = null!;
}
