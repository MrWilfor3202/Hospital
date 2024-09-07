using Hospital.Application.Services;
using Hospital.Core.Abstract.Repositories;
using Hospital.Core.Abstract.Services;
using Hospital.Core.Abstract.UnitOfWork;
using Hospital.DataAccess.Context;
using Hospital.DataAccess.Implementations.Repositories.EF;
using Hospital.DataAccess.Implementations.UnitOfWork.EF;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddTransient<IDoctorsService, DoctorsService>();
builder.Services.AddTransient<IPatientsService, PatientsService>();
builder.Services.AddDbContext<HospitalDbContext>();

/*
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
