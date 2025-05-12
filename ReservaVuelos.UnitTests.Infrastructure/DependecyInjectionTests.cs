// <copyright file="DependecyInjectionTests.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using AspNetCoreRateLimit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using ReservaVuelos.Application.Common.Interfaces.Repository;
using ReservaVuelos.Application.Common.Struct;
using ReservaVuelos.Domain;
using ReservaVuelos.Infrastructure;
using ReservaVuelos.Infrastructure.Context;
using ReservaVuelos.Logger.Models;

namespace ReservaVuelos.UnitTests.Infrastructure
{
	public class DependecyInjectionTests
	{
		[Fact]
		public void ConfigureRateLimitiong_ShouldConfigureRateLimitOptions()
		{
			// Arrange
			var services = new ServiceCollection();

			// Act
			DependecyInjection.ConfigureRateLimitiong(services);

			// Assert
			var serviceProvider = services.BuildServiceProvider();
			var options = serviceProvider.GetRequiredService<IOptions<IpRateLimitOptions>>().Value;

			Assert.Equal(ConfigurationStruct.EnableEndpointRateLimiting, options.EnableEndpointRateLimiting);
			Assert.Equal(ConfigurationStruct.StackBlockedRequests, options.StackBlockedRequests);
			Assert.Equal(429, options.HttpStatusCode);
			Assert.Equal(ConfigurationStruct.RealIpHeader, options.RealIpHeader);
			Assert.Single(options.GeneralRules);
			Assert.Equal(ConfigurationStruct.Endpoint, options.GeneralRules[0].Endpoint);
			Assert.Equal(ConfigurationStruct.Period, options.GeneralRules[0].Period);
			Assert.Equal(100000, options.GeneralRules[0].Limit);
		}
		[Fact]
		public void ConfigureRateLimiting_RegistersExpectedServices()
		{
			// Arrange
			var services = new ServiceCollection();

			// Act
			DependecyInjection.ConfigureRateLimitiong(services); // Asumiendo que este método está definido y accesible

			// Assert
			// Verificar que los servicios específicos están registrados
			Assert.Contains(services, service => service.ServiceType == typeof(IMemoryCache));
			Assert.Contains(services, service => service.ServiceType == typeof(IRateLimitConfiguration));
		}

		[Fact]
		public void AddInfrastructure_ShouldConfigureCorsPolicy()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();
			var services = builder.Services;
			Environment.SetEnvironmentVariable(ConfigurationStruct.WithOrigins, "http://example.com");

			// Act
			builder.AddInfrastructure();

			// Assert
			var serviceProvider = services.BuildServiceProvider();
			var corsOptions = serviceProvider.GetRequiredService<IOptions<CorsOptions>>().Value;
			Assert.NotNull(corsOptions);
			var corsPolicy = corsOptions.GetPolicy(ConfigurationStruct.CorsPolicy);
			Assert.NotNull(corsPolicy);
			Assert.Contains(corsPolicy.Origins, origin => origin == "http://example.com");
		}

		[Fact]
		public void AddInfrastructure_ShouldConfigureLogger()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();
			var services = builder.Services;
			Environment.SetEnvironmentVariable(ConfigurationStruct.Gerencia, "GerenciaTest");
			Environment.SetEnvironmentVariable(ConfigurationStruct.Celula, "CelulaTest");
			Environment.SetEnvironmentVariable(ConfigurationStruct.Aplicacion, "AplicacionTest");
			Environment.SetEnvironmentVariable(ConfigurationStruct.Proyecto, "ProyectoTest");

			// Act
			builder.AddInfrastructure();

			// Assert
			var serviceProvider = services.BuildServiceProvider();
			var loggerOptions = serviceProvider.GetRequiredService<IOptions<LoggerOptions>>().Value;
			Assert.NotNull(loggerOptions);
			Assert.Equal("v1.1", loggerOptions.Meta);
			Assert.Equal("", loggerOptions.Autor);
			Assert.Equal("", loggerOptions.Area);
			Assert.Equal("", loggerOptions.Aplicacion);
			Assert.Equal("", loggerOptions.Proceso);
			Assert.Equal("", loggerOptions.Servicio);
			Assert.Equal("", loggerOptions.Endpoint);
		}

		[Fact]
		public void AddDbContext_ShouldUseOracleWithDecryptedSecret()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();
			var services = builder.Services;
			var RESERVAS_DB_CONEXION = "Server=LAPTOP-KF792H7H;Database=ReservaVuelosDb;Integrated Security=True;TrustServerCertificate=True;";
			Environment.SetEnvironmentVariable(ConfigurationStruct.RESERVAS_DB_CONEXION, RESERVAS_DB_CONEXION);

			// Act
			builder.AddDbContext();

			// Assert
			var serviceProvider = services.BuildServiceProvider();
			var context = serviceProvider.GetService<DynamicContext>();
			Assert.NotNull(context);
		}


		[Fact]
		public void ConfigureRateLimitiong_ShouldConfigureRateLimitingCorrectly()
		{
			// Arrange
			var services = new ServiceCollection();

			// Act
			DependecyInjection.ConfigureRateLimitiong(services);

			// Assert
			var serviceProvider = services.BuildServiceProvider();
			var rateLimitConfig = serviceProvider.GetService<IRateLimitConfiguration>();
			Assert.NotNull(rateLimitConfig);
		}

		[Fact]
		public void ConfigureRateLimitiong_ShouldThrowException_WhenServicesIsNull()
		{
			// Arrange
			ServiceCollection? services = null;

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => DependecyInjection.ConfigureRateLimitiong(services!));
		}

		[Fact]
		public void ConfigureAppSettingsManagerConnections_ShouldConfigureAppSettingsCorrectly()
		{
			// Arrange
			var builderMock = WebApplication.CreateBuilder();
			var services = builderMock.Services;

			Environment.SetEnvironmentVariable(ConfigurationStruct.RESERVAS_DB_CONEXION, "TestConnectionString");

			// Act
			DependecyInjection.AddInfrastructure(builderMock);
			var serviceProvider = services.BuildServiceProvider();
			var options = serviceProvider.GetService<IOptions<AppSettingsConfig>>();

			// Assert
			Assert.NotNull(options);

		}

	}
}
