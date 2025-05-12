// <copyright file="TblSglIntegracion.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcavSgl
{
	[ExcludeFromCodeCoverage]
	public partial class TblSglIntegracion
	{
		public int IdIntegracion { get; set; }

		public int IdTipoIntegracion { get; set; }

		public string? CodigoInterno { get; set; }

		public short IdEstadoIntegracion { get; set; }

		public string? Mensaje { get; set; }

		public decimal? IdEstadoProceso { get; set; }

		public byte NumIntentos { get; set; }

		public string UsrCreacion { get; set; } = null!;

		public DateTime FechaCreacion { get; set; }

		public string? UsrModificacion { get; set; }

		public DateTime? FechaModificacion { get; set; }
	}
}
