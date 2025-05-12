// <copyright file="ServiceLoggerCollection.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using ReservaVuelos.Logger.Enricher;
using ReservaVuelos.Logger.Models;

using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;

namespace ReservaVuelos.Logger
{
	public static class ServiceLoggerCollection
	{
		private static LoggerConfiguration loggerConfig = new();

		private const string settings =
			"[{Timestamp: dd/MM/yyyy - HH:mm:ss.fff} {Level:u3}] | {SourceContext} | {Message:l} | {Properties} {NewLine} {Exception} | {miembro:MemberName} | linea: {LineNumber} ";

		public static LoggerOptions AddLogger(
		this IServiceCollection services, LoggerOptions setupAction,
		Dictionary<string, object>? customProperties = default)
		{
			services.AddLogging(loggingBuilder =>
			{
				loggerConfig = new LoggerConfiguration()
					.MinimumLevel.Information()
					.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
					.MinimumLevel.Override("Microsoft.Hosting.Lifetime",
						LogEventLevel.Information)
					.WriteTo.Console(outputTemplate: settings)
					.Enrich.FromLogContext()
					.Enrich.WithAssemblyName()
					.Enrich.With<LoggerEnricher>();

				//propiedes estadar
				foreach (var propertyInfo in setupAction.GetType().GetProperties())
				{
					var value = propertyInfo.GetValue(setupAction, null);
					loggerConfig = loggerConfig.Enrich.WithProperty(propertyInfo.Name, value);
				}

				//propiedes personalizadas
				if (customProperties != null)
				{
					foreach (var entry in customProperties)
					{
						loggerConfig.Enrich.WithProperty(entry.Key, entry.Value);
					}
				}

				var logger = loggerConfig.CreateLogger();

				loggingBuilder.Services.AddSingleton<ILoggerFactory>(provider =>
					new SerilogLoggerFactory(logger));
			});

			return setupAction;
		}

		/// <summary>
		///     Incluir propiedades adicionales
		/// </summary>
		/// <param name="swaggerGenOptions"></param>
		/// <param name="name">nombre de la propiedad</param>
		/// <param name="value">valor de la propiedad</param>
		public static void IncludeProperty(
			this LoggerOptions swaggerGenOptions, string name, object value)
		{
			loggerConfig.Enrich.WithProperty(name, value);
		}
	}
}
