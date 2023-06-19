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

    public async Task Add(Appointment appointment)
    {
        _db.Appointments.Add(appointment);
        await _db.SaveChangesAsync();
    }

    public async Task Cancel(Guid Id)
    {
        await _db.SaveChangesAsync();
    }

    public async Task AppointmentIsCompleted(bool status, Guid id)
    {
        var result = new Appointment { Id = id, IsCompleted = status };
        _db.Appointments.Attach(result).Property(x => x.IsCompleted).IsModified = true;
        _db.SaveChanges();

    }

    public async Task GetNextAppointment(string doctorName)
    {
        _db.Slots.Where(x => x.IsReserved == true).Where(x => x.DoctorName == doctorName).Where(x => x.Time == "xxx").ToList();
        await _db.SaveChangesAsync();


    }
}
