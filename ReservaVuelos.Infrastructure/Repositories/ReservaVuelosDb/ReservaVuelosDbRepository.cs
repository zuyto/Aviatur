// <copyright file="ReservaVuelosDbRepository.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using ReservaVuelos.Application.Common.Helpers;
using ReservaVuelos.Application.Common.Interfaces.Repository.ReservaVuelosDb;
using ReservaVuelos.Application.Common.Interfaces.Services.Serilog;
using ReservaVuelos.Application.Common.Struct;
using ReservaVuelos.Domain.Entities.ReservaVuelos;
using ReservaVuelos.Infrastructure.Context;

namespace ReservaVuelos.Infrastructure.Repositories.ReservaVuelosDb
{
	[ExcludeFromCodeCoverage]
	public class ReservaVuelosDbRepository(ReservaVuelosDbContext reservaVuelosDbContext, ISerilogImplements serilogImplements) : IReservaVuelosDbRepository
	{
		public readonly ReservaVuelosDbContext _reservaVuelosDbContext = reservaVuelosDbContext;
		public readonly ISerilogImplements _serilogImplements = serilogImplements;

		public async Task<string> CrearReserva(Reserva reserva)
		{
			try
			{
				_reservaVuelosDbContext.Reservas.Add(reserva);
				await _reservaVuelosDbContext.SaveChangesAsync();

				return reserva.CodigoReserva!;

			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Error, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, "\n\n **** CATCH ERROR CrearReserva **** \n");
				throw;
			}
		}

		public async Task<Reserva?> ObtenerReservaPorCodigo(string request)
		{
			try
			{
				return await _reservaVuelosDbContext.Reservas.Where(p => p.CodigoReserva == request).SingleOrDefaultAsync();
			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Error, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, "\n\n **** CATCH ERROR ObtenerReservaPorCodigo **** \n");
				throw;
			}
		}

		public async Task<List<Reserva>> ObtenerReservasDelDia(DateTime request)
		{
			try
			{
				var fechaTexto = request.Date.ToString("yyyy-MM-dd");

				var res = await _reservaVuelosDbContext.Reservas.Where(p => p.FechaSalida.HasValue && p.FechaSalida.Value.ToString() == fechaTexto).ToListAsync();

				return res;
			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Error, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, "\n\n **** CATCH ERROR ObtenerReservasDelDia **** \n");
				throw;
			}
		}
	}
}
