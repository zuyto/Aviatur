// <copyright file="DependecyInjection.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using ReservaVuelos.Blazor.Application.Common.Helpers;
using ReservaVuelos.Blazor.Application.Common.Interfaces;
using ReservaVuelos.Blazor.Application.Services;
using ReservaVuelos.Blazor.Application.Services.Serilog;

namespace ReservaVuelos.Blazor.Application
{
	[ExcludeFromCodeCoverage]
	public static class DependecyInjection
	{
		public static IServiceCollection AddApplication(
			this IServiceCollection services)
		{
			services.AddTransient<ISerilogImplements, SerilogImplements>();
			services.AddHttpClient();
			services.AddScoped<HttpServiceManager>();
			services.AddScoped<IReservaService, ReservaService>();

			return services;
		}
	}
}
