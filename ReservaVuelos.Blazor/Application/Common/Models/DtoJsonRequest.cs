// <copyright file="DtoJsonRequest.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Blazor.Application.Common.Models
{
	[ExcludeFromCodeCoverage]
	public class DtoJsonRequest
	{
		public string Cliente { get; set; }
		public string Origen { get; set; }
		public string Destino { get; set; }
		public DateTime FechaSalida { get; set; }
	}
}
