// <copyright file="IReservaService.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using ReservaVuelos.Blazor.Application.Common.Models;

namespace ReservaVuelos.Blazor.Application.Common.Interfaces
{
	public interface IReservaService
	{
		Task<string> CrearReservaAsync(DtoJsonRequest request);
		Task<ApiResponse<DtoJsonResponseGetCodigo>?> ObtenerPorCodigoAsync(string codigo);
		Task<ApiResponse<DtoJsonResponseGet>> ObtenerDelDiaAsync(DateTime fecha);
	}
}
