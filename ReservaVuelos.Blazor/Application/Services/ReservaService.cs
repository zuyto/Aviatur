// <copyright file="ReservaService.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Newtonsoft.Json;

using ReservaVuelos.Blazor.Application.Common.Helpers;
using ReservaVuelos.Blazor.Application.Common.Interfaces;
using ReservaVuelos.Blazor.Application.Common.Models;

namespace ReservaVuelos.Blazor.Application.Services
{
	public class ReservaService(HttpServiceManager httpServiceManager) : IReservaService
	{
		private readonly HttpServiceManager _httpServiceManager = httpServiceManager;
		public async Task<string> CrearReservaAsync(DtoJsonRequest request)
		{

			DtoGenericResponseHttp response = await _httpServiceManager.PostHttpAsync(ConfigurationStruct.URL_CREAR, JsonConvert.SerializeObject(request));
			ApiResponse<DtoJsonResponseCrear> result = JsonConvert.DeserializeObject<ApiResponse<DtoJsonResponseCrear>>(response.ResultadoHttp);
			return result?.Result?.CodigoReserva ?? result?.ErrorMessage;

		}

		public async Task<ApiResponse<DtoJsonResponseGet>> ObtenerDelDiaAsync(DateTime fecha)
		{
			var parametros = new Dictionary<string, string>
			{
				{ "request", fecha.Date.ToString("yyyy-MM-dd") }
			};
			var response = await _httpServiceManager.GetHttpAsync(ConfigurationStruct.URL_DIA, null, parametros);
			ApiResponse<DtoJsonResponseGet> result = JsonConvert.DeserializeObject<ApiResponse<DtoJsonResponseGet>>(response.ResultadoHttp);
			return result;
		}

		public async Task<ApiResponse<DtoJsonResponseGetCodigo>?> ObtenerPorCodigoAsync(string codigo)
		{
			var parametros = new Dictionary<string, string>
			{
				{ "request", codigo }
			};
			var response = await _httpServiceManager.GetHttpAsync(ConfigurationStruct.URL_POR_CODIGO, null, parametros);
			ApiResponse<DtoJsonResponseGetCodigo> result = JsonConvert.DeserializeObject<ApiResponse<DtoJsonResponseGetCodigo>>(response.ResultadoHttp);
			return result;
		}
	}
}
