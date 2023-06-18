using ClinicApp.Entities;
using ClinicApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using ClinicApp.Database;

namespace ClinicApp.Repositories;

public class AppointmentRepo : IAppointmentRepo
{
    private ClinicAppDatabase _db;

    public AppointmentRepo(ClinicAppDatabase db)
    {
        _db = db;
    }

    public bool SlotIdIsReserved(Guid slotId)
    {
        return _db.Slots.Any(x => x.Equals(slotId));
    }

    public async Task Add(Appointment appointment)
    {
        _db.Appointments.Add(appointment);
        await _db.SaveChangesAsync();
    }

    public async Task Cancel(Guid Id)
    {
        await _db.SaveChangesAsync();
    }



}
