﻿using CW_9_s29109.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9_s29109.Data;

public class AppDbContext : DbContext
{
    
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm=> new {pm.IdMedicament,pm.IdPrescription});

    }
}