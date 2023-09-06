using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Contexts;
using DoctorApp.Interfaces;
using DoctorApp.Models;





namespace DoctorApplication.Repositories
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly DoctorAppContexts _context;

        static List<Appointment> appointments = new List<Appointment>();

        public AppointmentRepository(DoctorAppContexts contexts)
        {
            _context = contexts;
        }

        public Appointment Add(Appointment entity)
        {
            if (entity == null)
                throw new ArgumentNullException("No Doctor Available");
            entity.AppointmentNumber = GenerateIndex();
            _context.appointments.Add(entity);
            _context.SaveChanges();
            return entity;

        }

        private int GenerateIndex()
        {
            int AppointmentNumber = appointments.Count;
            return ++AppointmentNumber;
        }



        public Appointment Delete(int id)
        {
            var apmt = GetById(id);
            _context.appointments.Remove(apmt);
            _context.SaveChanges();
            return apmt;
        }
        public Appointment GetById(int id)
        {
            var apmt = _context.appointments.FirstOrDefault(d => d.AppointmentNumber == id);
            return apmt;
        }
   



        public ICollection<Appointment> GetAll()
        {
            return _context.appointments.ToList();
        }


        public Appointment Update(Appointment entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}