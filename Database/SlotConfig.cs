using ClinicApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicApp.Entities;

namespace Test1.Database;

public class SlotConfig : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder.ToTable("Slots");
        builder.HasKey(x => x.DoctorName);
        builder.HasKey(x => x.Id);
        //throw new NotImplementedException();
    }
}
