using Microsoft.EntityFrameworkCore;
using RegaloOriginalTest.Infrastructure;
using RegaloOriginalTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RODbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RegaloOriginalDB"));
    });


builder.Services.AddScoped<IItemVentaService, ItemVentaService>();

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
