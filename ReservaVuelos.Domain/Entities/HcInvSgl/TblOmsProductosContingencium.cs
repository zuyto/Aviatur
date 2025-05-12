// <copyright file="TblOmsProductosContingencium.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcInvSgl
{
	[ExcludeFromCodeCoverage]
	public partial class TblOmsProductosContingencium
	{
		public long PrdLvlChild { get; set; }

		public string PrdLvlNumber { get; set; } = null!;

		public long? OrigenNumber { get; set; }

		public long? OrgLvlChild { get; set; }

		public byte? IdTipoNodo { get; set; }

		public int IdNodo { get; set; }

		public int? IdValorAtributo { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public string? UsuarioCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string? UsuarioModificacion { get; set; }
	}
}
