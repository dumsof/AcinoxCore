using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class DevolucionesPos
    {
        public long IdDevolucion { get; set; }
        public long IdEmpresaSucursal { get; set; }
        public long IdCaja { get; set; }
        public long FolioDevolucion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public long IdClienteSucursal { get; set; }
        public long IdUsuarioVendedor { get; set; }
        public long IdMoneda { get; set; }
        public long? IdTipoCambio { get; set; }
        public decimal ValorCambio { get; set; }
        public string Notas { get; set; }
        public decimal Timporte { get; set; }
        public decimal Tdescuento { get; set; }
        public decimal Tsubtotal { get; set; }
        public decimal Timpuesto { get; set; }
        public decimal Ttotal { get; set; }
        public long? IdRuCfd { get; set; }
        public long? IdPoliza { get; set; }
        public long? IdCotizacion { get; set; }
        public byte Servicio { get; set; }
        public short NumeroImpresion { get; set; }
        public string Terminal { get; set; }
        public long? IdUsuarioCerro { get; set; }
        public DateTime? FechaCerro { get; set; }
        public long? IdPeriodoAbrio { get; set; }
        public long? IdPeriodoCerro { get; set; }
        public long? IdUsuarioCancelo { get; set; }
        public DateTime? FechaCancelo { get; set; }
        public string MotivoCancelo { get; set; }
        public byte Status { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiDevolucion { get; set; }
        public long IdMovimientoAlmacen { get; set; }
        public long? IdPolizaCancelacion { get; set; }
        public long? IdTurnoAdministrativo { get; set; }
        public decimal Tieps { get; set; }
        public decimal TretencionIva { get; set; }
        public decimal TretencionIsr { get; set; }
        public decimal TretencionIeps { get; set; }
        public long? IdPolizaCostoVendido { get; set; }
        public byte ModoGeneracion { get; set; }
        public string Serie { get; set; }
        public decimal? Ish { get; set; }
        public long? FolioDevolucionFueraLinea { get; set; }
        public string Identificador { get; set; }
        public byte? TipoDevolucion { get; set; }
        public string Contrato { get; set; }
        public byte? DevolucionCero { get; set; }
        public Guid? Uuidcontrato { get; set; }
        public long? IdPolizaCostoVendidoCancelacion { get; set; }
        public byte? Prepolizas { get; set; }
        public byte? PrepolizasCancelacion { get; set; }
    }
}
