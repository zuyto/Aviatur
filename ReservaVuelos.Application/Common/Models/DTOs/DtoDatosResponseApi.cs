// <copyright file="DtoDatosResponseApi.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Application.Common.Models.DTOs
{
	[ExcludeFromCodeCoverage]
	public class DtoDatosResponseApi
	{
		public string Id { get; set; }
		public string Gmt { get; set; }
		public string Airport_Id { get; set; }
		public string Iata_Code { get; set; }
		public string City_Iata_Code { get; set; }
		public string Icao_Code { get; set; }
		public string Country_Iso2 { get; set; }
		public string Geoname_Id { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Airport_Name { get; set; }
		public string Country_Name { get; set; }
		public string Phone_Number { get; set; }
		public string Timezone { get; set; }
	}
}
