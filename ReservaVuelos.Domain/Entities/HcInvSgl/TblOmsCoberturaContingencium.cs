// <copyright file="TblOmsCoberturaContingencium.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcInvSgl
{
	[ExcludeFromCodeCoverage]
	public partial class TblOmsCoberturaContingencium
	{
		public int IdRedZona { get; set; }

		public int? IdZona { get; set; }

		public int? IdRed { get; set; }

		public int? IdDepto { get; set; }

		public int IdFlujo { get; set; }

		public string? Sigla { get; set; }

		public int? IdPromesaCliente { get; set; }

		public string? Promesa { get; set; }

		public byte? IdValorAtributo { get; set; }

		public string? ValorAtributo { get; set; }

		public int? IdCanal { get; set; }

		public int? IdTipoNodoInicial { get; set; }

		public string? CodigoInternoInicial { get; set; }

		public long? NumberInternoInicial { get; set; }

		public long? IdNodoInicial { get; set; }

		public int? IdTipoNodoFinal { get; set; }

		public string? CodigoInternoFinal { get; set; }

		public long? NumberInternoFinal { get; set; }

		public long? IdNodoFinal { get; set; }

		public int? IdCiudad { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public string? UsuarioCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string? UsuarioModificacion { get; set; }
	}
}
