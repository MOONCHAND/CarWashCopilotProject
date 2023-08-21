using CarWashCopilot.Model;
using CarWashCopilot.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("CarwashCS");
builder.Services.AddDbContext<UserContext>(options =>
 options.UseSqlServer(connectionString));
builder.Services.AddTransient<IUser, ImpUser>();
builder.Services.AddTransient<IPackage, ImpPackage>();
builder.Services.AddTransient<ICardetails, ImpCardetails>();
builder.Services.AddTransient<IAdmin, ImpAdmin>();
builder.Services.AddTransient<IOrderdetails, ImpOrderdetails>();
builder.Services.AddCors(op =>
{
    op.AddDefaultPolicy(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
