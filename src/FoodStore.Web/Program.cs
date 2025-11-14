using FluentValidation;
using FoodStore.Application.Behaviors;
using FoodStore.Application.Foods.Commands;
using FoodStore.Application.Services;
using FoodStore.Infrastructure;
using FoodStore.Infrastructure.DataModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<FoodStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(CreateFood).Assembly);
    options.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzkzMzE4NDAwIiwiaWF0IjoiMTc2MTg0OTgyNiIsImFjY291bnRfaWQiOiIwMTlhMzY2ZTNiN2M3NTE0YjUzMDc1YWEzYWFmZmRiYyIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazh2NnhxbTVzOHB0NzN5OWNjMTlwMnZlIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.DAu0Sms8cQASsZzENlvP6eH196C6PE2SvRjQBdMZUb1Jwo6MZMDigPRkLwfetIvC8kxUBf5zl1eNW2PM4eqUQRXWVdRFNwHmTEGsGhYHXl5ebf9-V5c6QoN_s4Prdghvkjr6COYaz_iPqtFMVAom2ztu0cctOvHVU-n3JjUY3ARORYffqFGX8cpfpNb-H7Wh56KnjPgzHpOhVsYnMU00PnlVTilEIlyn3IoOHPCSVPtVx-ygAHAEc7aXhu2Lz3ncrDW3NZk5erBIQWPH_JNhk2a0Lw30N-lIzWQAQg-ol3W8NdmEQRvy9JAVVTlzYg_jc5v_3gf8ChXMrS8kvQ8vSw";
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateFood.CreateFoodCommandValidator>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
