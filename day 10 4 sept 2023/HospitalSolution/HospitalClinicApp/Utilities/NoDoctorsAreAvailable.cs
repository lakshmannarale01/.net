namespace HospitalClinicApp.Utilities
{
    public class NoDoctorsAreAvailable :Exception
    {

        public override string Message => "Doctor is already occupied";
    }
}
