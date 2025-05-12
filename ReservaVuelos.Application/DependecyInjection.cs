// <copyright file="DependecyInjection.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;

using ReservaVuelos.Application.Common.Helpers;
using ReservaVuelos.Application.Common.Interfaces.Bifurcacion;
using ReservaVuelos.Application.Common.Interfaces.Services;
using ReservaVuelos.Application.Common.Interfaces.Services.Http;
using ReservaVuelos.Application.Common.Interfaces.Services.Serilog;
using ReservaVuelos.Application.Common.Profiles;
using ReservaVuelos.Application.Services;
using ReservaVuelos.Application.Services.Bifurcacion;
using ReservaVuelos.Application.Services.Http;
using ReservaVuelos.Application.Services.Serilog;

namespace ReservaVuelos.Application
{
	[ExcludeFromCodeCoverage]
	public static class DependecyInjection
	{
		public static IServiceCollection AddApplication(
			this IServiceCollection services)
		{
			_ = services.AddFluentValidationAutoValidation()
				.AddFluentValidationClientsideAdapters();

			_ = services.AddAutoMapper(
				Assembly.GetAssembly(typeof(MappingProfile)));

			services.AddTransient<ISerilogImplements, SerilogImplements>();
			services.AddTransient<IGenericServiceAgent, GenericServiceAgent>();
			services.AddTransient<HttpServiceManager>();
			services.AddTransient<IBifurcacionDatos, BifurcacionDatos>();
			services.AddTransient<IReservaService, ReservaService>();

			return services;
		}
	}
}
