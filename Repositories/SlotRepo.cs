﻿using ClinicApp.Entities;
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

    //add slot
    public async Task Add(Slot slot)
    {
        _db.Slots.Add(slot);
        await _db.SaveChangesAsync();
    }

    //remove slot
    public async Task Delete(Guid SlotId)
    {
        var itemToRemove = _db.Slots.SingleOrDefault(x => x.Id == SlotId);
        _db.Slots.Remove(itemToRemove);
        await _db.SaveChangesAsync();
    }

    public async Task <List<Slot>> ListSlotByDoctor(string doctorName)
    {
        return _db.Slots.Where(x => x.DoctorName == doctorName).ToList();

    }

    public async Task<List<Slot>> ListAllSlots()
    {
        return _db.Slots.ToList();

    }

    public async Task<List<Slot>> ListAvailableSlots()
    {
        return _db.Slots.Where(x => x.IsReserved == true).ToList();

    }
    public async Task UpdateSlotReservation(bool isReserved, Guid slotId)
    {
        var result = new Slot { Id = slotId, IsReserved = isReserved };
        _db.Slots.Attach(result).Property(x => x.IsReserved).IsModified = true;
        _db.SaveChanges();
        
    }


}

