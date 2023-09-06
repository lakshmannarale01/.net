using HospitalClinicApp.Models;
using HospitalClinicApp.contexts;
using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Utilities;
using Microsoft.EntityFrameworkCore;

namespace HospitalClinicApp.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContexts _context;

        public DoctorRepository(ClinicContexts context)
        {
            _context = context;
        }
        public Doctor Add(Doctor entity)
        {
            _context.doctors.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Doctor Delete(int key)
        {
            var doctor = GetById(key);
            if (doctor != null)
            {
                _context.doctors.Remove(doctor);
                _context.SaveChanges();
                return doctor;
            }
            throw new NoSuchDoctorException();
        }

        public ICollection<Doctor> GetAll()
        {
            var doctors = _context.doctors;
            if (doctors.Count() == 0)
                throw new NoDoctorsAreAvailable();
            return doctors.ToList();
        }

        public Doctor GetById(int key)
        {
            var doctor = _context.doctors.SingleOrDefault(d => d.Id == key);
            if (doctor != null)
                return doctor;
            throw new NoSuchDoctorException();
        }

        public Doctor Update(Doctor entity)
        {
            var doctor = GetById(entity.Id);
            if (doctor != null)
            {
                _context.Entry<Doctor>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new NoSuchDoctorException();
        }
    }
}
