// <copyright file="HcInvSglDbContext.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using ReservaVuelos.Domain.Entities.HcInvSgl;

namespace ReservaVuelos.Infrastructure.Context
{
	[ExcludeFromCodeCoverage]
	public partial class HcInvSglDbContext : DbContext
	{
		public HcInvSglDbContext()
		{
		}

		public HcInvSglDbContext(DbContextOptions<HcInvSglDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<TblOmsCoberturaContingencium> TblOmsCoberturaContingencia { get; set; }

		public virtual DbSet<TblOmsNodosContingencium> TblOmsNodosContingencia { get; set; }

		public virtual DbSet<TblOmsParametrosContingencium> TblOmsParametrosContingencia { get; set; }

		public virtual DbSet<TblOmsProductosContingencium> TblOmsProductosContingencia { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasDefaultSchema("SGL")
				.UseCollation("USING_NLS_COMP");

			modelBuilder.Entity<TblOmsCoberturaContingencium>(entity =>
			{
				entity
					.HasNoKey()
					.ToTable("TBL_OMS_COBERTURA_CONTINGENCIA");

				entity.HasIndex(e => new { e.IdValorAtributo, e.IdZona, e.IdCanal }, "IDX_BASE_COB_DOM_IDVA_ZO_CA2");

				entity.HasIndex(e => new { e.IdZona, e.IdCanal }, "IDX_TBL_BCOBD_DEPTO_CANAL2");

				entity.HasIndex(e => e.IdRedZona, "IDX_TBL_BCOBD_ID_RED_ZONA2");

				entity.HasIndex(e => e.IdZona, "IDX_TBL_BCOBD_ID_ZONA2");

				entity.HasIndex(e => e.NumberInternoInicial, "IDX_TBL_BCOBD_NBR_INT_INICIAL2");

				entity.HasIndex(e => e.IdRed, "IDX_TBL_BCOBD_RED2");

				entity.HasIndex(e => new { e.IdZona, e.CodigoInternoInicial }, "IDX_TBL_BCOBD_ZONA_ND_INICIAL2");

				entity.HasIndex(e => new { e.IdZona, e.IdValorAtributo }, "INDX_TOBCD_IDZO_IDAT_IVAT2");

				entity.HasIndex(e => new { e.NumberInternoFinal, e.IdValorAtributo }, "INDX_TOBCD_NUIF_IDAT_IVAT2");

				entity.HasIndex(e => e.Promesa, "INDX_TOBCD_NUIN_HI2");

				entity.HasIndex(e => new { e.NumberInternoInicial, e.IdValorAtributo }, "INDX_TOBCD_NUIN_IDAT_IVAT2");

				entity.HasIndex(e => new { e.IdCanal, e.IdValorAtributo, e.IdZona }, "INDX_TOBC_ICAN_IATR_IVAT_IZON2");

				entity.Property(e => e.CodigoInternoFinal)
					.HasMaxLength(25)
					.IsUnicode(false)
					.HasColumnName("CODIGO_INTERNO_FINAL");
				entity.Property(e => e.CodigoInternoInicial)
					.HasMaxLength(25)
					.IsUnicode(false)
					.HasColumnName("CODIGO_INTERNO_INICIAL");
				entity.Property(e => e.FechaCreacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION");
				entity.Property(e => e.FechaModificacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_MODIFICACION");
				entity.Property(e => e.IdCanal)
					.HasPrecision(10)
					.HasColumnName("ID_CANAL");
				entity.Property(e => e.IdCiudad)
					.HasPrecision(10)
					.HasColumnName("ID_CIUDAD");
				entity.Property(e => e.IdDepto)
					.HasPrecision(10)
					.HasColumnName("ID_DEPTO");
				entity.Property(e => e.IdFlujo)
					.HasPrecision(10)
					.HasColumnName("ID_FLUJO");
				entity.Property(e => e.IdNodoFinal)
					.HasPrecision(12)
					.HasColumnName("ID_NODO_FINAL");
				entity.Property(e => e.IdNodoInicial)
					.HasPrecision(12)
					.HasColumnName("ID_NODO_INICIAL");
				entity.Property(e => e.IdPromesaCliente)
					.HasPrecision(10)
					.HasColumnName("ID_PROMESA_CLIENTE");
				entity.Property(e => e.IdRed)
					.HasPrecision(10)
					.HasColumnName("ID_RED");
				entity.Property(e => e.IdRedZona)
					.HasPrecision(10)
					.HasColumnName("ID_RED_ZONA");
				entity.Property(e => e.IdTipoNodoFinal)
					.HasPrecision(10)
					.HasColumnName("ID_TIPO_NODO_FINAL");
				entity.Property(e => e.IdTipoNodoInicial)
					.HasPrecision(10)
					.HasColumnName("ID_TIPO_NODO_INICIAL");
				entity.Property(e => e.IdValorAtributo)
					.HasPrecision(2)
					.HasColumnName("ID_VALOR_ATRIBUTO");
				entity.Property(e => e.IdZona)
					.HasPrecision(10)
					.HasColumnName("ID_ZONA");
				entity.Property(e => e.NumberInternoFinal)
					.HasPrecision(12)
					.HasColumnName("NUMBER_INTERNO_FINAL");
				entity.Property(e => e.NumberInternoInicial)
					.HasPrecision(12)
					.HasColumnName("NUMBER_INTERNO_INICIAL");
				entity.Property(e => e.Promesa)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("PROMESA");
				entity.Property(e => e.Sigla)
					.HasMaxLength(25)
					.IsUnicode(false)
					.HasColumnName("SIGLA");
				entity.Property(e => e.UsuarioCreacion)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("USUARIO_CREACION");
				entity.Property(e => e.UsuarioModificacion)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("USUARIO_MODIFICACION");
				entity.Property(e => e.ValorAtributo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("VALOR_ATRIBUTO");
			});

			modelBuilder.Entity<TblOmsNodosContingencium>(entity =>
			{
				entity
					.HasNoKey()
					.ToTable("TBL_OMS_NODOS_CONTINGENCIA");

				entity.Property(e => e.Ciudad)
					.HasMaxLength(200)
					.IsUnicode(false)
					.HasColumnName("CIUDAD");
				entity.Property(e => e.Departamento)
					.HasMaxLength(200)
					.IsUnicode(false)
					.HasColumnName("DEPARTAMENTO");
				entity.Property(e => e.FechaCreacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION");
				entity.Property(e => e.FechaModificacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_MODIFICACION");
				entity.Property(e => e.IdCiudad)
					.HasPrecision(10)
					.HasColumnName("ID_CIUDAD");
				entity.Property(e => e.IdDepto)
					.HasPrecision(10)
					.HasColumnName("ID_DEPTO");
				entity.Property(e => e.IdNodo)
					.HasPrecision(10)
					.HasColumnName("ID_NODO");
				entity.Property(e => e.IdTipoNodo)
					.HasPrecision(2)
					.HasColumnName("ID_TIPO_NODO");
				entity.Property(e => e.OrgLvlChild)
					.HasPrecision(12)
					.HasColumnName("ORG_LVL_CHILD");
				entity.Property(e => e.OrigenNumber)
					.HasPrecision(12)
					.HasColumnName("ORIGEN_NUMBER");
				entity.Property(e => e.UsuarioCreacion)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("USUARIO_CREACION");
				entity.Property(e => e.UsuarioModificacion)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("USUARIO_MODIFICACION");
			});

			modelBuilder.Entity<TblOmsParametrosContingencium>(entity =>
			{
				entity
					.HasNoKey()
					.ToTable("TBL_OMS_PARAMETROS_CONTINGENCIA");

				entity.Property(e => e.IdParametro)
					.HasColumnType("NUMBER(38)")
					.HasColumnName("ID_PARAMETRO");
				entity.Property(e => e.Nombre)
					.HasMaxLength(200)
					.IsUnicode(false)
					.HasColumnName("NOMBRE");
				entity.Property(e => e.Valor)
					.HasPrecision(15)
					.HasColumnName("VALOR");
			});

			modelBuilder.Entity<TblOmsProductosContingencium>(entity =>
			{
				entity.HasKey(e => new { e.PrdLvlChild, e.IdNodo }).HasName("PK_PRD_NODO");

				entity.ToTable("TBL_OMS_PRODUCTOS_CONTINGENCIA");

				entity.HasIndex(e => new { e.PrdLvlChild, e.OrgLvlChild }, "IDX_PRD_ORG_CHILD");

				entity.Property(e => e.PrdLvlChild)
					.HasPrecision(12)
					.HasColumnName("PRD_LVL_CHILD");
				entity.Property(e => e.IdNodo)
					.HasPrecision(10)
					.HasColumnName("ID_NODO");
				entity.Property(e => e.FechaCreacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION");
				entity.Property(e => e.FechaModificacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_MODIFICACION");
				entity.Property(e => e.IdTipoNodo)
					.HasPrecision(2)
					.HasColumnName("ID_TIPO_NODO");
				entity.Property(e => e.IdValorAtributo)
					.HasPrecision(10)
					.HasColumnName("ID_VALOR_ATRIBUTO");
				entity.Property(e => e.OrgLvlChild)
					.HasPrecision(12)
					.HasColumnName("ORG_LVL_CHILD");
				entity.Property(e => e.OrigenNumber)
					.HasPrecision(12)
					.HasColumnName("ORIGEN_NUMBER");
				entity.Property(e => e.PrdLvlNumber)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("PRD_LVL_NUMBER");
				entity.Property(e => e.UsuarioCreacion)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("USUARIO_CREACION");
				entity.Property(e => e.UsuarioModificacion)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("USUARIO_MODIFICACION");
			});

		}

	}
}
