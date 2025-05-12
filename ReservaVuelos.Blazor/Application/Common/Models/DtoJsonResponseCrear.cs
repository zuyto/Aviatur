// <copyright file="DtoJsonResponseCrear.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Blazor.Application.Common.Models
{
	[ExcludeFromCodeCoverage]
	public class DtoJsonResponseCrear
	{
		public string CodigoReserva { get; set; }
		public string Mensaje { get; set; }
	}
}
