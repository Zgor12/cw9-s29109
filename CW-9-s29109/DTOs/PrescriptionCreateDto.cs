using CW_9_s29109.Models;

namespace CW_9_s29109.DTOs;

public class PrescriptionCreateDto
{
    public PatientDto Patient { get; set; } = null!;
    
    public Doctor Doctor { get; set; } = null!;
    
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public ICollection<PrescriptionMedicamentDto> Medicaments { get; set; }
    
}

public class PatientDto
{
    public int IdPatient { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime Birthdate { get; set; }
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } = null!;
}

public class PrescriptionMedicamentDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; } = null!;
}