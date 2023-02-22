using CarsStore.Data;
using CarsStore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICarRepository, CarRepository>();

builder.Services.AddDbContext<CarStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:CarsStoreDBConnection"]);
});

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapDefaultControllerRoute();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
