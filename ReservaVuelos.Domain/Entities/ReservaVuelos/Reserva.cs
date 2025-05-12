// <copyright file="Reserva.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.ReservaVuelos;

[ExcludeFromCodeCoverage]
public partial class Reserva
{
	public int Id { get; set; }

	public string? CodigoReserva { get; set; } = Guid.NewGuid().ToString("N")[..10].ToUpper();

	public string? Cliente { get; set; }

	public string? Origen { get; set; }

	public string? Destino { get; set; }

	public string? OrigenCiudad { get; set; }

	public string? DestinoCiudad { get; set; }

	public DateOnly? FechaSalida { get; set; }

	public string? Estado { get; set; }
}
