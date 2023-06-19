using ClinicApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using ClinicApp.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ClinicApp.Repositories;

public class SlotRepo : ISlotRepository
{
    private ClinicAppDatabase _db;

    public SlotRepo(ClinicAppDatabase db)
    {
        _db = db;
    }

    public bool SlotIdIsExist(Guid slotId)
    {
        return _db.Slots.Any(x => x.Equals(slotId));
    }

    public async Task Add(Slot slot)
    {
        _db.Slots.Add(slot);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Guid SlotId)
    {
        await _db.SaveChangesAsync();
    }

    public async Task <List<Slot>> ListSlotByDoctor(string doctorName)
    {
        var slots = _db.Slots.Where(x => x.DoctorName == doctorName).ToList();
        return slots;

    }

    public async Task<List<Slot>> ListAllSlots()
    {
        return _db.Slots.ToList();

    }



}

