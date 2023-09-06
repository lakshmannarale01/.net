using DoctorApp.Contexts;
using DoctorApp.Interfaces;
using DoctorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Repositories
{
    public class DoctorsRepository : IRepository<int, Doctor>
    {
        private readonly DoctorAppContexts _context;
        static List<Doctor> doctors = new List<Doctor>();

        public DoctorsRepository(DoctorAppContexts contexts)
        {
            _context  = contexts;
        }
        public Doctor Add(Doctor entity)
        {
            if (entity == null)
                throw new ArgumentNullException("No Doctor Available");
            entity.DoctorId = GenerateIndex();
            _context.doctors.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        private int GenerateIndex()
        {
            int DoctorId = doctors.Count;
            return ++DoctorId;
        }
      
        public Doctor Delete(int id)
        {
            var doctor = GetById(id);
            if (doctor != null)
            {
                _context.doctors.Remove(doctor);
                _context.SaveChanges();
                return doctor;
            }
            return doctor;
        }
       

        public ICollection<Doctor> GetAll()
        {
            return _context.doctors.ToList();
        }

        public Doctor Update(Doctor entity)
        {
            _context.Entry<Doctor>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public Doctor GetById(int id)
        {
            Doctor doct = doctors.FirstOrDefault(p => p.DoctorId == id);
            if (doct == null)
                throw new InvalidOperationException("No doctor with id " + id);
            return doct;
        }

    }
}
