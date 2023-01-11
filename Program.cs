using APIwithFrontNT;
using APIwithFrontNT.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var allowAll = "_allowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAll,
                      policy =>
                      {
                          policy
                         .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowAll);


app.UseAuthorization();

app.MapControllers();

app.Run();
