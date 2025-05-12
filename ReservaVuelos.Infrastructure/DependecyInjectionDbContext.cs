// <copyright file="DependecyInjectionDbContext.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>


using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ReservaVuelos.Application.Common.Struct;
using ReservaVuelos.Infrastructure.Context;

namespace ReservaVuelos.Infrastructure
{
	/// <summary>
	/// Clase encargada de realziar a consiguracion de los DbContext
	/// </summary>
	///
	[ExcludeFromCodeCoverage]
	public static class DependecyInjectionDbContext
	{
		/// <summary>
		/// Metodo extension de WebApplicationBuilder (Program)
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
		{


			AddDynamicContext(builder);
			AddReservaVuelosDbContext(builder);

			return builder!;
		}


		#region[DB DYMAMIC]
		private static void AddDynamicContext(WebApplicationBuilder builder)
		{
			builder?.Services.AddDbContext<DynamicContext>(options =>
			{
				ConfigureDbContextOptions(builder, options, ConfigurationStruct.PROD_SGL);
			}, ServiceLifetime.Scoped);
		}
		#endregion


		#region[DB RESERVAS_DB_CONEXION]
		private static void AddReservaVuelosDbContext(WebApplicationBuilder builder)
		{
			builder?.Services.AddDbContext<ReservaVuelosDbContext>(options =>
			{
				ConfigureDbContextOptions(builder, options, ConfigurationStruct.RESERVAS_DB_CONEXION);
			}, ServiceLifetime.Scoped);
		}
		#endregion

		/// <summary>
		/// Metodo encargado de realizar la configuracion de los DbContext
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="options"></param>
		/// <param name="connectionStringName"></param>
		private static void ConfigureDbContextOptions(WebApplicationBuilder builder, DbContextOptionsBuilder options, string connectionStringName)
		{

			options.UseSqlServer(Environment.GetEnvironmentVariable(connectionStringName));

			if (builder!.Environment.IsDevelopment()!)
			{
				// Configurar el nivel de registro
				options.EnableSensitiveDataLogging(); // Esto habilita la información sensible como parámetros de SQL
				options.LogTo(Console.WriteLine, [DbLoggerCategory.Database.Command.Name]); // Esto redirige los mensajes de registro a la consola
			}
		}
	}
}
