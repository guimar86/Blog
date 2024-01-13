using BlogApi.Data;
using BlogApi.Filters;
using BlogApi.Models;
using BlogApi.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(configure: cfg => { cfg.Filters.Add(typeof(ExceptionFilter)); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(("BlogDatabase"))));
builder.Services.AddAutoMapper(typeof(MapConfig));
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IBlog, BlogPostService>();
builder.Services.AddScoped<IComments, CommentService>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
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