using ClinicApp.Entities;

namespace ClinicApp.Repositories
{
    public interface IAppointmentRepo
    {

        public Task AppointmentIsCompleted(bool status, Guid id);
        public Task Add(Appointment appointment);
        public Task Cancel(Guid id);
        public Task GetNextAppointment(string doctorName);
     

    }
}

