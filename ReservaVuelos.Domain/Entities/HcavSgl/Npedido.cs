// <copyright file="Npedido.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Domain.Entities.HcavSgl
{
	[ExcludeFromCodeCoverage]
	public partial class Npedido
	{
		public string Sticker { get; set; } = null!;

		public decimal Consecutivo { get; set; }

		public short IdAlmacen { get; set; }

		public int IdCliente { get; set; }

		public decimal IdEstado { get; set; }

		public byte IdTipoNotaPedido { get; set; }

		public byte IdTipoEntrega { get; set; }

		public int IdDireccion { get; set; }

		public long Cedula { get; set; }

		public DateTime FechaCrea { get; set; }

		public string Origen { get; set; } = null!;

		public DateTime FechaCamb { get; set; }

		public DateTime FechaEntrega { get; set; }

		public string DescEmpleado { get; set; } = null!;

		public long CedulaAut { get; set; }

		public decimal PorcMinDesc { get; set; }

		public decimal PorcMaxDesc { get; set; }

		public long TotalBruto { get; set; }

		public string ContactoEfec { get; set; } = null!;

		public DateTime? FechaRealEnt { get; set; }

		public string? Observaciones { get; set; }

		public string? DirEntrega { get; set; }

		public int? IdCotizacion { get; set; }

		public decimal? Peso { get; set; }

		public long? Subtotal { get; set; }

		public long? VlrDescuento { get; set; }

		public long? VlrTotal { get; set; }

		public long? BaseIva { get; set; }

		public long? Iva { get; set; }

		public long? Retefuente { get; set; }

		public long? Reteica { get; set; }

		public long? SubtotalPos { get; set; }

		public long? VlrDctoPos { get; set; }

		public long? VlrTotalPos { get; set; }

		public long? BaseIvaPos { get; set; }

		public long? IvaPos { get; set; }

		public short? IdAlmEnt { get; set; }

		public short? IdAlmTrns { get; set; }

		public int? ValorFlete { get; set; }

		public string? TarjetaCredito { get; set; }

		public string? NitProvee { get; set; }

		public string? NombreProvee { get; set; }

		public DateTime? FechaPago { get; set; }

		public byte? Transaccion { get; set; }

		public DateTime? FechaRecogidaTransf { get; set; }

		public short? IdAlmacenPago { get; set; }

		public byte? TerminalPago { get; set; }

		public int? NumReserva { get; set; }

		public decimal? Volumen { get; set; }

		public short? IdAlmacenCotiza { get; set; }

		public byte? IdTipoFlete { get; set; }

		public string Mixto { get; set; } = null!;

		public string ZonaAledanna { get; set; } = null!;

		public int? ConsecInstal { get; set; }

		public long? VlrDevInstal { get; set; }

		public byte? IdTipolInstal { get; set; }

		public short? IdAlmacenVisita { get; set; }

		public int? ConsecutivoVisita { get; set; }

		public string? StickerVisita { get; set; }

		public string? IdCentroCosto { get; set; }

		public string? NombreZona { get; set; }

		public decimal? ReservaId { get; set; }

		public string Relacion { get; set; } = null!;

		public string ProdsControlados { get; set; } = null!;

		public string QuiebreStock { get; set; } = null!;

		public string ImpresionAlistamiento { get; set; } = null!;

		public string? CodAutorizacion { get; set; }

		public byte? IdTendtype { get; set; }

		public string? TcOrderId { get; set; }

		public byte? IdNivelServicio { get; set; }

		public string? PagoValido { get; set; }

		public DateTime? FechaInicialEntrega { get; set; }

		public decimal? DireccionEjeX { get; set; }

		public decimal? DireccionEjeY { get; set; }

		public long? Mandato { get; set; }

		public byte? IdEmpTransp { get; set; }

		public decimal? IdRecaudo { get; set; }

		public DateTime? FechaAlistamiento { get; set; }

		public DateTime? FechaEnvio { get; set; }

		public int? IdFuenteInventario { get; set; }

		public int? IdAlmacenAlistamiento { get; set; }

		public byte? IdPromesaCliente { get; set; }

		public int? IdRed { get; set; }

		public string? Flujo { get; set; }

		public long? VlrFleteManual { get; set; }

		public DateTime? FechaOriginalEntrega { get; set; }

		public short? IdCiudadRetiro { get; set; }

		public int? IdMensajeFalabella { get; set; }

		public DateTime? FechaAlistamientoOms { get; set; }

		public long? CodigoReserva { get; set; }

		public long? IdBarrio { get; set; }

		public string? Telefonos { get; set; }

		public string? NombresCliente { get; set; }

		public string? ApellidosCliente { get; set; }

		public DateTime? FechaTransito { get; set; }

		public bool? IdCanalVenta { get; set; }

		public string? NombreRed { get; set; }

		public string? IdHorario { get; set; }

		public string? Horario { get; set; }

		public string? Categoria { get; set; }
	}
}
