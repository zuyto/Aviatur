// <copyright file="DtoJsonResponseCrear.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Application.Common.Models.DTOs
{
	[ExcludeFromCodeCoverage]
	public class DtoJsonResponseCrear
	{
		public string? Mensaje { get; set; }
		public string? Codigo { get; set; }
	}
}
