using DateProvider;
using FireBaseDB.DB;
using FireBaseDB.DB.Impl;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency injection, inject with parameters
var fireBase_AuthSecret = builder.Configuration.GetValue<string>("FireBaseConfigrations:AuthSecret") ??  throw new InvalidOperationException(" not found.");
var fireBase_BasePath = builder.Configuration.GetValue<string>("FireBaseConfigrations:BasePath") ??  throw new InvalidOperationException(" not found.");

builder.Services.AddSingleton<IFireBaseDBContext>(provider => new FireBaseDBContext(fireBase_AuthSecret, fireBase_BasePath));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DateProvider service
builder.Services.AddTransient<IDateProvider, DateProvider.Impl.DateProvider>();

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
