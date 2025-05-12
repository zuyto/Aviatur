// <copyright file="DtoJsonResponseGet.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using ReservaVuelos.Domain.Entities.ReservaVuelos;

namespace ReservaVuelos.Application.Common.Models.DTOs
{
	[ExcludeFromCodeCoverage]
	public class DtoJsonResponseGet
	{
		public List<Reserva>? Reserva { get; set; }
	}
}
