// <copyright file="ReservaService.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>


using ReservaVuelos.Application.Common.Helpers;
using ReservaVuelos.Application.Common.Interfaces.Bifurcacion;
using ReservaVuelos.Application.Common.Interfaces.Repository;
using ReservaVuelos.Application.Common.Interfaces.Services;
using ReservaVuelos.Application.Common.Models.DTOs;
using ReservaVuelos.Application.Common.Models.DTOs.DtoBase;
using ReservaVuelos.Application.Common.Static;
using ReservaVuelos.Domain.Entities.ReservaVuelos;

namespace ReservaVuelos.Application.Services
{
	public class ReservaService(IUnitOfWorkReservaVuelosDb unitOfWorkReservaVuelosDb, IBifurcacionDatos bifurcacionDatos) : IReservaService
	{
		private readonly IUnitOfWorkReservaVuelosDb _unitOfWorkReservaVuelosDb = unitOfWorkReservaVuelosDb;
		private readonly IBifurcacionDatos _bifurcacionDatos = bifurcacionDatos;


		public async Task<DtoGenericResponse<DtoJsonResponseCrear>> CrearReserva(DtoJsonRequest request)
		{


			List<DtoDatosResponseApi> dtoDatosResponseApis = await _bifurcacionDatos.ValidarIataCodes(request.Origen, request.Destino);

			if (0 == dtoDatosResponseApis.Count)
			{
				return GenericHelpers.BuildResponse<DtoJsonResponseCrear>(false, null, UserTypeMessages.ERROR_IATA);
			}


			Reserva? reserva = _bifurcacionDatos.ArmarEntidad(request, dtoDatosResponseApis);

			if (null == reserva)
			{
				return GenericHelpers.BuildResponse<DtoJsonResponseCrear>(false, null, UserTypeMessages.ERROR_IATA);
			}


			string codigoReserva = await _unitOfWorkReservaVuelosDb.ReservaVuelosDbRepository.CrearReserva(reserva);

			DtoJsonResponseCrear res = new DtoJsonResponseCrear { Codigo = codigoReserva, Mensaje = UserTypeMessages.OKGEN01 };

			return GenericHelpers.BuildResponse<DtoJsonResponseCrear>(true, res, res.Mensaje);
		}

		public async Task<DtoGenericResponse<DtoJsonResponseGetCodigo>> ObtenerReservaPorCodigo(string request)
		{

			Reserva? reserva = await _unitOfWorkReservaVuelosDb.ReservaVuelosDbRepository.ObtenerReservaPorCodigo(request);


			if (null == reserva)
			{
				return GenericHelpers.BuildResponse<DtoJsonResponseGetCodigo>(false, new DtoJsonResponseGetCodigo { Reserva = reserva }, UserTypeMessages.NO_DATOS);
			}

			return GenericHelpers.BuildResponse<DtoJsonResponseGetCodigo>(true, new DtoJsonResponseGetCodigo { Reserva = reserva }, UserTypeMessages.OKGEN01);

		}

		public async Task<DtoGenericResponse<DtoJsonResponseGet>> ObtenerReservasDelDia(DateTime request)
		{
			List<Reserva> reserva = await _unitOfWorkReservaVuelosDb.ReservaVuelosDbRepository.ObtenerReservasDelDia(request);


			if (0 == reserva?.Count)
			{
				return GenericHelpers.BuildResponse<DtoJsonResponseGet>(false, new DtoJsonResponseGet { Reserva = reserva }, UserTypeMessages.NO_DATOS);
			}

			return GenericHelpers.BuildResponse<DtoJsonResponseGet>(true, new DtoJsonResponseGet { Reserva = reserva }, UserTypeMessages.OKGEN01);
		}
	}
}
