// <copyright file="IReservaVuelosDbRepository.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>



using ReservaVuelos.Domain.Entities.ReservaVuelos;

namespace ReservaVuelos.Application.Common.Interfaces.Repository.ReservaVuelosDb
{
	public interface IReservaVuelosDbRepository
	{
		Task<string> CrearReserva(Reserva reserva);
		Task<Reserva?> ObtenerReservaPorCodigo(string request);
		Task<List<Reserva>> ObtenerReservasDelDia(DateTime request);
	}
}
