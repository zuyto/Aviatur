// <copyright file="Program.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using FluentValidation;

using ReservaVuelos.Blazor.Application;
using ReservaVuelos.Blazor.Application.Common.Filtros;
using ReservaVuelos.Blazor.Application.Common.Helpers;
using ReservaVuelos.Blazor.Application.Common.Models;
using ReservaVuelos.Blazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddApplication();

builder.Services.AddValidatorsFromAssemblyContaining<DtoJsonRequestValidator>();
builder.Services.AddScoped<FluentValidationValidator<DtoJsonRequest>>();

builder?.Services.AddHttpClient(ConfigurationStruct.URL_CREAR, client =>
{
	client.BaseAddress = new Uri(Environment.GetEnvironmentVariable(ConfigurationStruct.URL_CREAR) ?? string.Empty);
});

builder?.Services.AddHttpClient(ConfigurationStruct.URL_POR_CODIGO, client =>
{
	client.BaseAddress = new Uri(Environment.GetEnvironmentVariable(ConfigurationStruct.URL_POR_CODIGO) ?? string.Empty);
});

builder?.Services.AddHttpClient(ConfigurationStruct.URL_DIA, client =>
{
	client.BaseAddress = new Uri(Environment.GetEnvironmentVariable(ConfigurationStruct.URL_DIA) ?? string.Empty);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
