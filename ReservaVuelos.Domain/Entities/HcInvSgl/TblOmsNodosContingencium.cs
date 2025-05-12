// <copyright file="TblOmsNodosContingencium.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcInvSgl
{
	[ExcludeFromCodeCoverage]
	public partial class TblOmsNodosContingencium
	{
		public long? OrigenNumber { get; set; }

		public long? OrgLvlChild { get; set; }

		public byte? IdTipoNodo { get; set; }

		public int? IdNodo { get; set; }

		public int? IdCiudad { get; set; }

		public string? Ciudad { get; set; }

		public int? IdDepto { get; set; }

		public string? Departamento { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public string? UsuarioCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string? UsuarioModificacion { get; set; }
	}
}
