using CW_9_s29109.Data;
using CW_9_s29109.DTOs;
using CW_9_s29109.Exceptions;
using CW_9_s29109.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9_s29109.Services;

public interface IDbService
{
    public Task<PrescriptionGetDto> CreatePrescriptionAsync(PrescriptionCreateDto dto);
    public Task<PatientGetDetailsDto> GetPatientDetailsByIdAsync(int patientId);


}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<PrescriptionGetDto> CreatePrescriptionAsync(PrescriptionCreateDto dto)
    {

        if (dto.Medicaments.Count > 10)
        {
            throw new Exception($"ERROR:    Too much medicaments on prescription");

        }

        if (dto.DueDate < dto.Date)
        {
            throw new Exception($"ERROR: Duedate cannot be earlier than Date");

        }

        List<Medicament> medicaments = [];

        if (dto.Medicaments is not null && dto.Medicaments.Count != 0)
        {
            foreach (var prmed in dto.Medicaments)
            {
                var med = await data.Medicaments.FirstOrDefaultAsync(m => m.IdMedicament ==prmed.IdMedicament);

                if (med is null)
                {
                    throw new NotFoundException("Medicament does not exist");
                }
                
                medicaments.Add(med);
                
            }
        }

        var patient = await data.Patients.FirstOrDefaultAsync(p => p.IdPatient == dto.Patient.IdPatient);
            
        if (patient is null)
        {
            patient = new Patient
            {
                FirstName = dto.Patient.FirstName,
                LastName = dto.Patient.LastName,
                Birthdate = dto.Patient.Birthdate
            };

            await data.Patients.AddAsync(patient);
            await data.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = dto.Date,
            DueDate = dto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = dto.Doctor.IdDoctor
        };
        
        
        await data.Prescriptions.AddAsync(prescription);
        await data.SaveChangesAsync();

        
        return new PrescriptionGetDto
        {
            IdPrescription = prescription.IdPrescription,
            Date = dto.Date,
            DueDate = dto.DueDate,
            IdPatient = patient.IdPatient,
            Doctor = dto.Doctor,
            
            Medicaments = dto.Medicaments.Select(m => new PrescriptionMedicamentDto
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Description = m.Description
            } ).ToList()
        };

    }

    
    public async Task<PatientGetDetailsDto> GetPatientDetailsByIdAsync(int patientId)
    {
        var result = await data.Patients.Select(p => new PatientGetDetailsDto()
        {

            IdPatient = patientId,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Birthdate = p.Birthdate,
            Prescriptions = p.Prescriptions.Select(pr => new PrescriptionGetDto
            {
                Date = pr.Date,
                DueDate = pr.DueDate,
                Medicaments = (ICollection<PrescriptionMedicamentDto>)pr.PrescriptionMedicaments.Select(med=> new PrescriptionMedicamentDto
                {
                    IdMedicament = med.IdMedicament,
                    Dose = med.Dose,
                    Description = med.Description
                }),
                
                Doctor = pr.Doctor
                
                
            }).ToList()
        }).FirstOrDefaultAsync(e => e.IdPatient == patientId);


        return result ?? throw new NotFoundException("Patient does not exist");
    }
}