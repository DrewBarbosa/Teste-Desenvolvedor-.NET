using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var services = new ServiceCollection();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


services.AddDbContext<ApplicationDbContext>(options => 
    options.UseInMemoryDatabase("VestibularDb"));


services.AddControllers();


//app.UseAuthorization();
app.Run();
