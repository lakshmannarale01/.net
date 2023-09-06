using HospitalClinicApp.Models;
using HospitalClinicApp.contexts;
using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Utilities;
using Microsoft.EntityFrameworkCore;

namespace HospitalClinicApp.Repositories
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly ClinicContexts _context;

        public PatientRepository(ClinicContexts context)
        {
            _context = context; 
        }
        public Patient Add(Patient entity)
        {
            _context.patients.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Patient Delete(int key)
        {
            var patient = GetById(key);
            if (patient != null)
            {
                _context.patients.Remove(patient);
                _context.SaveChanges();
                return patient;
            }
            throw new NoEntriesAvailable("Patient");
        }

        public ICollection<Patient> GetAll()
        {
            var patients = _context.patients;
            if (patients.Count() == 0)
                throw new NoSuchEntityException("Patient");
            return patients.ToList();
        }

        public Patient GetById(int key)
        {
            var patient = _context.patients.SingleOrDefault(app => app.Id == key);
            if (patient != null)
                return patient;
            throw new NoSuchEntityException("patient");
        }

        public Patient Update(Patient entity)
        {
            var patient = GetById(entity.Id);
            if (patient != null)
            {
                _context.Entry<Patient>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new NoSuchEntityException("Patient");
        }
    }
}
