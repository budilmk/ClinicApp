using ClinicApp.Entities;

namespace ClinicApp.Repositories
{
    public interface IAppointmentRepo
    {

        public bool SlotIdIsReserved(Guid id);
        public Task Add(Appointment appointment);
        public Task Cancel(Guid id);
     

    }
}

