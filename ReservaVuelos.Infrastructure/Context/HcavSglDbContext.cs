// <copyright file="HcavSglDbContext.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using ReservaVuelos.Domain.Entities.HcavSgl;

namespace ReservaVuelos.Infrastructure.Context
{
	[ExcludeFromCodeCoverage]
	public partial class HcavSglDbContext : DbContext
	{
		public HcavSglDbContext()
		{
		}

		public HcavSglDbContext(DbContextOptions<HcavSglDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<TblSglIntegracion> TblSglIntegracions { get; set; }

		public virtual DbSet<TblTraceEstadoConsultum> TblTraceEstadoConsulta { get; set; }

		public virtual DbSet<TblUnigisPedido> TblUnigisPedidos { get; set; }

		public virtual DbSet<TblSglTipoIntegracion> TblSglTipoIntegracions { get; set; }

		public virtual DbSet<Npedido> Npedidos { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasDefaultSchema("SGL")
				.UseCollation("USING_NLS_COMP");

			modelBuilder.Entity<TblSglIntegracion>(entity =>
			{
				entity.HasKey(e => e.IdIntegracion).HasName("PK_TBL_SGL_INTEGRACION_1");

				entity.ToTable("TBL_SGL_INTEGRACION");

				entity.HasIndex(e => e.CodigoInterno, "IDX_INTEGRA_COD_INTERNO_1");

				entity.HasIndex(e => new { e.IdTipoIntegracion, e.IdEstadoIntegracion }, "IDX_INTEGRA_COD_INTERNO_ESTA_1");

				entity.HasIndex(e => new { e.IdEstadoIntegracion, e.IdTipoIntegracion }, "IDX_INTEGRA_COD_INTERNO_TIPO_1");

				entity.HasIndex(e => new { e.CodigoInterno, e.IdTipoIntegracion }, "IDX_INTEGRA_COD_INTERNO_TIPO_I");

				entity.HasIndex(e => new { e.IdEstadoIntegracion, e.IdTipoIntegracion, e.FechaCreacion }, "IDX_INTEGRA_ESTA_INT_FECHA_1");

				entity.HasIndex(e => new { e.IdTipoIntegracion, e.CodigoInterno }, "IDX_INTEGRA_TIPO_COD_INTE_1");

				entity.HasIndex(e => new { e.IdTipoIntegracion, e.FechaCreacion }, "IDX_SGL_INTEGRACION_IDTIPO_FEC_1");

				entity.Property(e => e.IdIntegracion)
					.HasPrecision(10)
					.HasColumnName("ID_INTEGRACION");
				entity.Property(e => e.CodigoInterno)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedOnAdd()
					.HasColumnName("CODIGO_INTERNO");
				entity.Property(e => e.FechaCreacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION");
				entity.Property(e => e.FechaModificacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_MODIFICACION");
				entity.Property(e => e.IdEstadoIntegracion)
					.HasPrecision(5)

					.HasDefaultValueSql("0                     ")
					.HasColumnName("ID_ESTADO_INTEGRACION");
				entity.Property(e => e.IdEstadoProceso)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_ESTADO_PROCESO");
				entity.Property(e => e.IdTipoIntegracion)
					.HasPrecision(10)

					.HasColumnName("ID_TIPO_INTEGRACION");
				entity.Property(e => e.Mensaje)
					.HasColumnType("CLOB")
					.HasColumnName("MENSAJE");
				entity.Property(e => e.NumIntentos)
					.HasPrecision(2)

					.HasDefaultValueSql("0                     ")
					.HasColumnName("NUM_INTENTOS");
				entity.Property(e => e.UsrCreacion)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("USR_CREACION");
				entity.Property(e => e.UsrModificacion)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("USR_MODIFICACION");
			});

			modelBuilder.Entity<TblTraceEstadoConsultum>(entity =>
			{
				entity.HasKey(e => e.IdTraceEstado).HasName("TBL_TRACE_ESTADO_CONSULTA_PK");

				entity.ToTable("TBL_TRACE_ESTADO_CONSULTA");

				entity.HasIndex(e => e.RefDocumento, "IDX_TBL_TRACE_REF");

				entity.HasIndex(e => e.Sticker, "IDX_TBL_TRACE_STICKER");

				entity.Property(e => e.IdTraceEstado)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_TRACE_ESTADO");
				entity.Property(e => e.Apikey)
					.HasColumnType("NUMBER")
					.HasColumnName("APIKEY");
				entity.Property(e => e.FechaCreacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION");
				entity.Property(e => e.FechaModificacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_MODIFICACION");
				entity.Property(e => e.IdParada)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_PARADA");
				entity.Property(e => e.RefDocumento)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasColumnName("REF_DOCUMENTO");
				entity.Property(e => e.RefField1Num)
					.HasColumnType("NUMBER")
					.HasColumnName("REF_FIELD_1_NUM");
				entity.Property(e => e.RefField1Var)
					.HasMaxLength(500)
					.IsUnicode(false)
					.HasColumnName("REF_FIELD_1_VAR");
				entity.Property(e => e.RefField2Num)
					.HasColumnType("NUMBER")
					.HasColumnName("REF_FIELD_2_NUM");
				entity.Property(e => e.RefField2Var)
					.HasMaxLength(500)
					.IsUnicode(false)
					.HasColumnName("REF_FIELD_2_VAR");
				entity.Property(e => e.RefField3Num)
					.HasColumnType("NUMBER")
					.HasColumnName("REF_FIELD_3_NUM");
				entity.Property(e => e.RefField3Var)
					.HasMaxLength(500)
					.IsUnicode(false)
					.HasColumnName("REF_FIELD_3_VAR");
				entity.Property(e => e.Sticker)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasColumnName("STICKER");
				entity.Property(e => e.UsuarioCreacion)
					.HasMaxLength(200)
					.IsUnicode(false)
					.HasColumnName("USUARIO_CREACION");
				entity.Property(e => e.UsuarioModificacion)
					.HasMaxLength(200)
					.IsUnicode(false)
					.HasColumnName("USUARIO_MODIFICACION");
			});

			modelBuilder.Entity<TblUnigisPedido>(entity =>
			{
				entity.HasKey(e => e.IdPedidoSgl);

				entity.ToTable("TBL_UNIGIS_PEDIDO");

				entity.HasIndex(e => new { e.Destino, e.RefField1 }, "IDX_UNIGIS_PEDIDO_DEST");

				entity.HasIndex(e => new { e.FechaEntrega, e.RefDepositoSalida }, "IDX_UNIGIS_PEDIDO_FECDEP");

				entity.HasIndex(e => e.FechaCreacion, "IDX_UNIGIS_PEDIDO_FECHA_CREACI");

				entity.HasIndex(e => e.IdTipoIntegracion, "IDX_UNIGIS_PEDIDO_ID_TIPO_INTE");

				entity.HasIndex(e => e.RefDocumento, "IDX_UNIGIS_PEDIDO_REF_DOCUMENT");

				entity.HasIndex(e => e.RefDocumentoAdicional, "IDX_UNIGIS_PEDIDO_REF_DOC_ADIC");

				entity.HasIndex(e => new { e.RefField1, e.RefField2 }, "IDX_UNIGIS_PEDIDO_REF_FIELD");

				entity.HasIndex(e => e.Sticker, "IDX_UNIGIS_PEDIDO_STICKER");

				entity.HasIndex(e => new { e.IdTipoIntegracion, e.RefDocumento }, "IDX_UNIGIS_PEDIDO_TIPINT_REF");

				entity.Property(e => e.IdPedidoSgl)
					.ValueGeneratedOnAdd()
					.HasColumnType("NUMBER")
					.HasColumnName("ID_PEDIDO_SGL");
				entity.Property(e => e.AgruparItems)

					.HasColumnType("NUMBER")
					.HasColumnName("AGRUPAR_ITEMS");
				entity.Property(e => e.B2cpassword)
					.HasMaxLength(256)
					.IsUnicode(false)

					.HasColumnName("B2CPASSWORD");
				entity.Property(e => e.Barrio)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("BARRIO");
				entity.Property(e => e.BarrioNormalizado)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("BARRIO_NORMALIZADO");
				entity.Property(e => e.Bultos)

					.HasColumnType("NUMBER")
					.HasColumnName("BULTOS");
				entity.Property(e => e.Calle)
					.HasMaxLength(2000)
					.IsUnicode(false)

					.HasColumnName("CALLE");
				entity.Property(e => e.CalleNormalizada)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("CALLE_NORMALIZADA");
				entity.Property(e => e.Cantidad)

					.HasColumnType("NUMBER")
					.HasColumnName("CANTIDAD");
				entity.Property(e => e.CantidadReenvio)

					.HasColumnType("NUMBER")
					.HasColumnName("CANTIDAD_REENVIO");
				entity.Property(e => e.CargaExclusiva)

					.HasColumnType("NUMBER")
					.HasColumnName("CARGA_EXCLUSIVA");
				entity.Property(e => e.Categoria)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("CATEGORIA");
				entity.Property(e => e.CodigoOperacion)
					.HasMaxLength(60)
					.IsUnicode(false)

					.HasColumnName("CODIGO_OPERACION");
				entity.Property(e => e.CodigoPostal)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("CODIGO_POSTAL");
				entity.Property(e => e.CodigoPostalNormalizado)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("CODIGO_POSTAL_NORMALIZADO");
				entity.Property(e => e.CodigoSucursal)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("CODIGO_SUCURSAL");
				entity.Property(e => e.Color)

					.HasColumnType("NUMBER")
					.HasColumnName("COLOR");
				entity.Property(e => e.Contactado)

					.HasColumnType("NUMBER")
					.HasColumnName("CONTACTADO");
				entity.Property(e => e.Datetime1)

					.HasColumnType("DATE")
					.HasColumnName("DATETIME_1");
				entity.Property(e => e.Datetime2)

					.HasColumnType("DATE")
					.HasColumnName("DATETIME_2");
				entity.Property(e => e.Datetime3)

					.HasColumnType("DATE")
					.HasColumnName("DATETIME_3");
				entity.Property(e => e.Descripcion)
					.HasMaxLength(2000)
					.IsUnicode(false)

					.HasColumnName("DESCRIPCION");
				entity.Property(e => e.DescripcionDepositoLlegada)
					.HasMaxLength(60)
					.IsUnicode(false)

					.HasColumnName("DESCRIPCION_DEPOSITO_LLEGADA");
				entity.Property(e => e.DescripcionDepositoSalida)
					.HasMaxLength(60)
					.IsUnicode(false)

					.HasColumnName("DESCRIPCION_DEPOSITO_SALIDA");
				entity.Property(e => e.Destino)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("DESTINO");
				entity.Property(e => e.Direccion)
					.HasMaxLength(2000)
					.IsUnicode(false)

					.HasColumnName("DIRECCION");
				entity.Property(e => e.Distancia)

					.HasColumnType("NUMBER")
					.HasColumnName("DISTANCIA");
				entity.Property(e => e.DomicilioCodigoPostal)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("DOMICILIO_CODIGO_POSTAL");
				entity.Property(e => e.EdicionActiva)

					.HasColumnType("NUMBER")
					.HasColumnName("EDICION_ACTIVA");
				entity.Property(e => e.Eliminado)

					.HasColumnType("NUMBER")
					.HasColumnName("ELIMINADO");
				entity.Property(e => e.Email)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("EMAIL");
				entity.Property(e => e.EntreCalle)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("ENTRE_CALLE");
				entity.Property(e => e.EntreCalleNormalizada)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("ENTRE_CALLE_NORMALIZADA");
				entity.Property(e => e.Estado)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("ESTADO");
				entity.Property(e => e.FechaCreacion)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION");
				entity.Property(e => e.FechaCreacionUnigis)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION_UNIGIS");
				entity.Property(e => e.FechaEliminacion)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_ELIMINACION");
				entity.Property(e => e.FechaEntrega)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_ENTREGA");
				entity.Property(e => e.FechaEntregaOriginal)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_ENTREGA_ORIGINAL");
				entity.Property(e => e.FechaModificacion)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_MODIFICACION");
				entity.Property(e => e.FechaPedido)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_PEDIDO");
				entity.Property(e => e.FechaRecoleccion)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_RECOLECCION");
				entity.Property(e => e.FechaUltimaModificacion)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_ULTIMA_MODIFICACION");
				entity.Property(e => e.FechaUltimoEstado)

					.HasColumnType("DATE")
					.HasColumnName("FECHA_ULTIMO_ESTADO");
				entity.Property(e => e.FinHorario1)

					.HasColumnType("NUMBER")
					.HasColumnName("FIN_HORARIO1");
				entity.Property(e => e.FinHorario2)

					.HasColumnType("NUMBER")
					.HasColumnName("FIN_HORARIO2");
				entity.Property(e => e.FinHorarioRecoleccion1)

					.HasColumnType("NUMBER")
					.HasColumnName("FIN_HORARIO_RECOLECCION1");
				entity.Property(e => e.FinHorarioRecoleccion2)

					.HasColumnType("NUMBER")
					.HasColumnName("FIN_HORARIO_RECOLECCION2");
				entity.Property(e => e.Float1)

					.HasColumnType("NUMBER")
					.HasColumnName("FLOAT_1");
				entity.Property(e => e.Float2)

					.HasColumnType("NUMBER")
					.HasColumnName("FLOAT_2");
				entity.Property(e => e.Fulfillment)

					.HasColumnType("NUMBER(30,6)")
					.HasColumnName("FULFILLMENT");
				entity.Property(e => e.GrupoRutas)

					.HasColumnType("NUMBER")
					.HasColumnName("GRUPO_RUTAS");
				entity.Property(e => e.Icono)

					.HasColumnType("NUMBER")
					.HasColumnName("ICONO");
				entity.Property(e => e.IdAuditoriaEstado)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_AUDITORIA_ESTADO");
				entity.Property(e => e.IdCategoriaPedido)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_CATEGORIA_PEDIDO");
				entity.Property(e => e.IdCategoriaPedidoAdicional)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_CATEGORIA_PEDIDO_ADICIONAL");
				entity.Property(e => e.IdDomicilioOrden2)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_DOMICILIO_ORDEN2");
				entity.Property(e => e.IdEmpresa)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_EMPRESA");
				entity.Property(e => e.IdEstado)

					.HasDefaultValueSql("1")
					.HasColumnType("NUMBER")
					.HasColumnName("ID_ESTADO");
				entity.Property(e => e.IdEstadoPedido)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_ESTADO_PEDIDO");
				entity.Property(e => e.IdGrupo)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_GRUPO");
				entity.Property(e => e.IdImportacion)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_IMPORTACION");
				entity.Property(e => e.IdOperacion)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_OPERACION");
				entity.Property(e => e.IdPedidoUnigis)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_PEDIDO_UNIGIS");
				entity.Property(e => e.IdPrioridadPedido)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_PRIORIDAD_PEDIDO");
				entity.Property(e => e.IdSucursal)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_SUCURSAL");
				entity.Property(e => e.IdTipoCanal)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_TIPO_CANAL");
				entity.Property(e => e.IdTipoIntegracion)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_TIPO_INTEGRACION");
				entity.Property(e => e.IdTipoMercaderia)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_TIPO_MERCADERIA");
				entity.Property(e => e.IdTipoPedido)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_TIPO_PEDIDO");
				entity.Property(e => e.IdTipoUnidadContenedora)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_TIPO_UNIDAD_CONTENEDORA");
				entity.Property(e => e.IdTipoVerificacion)

					.HasColumnType("NUMBER")
					.HasColumnName("ID_TIPO_VERIFICACION");
				entity.Property(e => e.ImporteCosto)

					.HasColumnType("NUMBER(19,4)")
					.HasColumnName("IMPORTE_COSTO");
				entity.Property(e => e.InicioHorario1)

					.HasColumnType("NUMBER")
					.HasColumnName("INICIO_HORARIO1");
				entity.Property(e => e.InicioHorario2)

					.HasColumnType("NUMBER")
					.HasColumnName("INICIO_HORARIO2");
				entity.Property(e => e.InicioHorarioRecoleccion1)

					.HasColumnType("NUMBER")
					.HasColumnName("INICIO_HORARIO_RECOLECCION1");
				entity.Property(e => e.InicioHorarioRecoleccion2)

					.HasColumnType("NUMBER")
					.HasColumnName("INICIO_HORARIO_RECOLECCION2");
				entity.Property(e => e.Int1)

					.HasColumnType("NUMBER")
					.HasColumnName("INT_1");
				entity.Property(e => e.Int2)

					.HasColumnType("NUMBER")
					.HasColumnName("INT_2");
				entity.Property(e => e.Latitud)

					.HasColumnType("NUMBER")
					.HasColumnName("LATITUD");
				entity.Property(e => e.Localidad)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("LOCALIDAD");
				entity.Property(e => e.LocalidadNormalizada)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("LOCALIDAD_NORMALIZADA");
				entity.Property(e => e.Longitud)

					.HasColumnType("NUMBER")
					.HasColumnName("LONGITUD");
				entity.Property(e => e.Moneda)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("MONEDA");
				entity.Property(e => e.NumeroPuerta)
					.HasMaxLength(20)
					.IsUnicode(false)

					.HasColumnName("NUMERO_PUERTA");
				entity.Property(e => e.NumeroPuertaNormalizado)

					.HasColumnType("NUMBER")
					.HasColumnName("NUMERO_PUERTA_NORMALIZADO");
				entity.Property(e => e.Observaciones)
					.HasMaxLength(2000)
					.IsUnicode(false)

					.HasColumnName("OBSERVACIONES");
				entity.Property(e => e.Origen)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("ORIGEN");
				entity.Property(e => e.OrigenGeocodificacion)

					.HasColumnType("NUMBER")
					.HasColumnName("ORIGEN_GEOCODIFICACION");
				entity.Property(e => e.Pais)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("PAIS");
				entity.Property(e => e.PaisNormalizado)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("PAIS_NORMALIZADO");
				entity.Property(e => e.Pallets)

					.HasColumnType("NUMBER")
					.HasColumnName("PALLETS");
				entity.Property(e => e.Partido)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("PARTIDO");
				entity.Property(e => e.PartidoNormalizado)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("PARTIDO_NORMALIZADO");
				entity.Property(e => e.Peso)

					.HasColumnType("NUMBER")
					.HasColumnName("PESO");
				entity.Property(e => e.Provincia)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("PROVINCIA");
				entity.Property(e => e.ProvinciaNormalizada)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("PROVINCIA_NORMALIZADA");
				entity.Property(e => e.RazonSocial)
					.HasMaxLength(1000)
					.IsUnicode(false)

					.HasColumnName("RAZON_SOCIAL");
				entity.Property(e => e.RefCliente)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("REF_CLIENTE");
				entity.Property(e => e.RefDepositoLlegada)

					.HasColumnType("NUMBER")
					.HasColumnName("REF_DEPOSITO_LLEGADA");
				entity.Property(e => e.RefDepositoSalida)

					.HasColumnType("NUMBER")
					.HasColumnName("REF_DEPOSITO_SALIDA");
				entity.Property(e => e.RefDocumento)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("REF_DOCUMENTO");
				entity.Property(e => e.RefDocumentoAdicional)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("REF_DOCUMENTO_ADICIONAL");
				entity.Property(e => e.RefField0)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_0");
				entity.Property(e => e.RefField1)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_1");
				entity.Property(e => e.RefField2)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_2");
				entity.Property(e => e.RefField3)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_3");
				entity.Property(e => e.RefField4)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_4");
				entity.Property(e => e.RefField5)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_5");
				entity.Property(e => e.RefField6)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_6");
				entity.Property(e => e.RefField7)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_7");
				entity.Property(e => e.RefField8)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_8");
				entity.Property(e => e.RefField9)
					.HasMaxLength(200)
					.IsUnicode(false)

					.HasColumnName("REF_FIELD_9");
				entity.Property(e => e.RequiereAbasto)

					.HasColumnType("NUMBER")
					.HasColumnName("REQUIERE_ABASTO");
				entity.Property(e => e.RequiereTurno)

					.HasColumnType("NUMBER")
					.HasColumnName("REQUIERE_TURNO");
				entity.Property(e => e.Sticker)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("STICKER");
				entity.Property(e => e.Telefono)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("TELEFONO");
				entity.Property(e => e.Telefono2)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("TELEFONO2");
				entity.Property(e => e.Telefono3)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("TELEFONO3");
				entity.Property(e => e.TiempoEspera)

					.HasColumnType("NUMBER")
					.HasColumnName("TIEMPO_ESPERA");
				entity.Property(e => e.TiempoMaximoEstadoExcedido)

					.HasColumnType("NUMBER")
					.HasColumnName("TIEMPO_MAXIMO_ESTADO_EXCEDIDO");
				entity.Property(e => e.TipoGeocodificacion)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("TIPO_GEOCODIFICACION");
				entity.Property(e => e.TipoPedido)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("TIPO_PEDIDO");
				entity.Property(e => e.UltimaVisita)

					.HasColumnType("NUMBER")
					.HasColumnName("ULTIMA_VISITA");
				entity.Property(e => e.Unidades)

					.HasColumnType("NUMBER")
					.HasColumnName("UNIDADES");
				entity.Property(e => e.Urlb2c)
					.HasMaxLength(3000)
					.IsUnicode(false)

					.HasColumnName("URLB2C");
				entity.Property(e => e.UsarProductos)

					.HasColumnType("NUMBER")
					.HasColumnName("USAR_PRODUCTOS");
				entity.Property(e => e.UsrCreacion)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("USR_CREACION");
				entity.Property(e => e.UsrModificacion)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("USR_MODIFICACION");
				entity.Property(e => e.ValorCorte)

					.HasColumnType("NUMBER")
					.HasColumnName("VALOR_CORTE");
				entity.Property(e => e.ValorDeclarado)

					.HasColumnType("NUMBER(30,6)")
					.HasColumnName("VALOR_DECLARADO");
				entity.Property(e => e.Varchar1)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_1");
				entity.Property(e => e.Varchar2)
					.HasMaxLength(100)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_2");
				entity.Property(e => e.Varchar3)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_3");
				entity.Property(e => e.Varchar4)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_4");
				entity.Property(e => e.Varchar5)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_5");
				entity.Property(e => e.Varchar6)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_6");
				entity.Property(e => e.Varchar7)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_7");
				entity.Property(e => e.Varchar8)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_8");
				entity.Property(e => e.Varchar9)
					.HasMaxLength(50)
					.IsUnicode(false)

					.HasColumnName("VARCHAR_9");
				entity.Property(e => e.VigenciaDesde)

					.HasColumnType("DATE")
					.HasColumnName("VIGENCIA_DESDE");
				entity.Property(e => e.VigenciaHasta)

					.HasColumnType("DATE")
					.HasColumnName("VIGENCIA_HASTA");
				entity.Property(e => e.Volumen)

					.HasColumnType("NUMBER")
					.HasColumnName("VOLUMEN");
				entity.Property(e => e.VolumenAdicional)

					.HasColumnType("NUMBER(30,6)")
					.HasColumnName("VOLUMEN_ADICIONAL");
			});

			modelBuilder.Entity<TblSglTipoIntegracion>(entity =>
			{
				entity.HasKey(e => e.IdTipoIntegracion).HasName("PK_SGL_TIPO_INTEGRACION");

				entity.ToTable("TBL_SGL_TIPO_INTEGRACION");

				entity.HasIndex(e => e.Descripcion, "IDX_TIPO_INTEGRACION_DESCRI");

				entity.Property(e => e.IdTipoIntegracion)
					.HasPrecision(10)
					.ValueGeneratedNever()
					.HasColumnName("ID_TIPO_INTEGRACION");
				entity.Property(e => e.Activo)
					.HasDefaultValueSql("'1' ")
					.HasColumnType("NUMBER")
					.HasColumnName("ACTIVO");
				entity.Property(e => e.Descripcion)
					.HasMaxLength(200)
					.IsUnicode(false)
					.HasColumnName("DESCRIPCION");
				entity.Property(e => e.Endpoint)
					.HasMaxLength(1000)
					.IsUnicode(false)
					.HasColumnName("ENDPOINT");
				entity.Property(e => e.FechaCreacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREACION");
				entity.Property(e => e.FechaModificacion)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_MODIFICACION");
				entity.Property(e => e.IdAplicacion)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_APLICACION");
				entity.Property(e => e.IdRuteador)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_RUTEADOR");
				entity.Property(e => e.IdSqlActualizacion)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_SQL_ACTUALIZACION");
				entity.Property(e => e.IdSqlIntegracion)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_SQL_INTEGRACION");
				entity.Property(e => e.NombreWebService)
					.HasMaxLength(200)
					.IsUnicode(false)
					.HasColumnName("NOMBRE_WEB_SERVICE");
				entity.Property(e => e.NumMaxIntentos)
					.HasPrecision(2)
					.HasDefaultValueSql("0 ")
					.HasColumnName("NUM_MAX_INTENTOS");
				entity.Property(e => e.UsrCreacion)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("USR_CREACION");
				entity.Property(e => e.UsrModificacion)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("USR_MODIFICACION");
			});

			modelBuilder.Entity<Npedido>(entity =>
			{
				entity.HasKey(e => new { e.Sticker, e.Consecutivo, e.IdAlmacen });

				entity.ToTable("NPEDIDO", "SAPS");

				entity.HasIndex(e => new { e.IdEstado, e.IdAlmEnt, e.IdTipoEntrega, e.IdTipoNotaPedido, e.Sticker }, "IDX4_NPEDIDO");

				entity.HasIndex(e => e.FechaCrea, "IDX5_NPEDIDO");

				entity.HasIndex(e => new { e.IdAlmEnt, e.IdAlmacen }, "IDX6_NPEDIDO");

				entity.HasIndex(e => e.IdDireccion, "IDX7_NPEDIDO");

				entity.HasIndex(e => new { e.IdCotizacion, e.IdAlmacen }, "IDX8_NPEDIDO");

				entity.HasIndex(e => new { e.FechaPago, e.Transaccion }, "IDXREPO_NPEDIDO");

				entity.HasIndex(e => new { e.IdRecaudo, e.Sticker }, "IDX_ID_RECAUDO");

				entity.HasIndex(e => e.IdAlmacen, "IDX_NPEDIDO_ALMACEN_FK1");

				entity.HasIndex(e => new { e.IdAlmEnt, e.FechaCrea }, "IDX_NPEDIDO_ALM_ENT_FECHA_CREA");

				entity.HasIndex(e => e.IdCliente, "IDX_NPEDIDO_CLIENTE_FK1");

				entity.HasIndex(e => e.Cedula, "IDX_NPEDIDO_EMPLEADO_FK1");

				entity.HasIndex(e => new { e.IdEstado, e.FechaEntrega, e.Sticker }, "IDX_NPEDIDO_ES_FE_ST");

				entity.HasIndex(e => e.IdRed, "IDX_NPEDIDO_ID_RED");

				entity.HasIndex(e => new { e.Relacion, e.FechaCrea }, "IDX_NPEDIDO_RELAC_FECHA_CREA");

				entity.HasIndex(e => e.IdTipoEntrega, "IDX_NPEDIDO_TIPO_ENTREGA_FK1");

				entity.HasIndex(e => e.IdTipoFlete, "IDX_NPEDIDO_TIPO_FLE_FK1");

				entity.HasIndex(e => new { e.Sticker, e.IdAlmEnt }, "INDX_NPED_IDAE");

				entity.HasIndex(e => new { e.IdEstado, e.PagoValido, e.Origen, e.FechaCrea, e.Sticker, e.IdTipoNotaPedido }, "INDX_NPED_IDES_PAVA_ORIG_FECR");

				entity.HasIndex(e => new { e.IdTipoEntrega, e.FechaCrea }, "INDX_NPED_IDTE_FECR");

				entity.HasIndex(e => e.Origen, "INDX_NPED_ORIG");

				entity.HasIndex(e => new { e.Relacion, e.IdTipoEntrega, e.FechaCrea, e.IdHorario, e.Flujo, e.IdEstado, e.FechaPago }, "INDX_NPED_RELA_IDTE_FECR_IDHF");

				entity.HasIndex(e => new { e.Sticker, e.FechaCrea, e.IdTipoNotaPedido, e.IdEstado, e.Origen, e.PagoValido }, "INDX_NPED_STIC_FECR_ITNP_IEOR");

				entity.HasIndex(e => e.Categoria, "INDX_NP_CATEGORIA");

				entity.HasIndex(e => e.FechaEntrega, "INDX_NP_FECHA_ENTREGA");

				entity.HasIndex(e => new { e.IdEstado, e.IdAlmEnt, e.IdTipoEntrega, e.IdTipoNotaPedido }, "NP_ALT001");

				entity.HasIndex(e => e.Sticker, "PK2_NPEDIDO").IsUnique();

				entity.HasIndex(e => new { e.Consecutivo, e.IdAlmacen }, "PK3_NPEDIDO");

				entity.Property(e => e.Sticker)
					.HasMaxLength(22)
					.IsUnicode(false)
					.HasColumnName("STICKER");
				entity.Property(e => e.Consecutivo)
					.HasColumnType("NUMBER")
					.HasColumnName("CONSECUTIVO");
				entity.Property(e => e.IdAlmacen)
					.HasPrecision(5)
					.HasColumnName("ID_ALMACEN");
				entity.Property(e => e.ApellidosCliente)
					.HasMaxLength(60)
					.IsUnicode(false)
					.HasColumnName("APELLIDOS_CLIENTE");
				entity.Property(e => e.BaseIva)
					.HasPrecision(12)
					.HasColumnName("BASE_IVA");
				entity.Property(e => e.BaseIvaPos)
					.HasPrecision(12)
					.HasColumnName("BASE_IVA_POS");
				entity.Property(e => e.Categoria)
					.HasMaxLength(10)
					.IsUnicode(false)
					.HasColumnName("CATEGORIA");
				entity.Property(e => e.Cedula)
					.HasPrecision(12)
					.HasColumnName("CEDULA");
				entity.Property(e => e.CedulaAut)
					.HasPrecision(12)
					.HasColumnName("CEDULA_AUT");
				entity.Property(e => e.CodAutorizacion)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("COD_AUTORIZACION");
				entity.Property(e => e.CodigoReserva)
					.HasPrecision(12)
					.HasColumnName("CODIGO_RESERVA");
				entity.Property(e => e.ConsecInstal)
					.HasPrecision(6)
					.HasColumnName("CONSEC_INSTAL");
				entity.Property(e => e.ConsecutivoVisita)
					.HasPrecision(6)
					.HasColumnName("CONSECUTIVO_VISITA");
				entity.Property(e => e.ContactoEfec)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N' ")
					.IsFixedLength()
					.HasColumnName("CONTACTO_EFEC");
				entity.Property(e => e.DescEmpleado)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N' ")
					.HasColumnName("DESC_EMPLEADO");
				entity.Property(e => e.DirEntrega)
					.HasMaxLength(250)
					.IsUnicode(false)
					.HasColumnName("DIR_ENTREGA");
				entity.Property(e => e.DireccionEjeX)
					.HasColumnType("NUMBER")
					.HasColumnName("DIRECCION_EJE_X");
				entity.Property(e => e.DireccionEjeY)
					.HasColumnType("NUMBER")
					.HasColumnName("DIRECCION_EJE_Y");
				entity.Property(e => e.FechaAlistamiento)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_ALISTAMIENTO");
				entity.Property(e => e.FechaAlistamientoOms)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_ALISTAMIENTO_OMS");
				entity.Property(e => e.FechaCamb)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CAMB");
				entity.Property(e => e.FechaCrea)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_CREA");
				entity.Property(e => e.FechaEntrega)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_ENTREGA");
				entity.Property(e => e.FechaEnvio)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_ENVIO");
				entity.Property(e => e.FechaInicialEntrega)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_INICIAL_ENTREGA");
				entity.Property(e => e.FechaOriginalEntrega)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_ORIGINAL_ENTREGA");
				entity.Property(e => e.FechaPago)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_PAGO");
				entity.Property(e => e.FechaRealEnt)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_REAL_ENT");
				entity.Property(e => e.FechaRecogidaTransf)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_RECOGIDA_TRANSF");
				entity.Property(e => e.FechaTransito)
					.HasColumnType("DATE")
					.HasColumnName("FECHA_TRANSITO");
				entity.Property(e => e.Flujo)
					.HasMaxLength(25)
					.IsUnicode(false)
					.HasColumnName("FLUJO");
				entity.Property(e => e.Horario)
					.HasMaxLength(59)
					.IsUnicode(false)
					.HasColumnName("HORARIO");
				entity.Property(e => e.IdAlmEnt)
					.HasPrecision(5)
					.HasColumnName("ID_ALM_ENT");
				entity.Property(e => e.IdAlmTrns)
					.HasPrecision(5)
					.HasColumnName("ID_ALM_TRNS");
				entity.Property(e => e.IdAlmacenAlistamiento)
					.HasPrecision(10)
					.HasColumnName("ID_ALMACEN_ALISTAMIENTO");
				entity.Property(e => e.IdAlmacenCotiza)
					.HasPrecision(5)
					.HasColumnName("ID_ALMACEN_COTIZA");
				entity.Property(e => e.IdAlmacenPago)
					.HasPrecision(5)
					.HasColumnName("ID_ALMACEN_PAGO");
				entity.Property(e => e.IdAlmacenVisita)
					.HasPrecision(5)
					.HasColumnName("ID_ALMACEN_VISITA");
				entity.Property(e => e.IdBarrio)
					.HasPrecision(12)
					.HasColumnName("ID_BARRIO");
				entity.Property(e => e.IdCanalVenta)
					.HasPrecision(1)
					.HasColumnName("ID_CANAL_VENTA");
				entity.Property(e => e.IdCentroCosto)
					.HasMaxLength(10)
					.IsUnicode(false)
					.HasColumnName("ID_CENTRO_COSTO");
				entity.Property(e => e.IdCiudadRetiro)
					.HasPrecision(5)
					.HasColumnName("ID_CIUDAD_RETIRO");
				entity.Property(e => e.IdCliente)
					.HasPrecision(8)
					.HasColumnName("ID_CLIENTE");
				entity.Property(e => e.IdCotizacion)
					.HasPrecision(10)
					.HasColumnName("ID_COTIZACION");
				entity.Property(e => e.IdDireccion)
					.HasPrecision(9)
					.HasColumnName("ID_DIRECCION");
				entity.Property(e => e.IdEmpTransp)
					.HasPrecision(3)
					.HasColumnName("ID_EMP_TRANSP");
				entity.Property(e => e.IdEstado)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_ESTADO");
				entity.Property(e => e.IdFuenteInventario)
					.HasPrecision(10)
					.HasColumnName("ID_FUENTE_INVENTARIO");
				entity.Property(e => e.IdHorario)
					.HasMaxLength(10)
					.IsUnicode(false)
					.HasColumnName("ID_HORARIO");
				entity.Property(e => e.IdMensajeFalabella)
					.HasPrecision(6)
					.HasColumnName("ID_MENSAJE_FALABELLA");
				entity.Property(e => e.IdNivelServicio)
					.HasPrecision(4)
					.HasDefaultValueSql("0 ")
					.HasColumnName("ID_NIVEL_SERVICIO");
				entity.Property(e => e.IdPromesaCliente)
					.HasPrecision(2)
					.HasColumnName("ID_PROMESA_CLIENTE");
				entity.Property(e => e.IdRecaudo)
					.HasColumnType("NUMBER")
					.HasColumnName("ID_RECAUDO");
				entity.Property(e => e.IdRed)
					.HasPrecision(10)
					.HasColumnName("ID_RED");
				entity.Property(e => e.IdTendtype)
					.HasPrecision(2)
					.HasColumnName("ID_TENDTYPE");
				entity.Property(e => e.IdTipoEntrega)
					.HasPrecision(2)
					.HasColumnName("ID_TIPO_ENTREGA");
				entity.Property(e => e.IdTipoFlete)
					.HasPrecision(2)
					.HasColumnName("ID_TIPO_FLETE");
				entity.Property(e => e.IdTipoNotaPedido)
					.HasPrecision(2)
					.HasColumnName("ID_TIPO_NOTA_PEDIDO");
				entity.Property(e => e.IdTipolInstal)
					.HasPrecision(2)
					.HasColumnName("ID_TIPOL_INSTAL");
				entity.Property(e => e.ImpresionAlistamiento)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N' ")
					.IsFixedLength()
					.HasColumnName("IMPRESION_ALISTAMIENTO");
				entity.Property(e => e.Iva)
					.HasPrecision(12)
					.HasColumnName("IVA");
				entity.Property(e => e.IvaPos)
					.HasPrecision(12)
					.HasColumnName("IVA_POS");
				entity.Property(e => e.Mandato)
					.HasPrecision(12)
					.HasDefaultValueSql("0 ")
					.HasColumnName("MANDATO");
				entity.Property(e => e.Mixto)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N'")
					.HasColumnName("MIXTO");
				entity.Property(e => e.NitProvee)
					.HasMaxLength(12)
					.IsUnicode(false)
					.HasColumnName("NIT_PROVEE");
				entity.Property(e => e.NombreProvee)
					.HasMaxLength(40)
					.IsUnicode(false)
					.HasColumnName("NOMBRE_PROVEE");
				entity.Property(e => e.NombreRed)
					.HasMaxLength(80)
					.IsUnicode(false)
					.HasColumnName("NOMBRE_RED");
				entity.Property(e => e.NombreZona)
					.HasMaxLength(60)
					.IsUnicode(false)
					.HasColumnName("NOMBRE_ZONA");
				entity.Property(e => e.NombresCliente)
					.HasMaxLength(60)
					.IsUnicode(false)
					.HasColumnName("NOMBRES_CLIENTE");
				entity.Property(e => e.NumReserva)
					.HasPrecision(10)
					.HasColumnName("NUM_RESERVA");
				entity.Property(e => e.Observaciones)
					.HasMaxLength(2000)
					.IsUnicode(false)
					.HasColumnName("OBSERVACIONES");
				entity.Property(e => e.Origen)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'P' ")
					.HasColumnName("ORIGEN");
				entity.Property(e => e.PagoValido)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N'")
					.IsFixedLength()
					.HasColumnName("PAGO_VALIDO");
				entity.Property(e => e.Peso)
					.HasColumnType("NUMBER(10,3)")
					.HasColumnName("PESO");
				entity.Property(e => e.PorcMaxDesc)
					.HasDefaultValueSql("0 ")
					.HasColumnType("NUMBER(7,4)")
					.HasColumnName("PORC_MAX_DESC");
				entity.Property(e => e.PorcMinDesc)
					.HasDefaultValueSql("0")
					.HasColumnType("NUMBER(7,4)")
					.HasColumnName("PORC_MIN_DESC");
				entity.Property(e => e.ProdsControlados)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N'")
					.IsFixedLength()
					.HasColumnName("PRODS_CONTROLADOS");
				entity.Property(e => e.QuiebreStock)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N'")
					.IsFixedLength()
					.HasColumnName("QUIEBRE_STOCK");
				entity.Property(e => e.Relacion)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N' ")
					.IsFixedLength()
					.HasColumnName("RELACION");
				entity.Property(e => e.ReservaId)
					.HasColumnType("NUMBER(20)")
					.HasColumnName("RESERVA_ID");
				entity.Property(e => e.Retefuente)
					.HasPrecision(12)
					.HasColumnName("RETEFUENTE");
				entity.Property(e => e.Reteica)
					.HasPrecision(12)
					.HasColumnName("RETEICA");
				entity.Property(e => e.StickerVisita)
					.HasMaxLength(22)
					.IsUnicode(false)
					.HasColumnName("STICKER_VISITA");
				entity.Property(e => e.Subtotal)
					.HasPrecision(12)
					.HasColumnName("SUBTOTAL");
				entity.Property(e => e.SubtotalPos)
					.HasPrecision(12)
					.HasColumnName("SUBTOTAL_POS");
				entity.Property(e => e.TarjetaCredito)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N' ")
					.HasColumnName("TARJETA_CREDITO");
				entity.Property(e => e.TcOrderId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("TC_ORDER_ID");
				entity.Property(e => e.Telefonos)
					.HasMaxLength(60)
					.IsUnicode(false)
					.HasColumnName("TELEFONOS");
				entity.Property(e => e.TerminalPago)
					.HasPrecision(2)
					.HasColumnName("TERMINAL_PAGO");
				entity.Property(e => e.TotalBruto)
					.HasPrecision(12)
					.HasDefaultValueSql("0")
					.HasColumnName("TOTAL_BRUTO");
				entity.Property(e => e.Transaccion)
					.HasPrecision(4)
					.HasColumnName("TRANSACCION");
				entity.Property(e => e.ValorFlete)
					.HasPrecision(9)
					.HasColumnName("VALOR_FLETE");
				entity.Property(e => e.VlrDctoPos)
					.HasPrecision(12)
					.HasColumnName("VLR_DCTO_POS");
				entity.Property(e => e.VlrDescuento)
					.HasPrecision(12)
					.HasColumnName("VLR_DESCUENTO");
				entity.Property(e => e.VlrDevInstal)
					.HasPrecision(12)
					.HasDefaultValueSql("0 ")
					.HasColumnName("VLR_DEV_INSTAL");
				entity.Property(e => e.VlrFleteManual)
					.HasPrecision(12)
					.HasColumnName("VLR_FLETE_MANUAL");
				entity.Property(e => e.VlrTotal)
					.HasPrecision(12)
					.HasColumnName("VLR_TOTAL");
				entity.Property(e => e.VlrTotalPos)
					.HasPrecision(12)
					.HasColumnName("VLR_TOTAL_POS");
				entity.Property(e => e.Volumen)
					.HasColumnType("NUMBER(10,3)")
					.HasColumnName("VOLUMEN");
				entity.Property(e => e.ZonaAledanna)
					.HasMaxLength(1)
					.IsUnicode(false)
					.HasDefaultValueSql("'N'")
					.IsFixedLength()
					.HasColumnName("ZONA_ALEDANNA");
			});


		}

	}
}
