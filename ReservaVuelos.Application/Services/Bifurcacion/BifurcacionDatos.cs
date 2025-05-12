// <copyright file="BifurcacionDatos.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Newtonsoft.Json;

using ReservaVuelos.Application.Common.Helpers;
using ReservaVuelos.Application.Common.Interfaces.Bifurcacion;
using ReservaVuelos.Application.Common.Models.DTOs;
using ReservaVuelos.Application.Common.Models.DTOs.DtoBase;
using ReservaVuelos.Application.Common.Struct;
using ReservaVuelos.Domain.Entities.ReservaVuelos;

namespace ReservaVuelos.Application.Services.Bifurcacion
{
	public class BifurcacionDatos(HttpServiceManager httpServiceManager) : IBifurcacionDatos
	{
		private readonly HttpServiceManager _httpServiceManager = httpServiceManager;

		public Reserva? ArmarEntidad(DtoJsonRequest request, List<DtoDatosResponseApi> dtoDatosResponseApis)
		{

			DtoDatosResponseApi origenInfo = dtoDatosResponseApis.FirstOrDefault(a => string.Equals(a.Iata_Code, request.Origen, StringComparison.OrdinalIgnoreCase));

			DtoDatosResponseApi destinoInfo = dtoDatosResponseApis.FirstOrDefault(a => string.Equals(a.Iata_Code, request.Destino, StringComparison.OrdinalIgnoreCase));

			Reserva reserva = new Reserva
			{

				Cliente = request.Cliente,
				Origen = request.Origen,
				Destino = request.Destino,
				OrigenCiudad = origenInfo.Country_Name,
				DestinoCiudad = destinoInfo.Country_Name,
				FechaSalida = DateOnly.FromDateTime(request.FechaSalida),
				Estado = "Pendiente"
			};

			return reserva;
		}

		public async Task<List<DtoDatosResponseApi>> ValidarIataCodes(string origen, string destino)
		{


			var parametros = new Dictionary<string, string>
			{
				{ "access_key", Environment.GetEnvironmentVariable(ConfigurationStruct.ACCESS_KEY).ToString() }
			};


			DtoGenericResponseHttp respuesta = await _httpServiceManager.GetHttpAsync(ConfigurationStruct.AVIATIONSTACK, null, parametros);

			if (!respuesta.EsExitoso)
			{
				return [];
			}

			DtoJsonResponseApiExterna dtoDatosResponseApi = JsonConvert.DeserializeObject<DtoJsonResponseApiExterna>(respuesta.ResultadoHttp);

			if (0 == dtoDatosResponseApi.Data.Count)
			{
				return [];
			}

			List<DtoDatosResponseApi> iataCodeEncontrados = dtoDatosResponseApi.Data
										.Where(a => string.Equals(a.Iata_Code, origen, StringComparison.OrdinalIgnoreCase) || string.Equals(a.Iata_Code, destino, StringComparison.OrdinalIgnoreCase))
										.ToList();

			if (0 == iataCodeEncontrados.Count)
			{
				return [];
			}



			return iataCodeEncontrados;

		}
	}
}
