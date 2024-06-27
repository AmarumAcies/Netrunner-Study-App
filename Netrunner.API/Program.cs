using Netrunner.Application.ClassicExample.Contract;
using Netrunner.Application.ClassicExample.Implementaion;
using Netrunner.Application;
using Netrunner.Domain.Interface;
using Netrunner.Infrastructure.Implementation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//подключить интеграцию зависимостей
builder.Services.AddScoped<ICardRepository, CardRepository>(sp =>
{
    var connectionString = "Data Source=Amarum;Initial Catalog=Netrunner.Base;Integrated Security=True;Encrypt=False";
    return new CardRepository(connectionString);
}

 );

//builder.Services.AddScoped<ICardLogic, CardLogic>(sp =>
//{
//    var cardRepository = sp.GetRequiredService<CardRepository>();
//    return new CardLogic(cardRepository);
//}
//);
builder.Services.AddApplication();




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
