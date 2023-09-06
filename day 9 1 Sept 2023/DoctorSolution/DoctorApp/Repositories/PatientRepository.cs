using DoctorApp.Contexts;
using DoctorApp.Interfaces;
using DoctorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Repositories
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly DoctorAppContexts _context;
        static List<Patient> patients = new List<Patient>();
        public PatientRepository(DoctorAppContexts contexts)
        {
            _context = contexts;
        }


        public Patient Add(Patient entity)
        {
            _context.patients.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public Patient Delete(int id)
        {
            var patient = Get(id);
            if (patient != null)
            {
                _context.patients.Remove(patient);
                _context.SaveChanges();
                return patient;
            }
            return patient;
        }

        public Patient Get(int id)
        {
            var employee = _context.patients.FirstOrDefault(e => e.PatientId == id);
            return employee;
        }

        public ICollection<Patient> GetAll()
        {
            return _context.patients.ToList();
        }

        public Patient Update(Patient entity)
        {
            _context.Entry<Patient>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
     
        public Patient GetById(int id)
        {
            Patient doct = patients.FirstOrDefault(predicate: p => p.PatientId == id);
            if (doct == null)
                throw new InvalidOperationException("No Patient with id " + id);
            return doct;
        }
        public Patient UpdatePatient(Patient patient )
        {
            Patient pat=GetById(patient.PatientId);
            pat.PatientName = patient.PatientName;
            pat.PatientPhone = patient.PatientPhone;
            pat.PatientEmail = patient.PatientEmail;
            
            return pat;
        }
    }
}
