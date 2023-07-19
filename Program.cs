using System.Text.Json;
using Microsoft.Extensions.Hosting;
using ClinicApp.Services;
using ClinicApp.Repositories;
using ClinicApp.Database;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using ClinicApp.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services);
});

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
});

// Add services to the container.
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.AddClinicAuthentication(builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddClinicAppDb(builder.Configuration);
builder.Services.AddTransient<ISlotService, SlotService>();
builder.Services.AddTransient<ISlotRepository, SlotRepo>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddTransient<JwtCreator>();

var app = builder.Build();

app.UseHttpLogging();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.MapGet("/", () => "Clinic Module");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();