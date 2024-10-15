using Microsoft.EntityFrameworkCore;
using TaskList.Data.Context;
using TaskList.Services.Interfaces;
using TaskList.Services.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ListenAnyIP(5000);
    opt.ListenAnyIP(5001);
});
builder.WebHost.UseUrls("http://*:5000");
builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskConnection"));
});

builder.Services.AddTransient<ITaskService, TaskService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
