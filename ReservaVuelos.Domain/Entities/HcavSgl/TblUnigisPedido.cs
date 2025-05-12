// <copyright file="TblUnigisPedido.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcavSgl
{
	[ExcludeFromCodeCoverage]
	public partial class TblUnigisPedido
	{
		public decimal IdPedidoSgl { get; set; }

		public decimal? IdPedidoUnigis { get; set; }

		public string? RefDocumento { get; set; }

		public string? RefDocumentoAdicional { get; set; }

		public DateTime? FechaPedido { get; set; }

		public DateTime? FechaEntrega { get; set; }

		public DateTime? FechaEntregaOriginal { get; set; }

		public string? RefCliente { get; set; }

		public string? RazonSocial { get; set; }

		public string? Telefono { get; set; }

		public string? Telefono2 { get; set; }

		public string? Telefono3 { get; set; }

		public string? Email { get; set; }

		public string? Descripcion { get; set; }

		public string? Direccion { get; set; }

		public string? Calle { get; set; }

		public string? NumeroPuerta { get; set; }

		public string? EntreCalle { get; set; }

		public string? Barrio { get; set; }

		public string? Localidad { get; set; }

		public string? Partido { get; set; }

		public string? Provincia { get; set; }

		public string? Pais { get; set; }

		public decimal? Latitud { get; set; }

		public decimal? Longitud { get; set; }

		public decimal? InicioHorario1 { get; set; }

		public decimal? FinHorario1 { get; set; }

		public decimal? InicioHorario2 { get; set; }

		public decimal? FinHorario2 { get; set; }

		public decimal? TiempoEspera { get; set; }

		public string? DomicilioCodigoPostal { get; set; }

		public string? CodigoSucursal { get; set; }

		public string? TipoPedido { get; set; }

		public string? Estado { get; set; }

		public decimal? Bultos { get; set; }

		public decimal? Pallets { get; set; }

		public decimal? Volumen { get; set; }

		public decimal? Peso { get; set; }

		public decimal? Cantidad { get; set; }

		public decimal? ValorCorte { get; set; }

		public string? Observaciones { get; set; }

		public string? Varchar1 { get; set; }

		public string? Varchar2 { get; set; }

		public string? Varchar3 { get; set; }

		public string? Varchar4 { get; set; }

		public string? Varchar5 { get; set; }

		public string? Varchar6 { get; set; }

		public string? Varchar7 { get; set; }

		public string? Varchar8 { get; set; }

		public string? Varchar9 { get; set; }

		public decimal? CargaExclusiva { get; set; }

		public decimal? RequiereTurno { get; set; }

		public decimal? UltimaVisita { get; set; }

		public decimal? RequiereAbasto { get; set; }

		public decimal? RefDepositoSalida { get; set; }

		public string? DescripcionDepositoSalida { get; set; }

		public decimal? RefDepositoLlegada { get; set; }

		public string? DescripcionDepositoLlegada { get; set; }

		public string? CodigoPostal { get; set; }

		public string? CodigoOperacion { get; set; }

		public decimal? UsarProductos { get; set; }

		public decimal? AgruparItems { get; set; }

		public decimal? ValorDeclarado { get; set; }

		public string? Urlb2c { get; set; }

		public decimal? EdicionActiva { get; set; }

		public string? BarrioNormalizado { get; set; }

		public string? CalleNormalizada { get; set; }

		public string? EntreCalleNormalizada { get; set; }

		public decimal? NumeroPuertaNormalizado { get; set; }

		public string? LocalidadNormalizada { get; set; }

		public string? PartidoNormalizado { get; set; }

		public string? ProvinciaNormalizada { get; set; }

		public string? PaisNormalizado { get; set; }

		public string? CodigoPostalNormalizado { get; set; }

		public decimal? Color { get; set; }

		public decimal? Icono { get; set; }

		public decimal? Int1 { get; set; }

		public decimal? Int2 { get; set; }

		public decimal? Float1 { get; set; }

		public decimal? Float2 { get; set; }

		public DateTime? Datetime1 { get; set; }

		public DateTime? Datetime2 { get; set; }

		public DateTime? Datetime3 { get; set; }

		public decimal? Eliminado { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		public DateTime? FechaCreacionUnigis { get; set; }

		public DateTime? FechaUltimaModificacion { get; set; }

		public decimal? Contactado { get; set; }

		public decimal? IdTipoPedido { get; set; }

		public decimal? ImporteCosto { get; set; }

		public decimal? IdSucursal { get; set; }

		public decimal? Distancia { get; set; }

		public DateTime? FechaUltimoEstado { get; set; }

		public decimal? TiempoMaximoEstadoExcedido { get; set; }

		public decimal? OrigenGeocodificacion { get; set; }

		public string? TipoGeocodificacion { get; set; }

		public decimal? VolumenAdicional { get; set; }

		public decimal? IdEmpresa { get; set; }

		public decimal? IdEstadoPedido { get; set; }

		public decimal? IdImportacion { get; set; }

		public decimal? IdGrupo { get; set; }

		public decimal? IdCategoriaPedido { get; set; }

		public decimal? IdPrioridadPedido { get; set; }

		public decimal? CantidadReenvio { get; set; }

		public decimal? IdOperacion { get; set; }

		public decimal? IdDomicilioOrden2 { get; set; }

		public DateTime? FechaRecoleccion { get; set; }

		public decimal? GrupoRutas { get; set; }

		public decimal? InicioHorarioRecoleccion1 { get; set; }

		public decimal? FinHorarioRecoleccion1 { get; set; }

		public decimal? InicioHorarioRecoleccion2 { get; set; }

		public decimal? FinHorarioRecoleccion2 { get; set; }

		public string? Moneda { get; set; }

		public decimal? IdTipoMercaderia { get; set; }

		public decimal? IdTipoCanal { get; set; }

		public decimal? IdTipoVerificacion { get; set; }

		public decimal? Unidades { get; set; }

		public string? B2cpassword { get; set; }

		public decimal? IdCategoriaPedidoAdicional { get; set; }

		public decimal? IdTipoUnidadContenedora { get; set; }

		public string? Origen { get; set; }

		public string? Destino { get; set; }

		public string? Sticker { get; set; }

		public string? Categoria { get; set; }

		public decimal? Fulfillment { get; set; }

		public DateTime? VigenciaDesde { get; set; }

		public DateTime? VigenciaHasta { get; set; }

		public decimal? IdEstado { get; set; }

		public decimal? IdAuditoriaEstado { get; set; }

		public decimal? IdTipoIntegracion { get; set; }

		public string? UsrCreacion { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public string? UsrModificacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string? RefField1 { get; set; }

		public string? RefField2 { get; set; }

		public string? RefField3 { get; set; }

		public string? RefField4 { get; set; }

		public string? RefField5 { get; set; }

		public string? RefField6 { get; set; }

		public string? RefField7 { get; set; }

		public string? RefField8 { get; set; }

		public string? RefField9 { get; set; }

		public string? RefField0 { get; set; }
	}
}
