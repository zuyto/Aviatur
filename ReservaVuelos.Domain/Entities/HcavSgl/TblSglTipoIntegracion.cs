// <copyright file="TblSglTipoIntegracion.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcavSgl
{
	[ExcludeFromCodeCoverage]
	public partial class TblSglTipoIntegracion
	{
		public int IdTipoIntegracion { get; set; }

		public string Descripcion { get; set; } = null!;

		public decimal? IdSqlIntegracion { get; set; }

		public decimal? IdSqlActualizacion { get; set; }

		public byte NumMaxIntentos { get; set; }

		public decimal Activo { get; set; }

		public string UsrCreacion { get; set; } = null!;

		public DateTime FechaCreacion { get; set; }

		public string? UsrModificacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public decimal? IdRuteador { get; set; }

		public string? NombreWebService { get; set; }

		public string? Endpoint { get; set; }

		public decimal? IdAplicacion { get; set; }
	}
}
