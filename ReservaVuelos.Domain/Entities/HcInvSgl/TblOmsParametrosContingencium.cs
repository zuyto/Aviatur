// <copyright file="TblOmsParametrosContingencium.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcInvSgl
{
	[ExcludeFromCodeCoverage]
	public partial class TblOmsParametrosContingencium
	{
		public decimal? IdParametro { get; set; }

		public string? Nombre { get; set; }

		public long? Valor { get; set; }
	}
}
