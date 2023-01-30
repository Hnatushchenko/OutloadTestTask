using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OutloadTestTaskApp.Repository;
using OutloadTestTaskApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));
builder.Services.AddScoped<IApplicationContext>(provider => provider.GetRequiredService<ApplicationContext>());
builder.Services.AddTransient<IRssSubscriptionService, RssSubscriptionService>();

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
