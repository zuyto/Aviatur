// <copyright file="ReservaVuelosDbContext.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using ReservaVuelos.Domain.Entities.ReservaVuelos;

namespace ReservaVuelos.Infrastructure.Context;

[ExcludeFromCodeCoverage]
public partial class ReservaVuelosDbContext : DbContext
{
	public ReservaVuelosDbContext()
	{
	}

	public ReservaVuelosDbContext(DbContextOptions<ReservaVuelosDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Reserva> Reservas { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Reserva>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Reservas__3214EC073D0FE3EE");

			entity.HasIndex(e => e.CodigoReserva, "IX_Reservas_CodigoReserva").IsUnique();

			entity.HasIndex(e => new { e.FechaSalida, e.Origen }, "IX_Reservas_FechaOrigen");

			entity.HasIndex(e => e.FechaSalida, "IX_Reservas_FechaSalida");

			entity.HasIndex(e => new { e.Origen, e.Destino }, "IX_Reservas_OrigenDestino");

			entity.Property(e => e.Cliente).HasMaxLength(100);
			entity.Property(e => e.CodigoReserva).HasMaxLength(20);
			entity.Property(e => e.Destino).HasMaxLength(3);
			entity.Property(e => e.DestinoCiudad).HasMaxLength(100);
			entity.Property(e => e.Estado)
				.HasMaxLength(20)
				.HasDefaultValue("Pendiente");
			entity.Property(e => e.Origen).HasMaxLength(3);
			entity.Property(e => e.OrigenCiudad).HasMaxLength(100);
		});


	}


}
