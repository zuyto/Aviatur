// <copyright file="IBifurcacionDatos.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>


using ReservaVuelos.Application.Common.Models.DTOs;
using ReservaVuelos.Domain.Entities.ReservaVuelos;

namespace ReservaVuelos.Application.Common.Interfaces.Bifurcacion
{
	public interface IBifurcacionDatos
	{
		Reserva? ArmarEntidad(DtoJsonRequest request, List<DtoDatosResponseApi> dtoDatosResponseApis);
		Task<List<DtoDatosResponseApi>> ValidarIataCodes(string origen, string destino);
	}
}
