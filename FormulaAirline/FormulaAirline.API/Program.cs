using FormulaAirline.Database;
using FormulaAirline.Service.Implementation;
using FormulaAirline.Service.Interface;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AirlineDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IMessageProducer, MessageProducer>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
