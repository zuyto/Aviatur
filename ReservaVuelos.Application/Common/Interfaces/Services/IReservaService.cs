// <copyright file="IReservaService.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using ReservaVuelos.Application.Common.Models.DTOs;
using ReservaVuelos.Application.Common.Models.DTOs.DtoBase;

namespace ReservaVuelos.Application.Common.Interfaces.Services
{
	public interface IReservaService
	{
		Task<DtoGenericResponse<DtoJsonResponseCrear>> CrearReserva(DtoJsonRequest request);
		Task<DtoGenericResponse<DtoJsonResponseGetCodigo>> ObtenerReservaPorCodigo(string request);
		Task<DtoGenericResponse<DtoJsonResponseGet>> ObtenerReservasDelDia(DateTime request);
	}
}
