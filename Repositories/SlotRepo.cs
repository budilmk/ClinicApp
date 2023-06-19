﻿using ClinicApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using ClinicApp.Database;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public async Task ListSlot(string doctorName)
    {

    }

    public async Task<List<Slot>> GetAll()
    {
        return _db.Slots.ToList();

    }



}

