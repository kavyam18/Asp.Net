using LearningManagementSystem.DAL;
using LearningManagementSystem.Services.Implementation;
using LearningManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPrimaryInfoRepository, PrimaryInfoRepository>();
builder.Services.AddScoped<ISecondaryInfoRepository, SecondaryInfoRepository>();    
builder.Services.AddScoped<IEducationRepository, EducationRepository>();    
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();   
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ITechnicalSkillRepository, TechnicalSkillRepository>();  

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
