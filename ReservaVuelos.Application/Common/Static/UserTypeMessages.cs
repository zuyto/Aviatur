// <copyright file="UserTypeMessages.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace ReservaVuelos.Application.Common.Static
{
	/// <summary>
	///     Mensajes de control de errores de la aplicación
	/// </summary>
	public static class UserTypeMessages
	{

		public const string? SSL = "⚠️ La validación del certificado SSL está deshabilitada en entornos de desarrollo y pruebas.";

		public const string OKGEN01 = "PROCESO REALIZADO CON EXITO";
		public const string OKERRGEN01 = "PROCESO REALIZADO CON EXITO, PERO PRESENTO ALGUNAS NOVEDADES";
		public const string API_NO_RETORNA_DATOS = "LA CONSULTA NO RETORNO DATOS";
		public const string ERROR_IATA = "LOS CÓDIGOS IATA NO SON VÁLIDOS O NO EXISTEN EN EL SISTEMA";
		public const string ERRGEN07 = "LA CONSULTA NO RETORNO DATOS";
		public const string ERRGEN08 = "TIMEOUT AL INTENTAR REALIZAR LA SOLICITUD HTTP";
		public const string CONTROLLER_RESPONSE = "**** CONTROLLER RESPONSE {0} ****";
		public const string ERRCATHCONTROLLER = "**** CONTROLLER RESPONSE CATCH {0} ****";


		public const string NO_DATOS = "NO SE RETORNARON DATOS";
		public const string ERROR_NO_CONTROLADO = "SE HA PRESENTADO UN ERROR NO CONTROLADO";
		public const string NULL_BODY_REQUEST = "EL CUERPO DEL REQUEST NO PUEDE SER NULO.";
		public const string ERROR_REQUEST = "LOS DATOS DEL REQUEST ENVIADO ES NULO O EL FORMATO ENVIADO ES INCORRECTO";
		public const string ERROR_API_EXTERNA = "ERROR EN EL API EXTERNA";
		public const string ERROR_OBTENER_DATOS = "ERROR PRESENTADO AL OBTENER LOS DATOS";




	}
}
