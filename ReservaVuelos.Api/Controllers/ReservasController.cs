// <copyright file="ReservasController.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ReservaVuelos.Api.Response;
using ReservaVuelos.Application.Common.Helpers;
using ReservaVuelos.Application.Common.Interfaces.Services;
using ReservaVuelos.Application.Common.Interfaces.Services.Serilog;
using ReservaVuelos.Application.Common.Models.DTOs;
using ReservaVuelos.Application.Common.Models.DTOs.DtoBase;
using ReservaVuelos.Application.Common.Static;
using ReservaVuelos.Application.Common.Struct;

namespace ReservaVuelos.Api.Controllers
{
	/// <summary>
	/// Controller para la gestion de reservas
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ReservasController : ControllerBase
	{
		private readonly ISerilogImplements _serilogImplements;
		private readonly IReservaService _application;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="serilogImplements"></param>
		/// <param name="reservaService"></param>
		public ReservasController(ISerilogImplements serilogImplements, IReservaService reservaService)
		{
			_serilogImplements = serilogImplements;
			_application = reservaService;
		}

		/// <summary>
		/// Endpoint encargado de Crear una reserva
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("CrearReserva")]
		[HttpPost]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseCrear>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseCrear>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseCrear>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CrearReserva([FromBody] DtoJsonRequest request)
		{
			ObjectResult result;
			string methodName = nameof(CrearReserva);

			try
			{
				if (request == null)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<DtoJsonResponseCrear>.CreateError(UserTypeMessages.ERROR_REQUEST, new DtoJsonResponseCrear()));
				}

				DtoGenericResponse<DtoJsonResponseCrear> response = await _application.CrearReserva(request);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<DtoJsonResponseCrear>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<DtoJsonResponseCrear>.CreateSuccessful(response.Resultado!, response.Mensaje!));
				}

				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Information, JsonConvert.SerializeObject(result, Formatting.Indented), null, string.Format(UserTypeMessages.CONTROLLER_RESPONSE, methodName));

				return result;

			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Critical, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, string.Format(UserTypeMessages.ERRCATHCONTROLLER, methodName));
				return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<DtoErrorResponse>.CreateError(UserTypeMessages.ERROR_NO_CONTROLADO, ex.HandleExceptionMessage()));
			}
		}

		/// <summary>
		/// Endpoint encargado de obtener una reserva por código 
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("ObtenerReservaPorCodigo")]
		[HttpGet]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseGetCodigo>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseGetCodigo>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseGetCodigo>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> ObtenerReservaPorCodigo([FromQuery] string request)
		{
			ObjectResult result;
			string methodName = nameof(ObtenerReservaPorCodigo);

			try
			{

				if (string.IsNullOrWhiteSpace(request))
				{
					return BadRequest(ApiResponse<List<string>>.CreateError("El código de reserva es obligatorio."));
				}

				DtoGenericResponse<DtoJsonResponseGetCodigo> response = await _application.ObtenerReservaPorCodigo(request);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<DtoJsonResponseGetCodigo>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<DtoJsonResponseGetCodigo>.CreateSuccessful(response.Resultado!, response.Mensaje!));
				}

				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Information, JsonConvert.SerializeObject(result, Formatting.Indented), null, string.Format(UserTypeMessages.CONTROLLER_RESPONSE, methodName));

				return result;

			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Critical, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, string.Format(UserTypeMessages.ERRCATHCONTROLLER, methodName));
				return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<DtoErrorResponse>.CreateError(UserTypeMessages.ERROR_NO_CONTROLADO, ex.HandleExceptionMessage()));
			}
		}


		/// <summary>
		/// Endpoint encargado de obtener las reservas del dia 
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("GetReservasDelDia/dia")]
		[HttpGet]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseGet>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseGet>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseGet>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetReservasDelDia([FromQuery] DateTime request)
		{
			ObjectResult result;
			string methodName = nameof(GetReservasDelDia);

			try
			{
				if (request.Date < DateTime.Today)
				{
					return BadRequest(ApiResponse<List<string>>.CreateError("La fecha debe ser igual o posterior a hoy."));
				}


				DtoGenericResponse<DtoJsonResponseGet> response = await _application.ObtenerReservasDelDia(request);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<DtoJsonResponseGet>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<DtoJsonResponseGet>.CreateSuccessful(response.Resultado!, response.Mensaje!));
				}

				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Information, JsonConvert.SerializeObject(result, Formatting.Indented), null, string.Format(UserTypeMessages.CONTROLLER_RESPONSE, methodName));

				return result;

			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Critical, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, string.Format(UserTypeMessages.ERRCATHCONTROLLER, methodName));
				return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<DtoErrorResponse>.CreateError(UserTypeMessages.ERROR_NO_CONTROLADO, ex.HandleExceptionMessage()));
			}
		}
	}
}
