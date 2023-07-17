using System.Text.Json;
using Microsoft.Extensions.Hosting;
using ClinicApp.Services;
using ClinicApp.Repositories;
using ClinicApp.Database;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddClinicAppDb(builder.Configuration);
builder.Services.AddTransient<ISlotService, SlotService>();
builder.Services.AddTransient<ISlotRepository, SlotRepo>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IAppointmentRepo, AppointmentRepo>();

var app = builder.Build();

app.UseHttpLogging();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/", () => "Clinic Module");

app.MapControllers();

app.Run();