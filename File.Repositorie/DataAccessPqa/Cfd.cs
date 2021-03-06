﻿using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Cfd
    {
        public long IdCfd { get; set; }
        public long IdRuCfd { get; set; }
        public long IdEmpresaSucursal { get; set; }
        public long? IdCertificado { get; set; }
        public string SerieCfd { get; set; }
        public long NumeroCfd { get; set; }
        public DateTime FechaCfd { get; set; }
        public long IdCacxc { get; set; }
        public long IdClienteSucursal { get; set; }
        public string NombreCliente { get; set; }
        public string Calle { get; set; }
        public string NumExterior { get; set; }
        public string NumInterior { get; set; }
        public string Referencia { get; set; }
        public long? CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public long IdZonaIva { get; set; }
        public long DiasCredito { get; set; }
        public long IdMoneda { get; set; }
        public decimal ValorCambio { get; set; }
        public string EfectoCfd { get; set; }
        public decimal Timporte { get; set; }
        public decimal Tdescuento { get; set; }
        public decimal TsubTotal { get; set; }
        public decimal Tiva { get; set; }
        public decimal Tieps { get; set; }
        public decimal Tretisr { get; set; }
        public decimal Tretiva { get; set; }
        public decimal Tretieps { get; set; }
        public decimal Ttotal { get; set; }
        public string FormaPago { get; set; }
        public string CondicionesPago { get; set; }
        public string MetodoPago { get; set; }
        public string Pedimento { get; set; }
        public string FechaPedimento { get; set; }
        public string Aduana { get; set; }
        public long? IdUsuarioCancelo { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public string MotivoCancelacion { get; set; }
        public string Observaciones { get; set; }
        public long? IdPoliza { get; set; }
        public long? IdPolizaCancelacion { get; set; }
        public long? IdRuCxccargo { get; set; }
        public long? IdRuCxcabono { get; set; }
        public string CadenaOriginal { get; set; }
        public byte[] Xml { get; set; }
        public byte[] XmlTimbrado { get; set; }
        public byte[] Pdf { get; set; }
        public DateTime? FechaTimbrado { get; set; }
        public string FolioFiscal { get; set; }
        public string CertificadoSat { get; set; }
        public string SelloSat { get; set; }
        public byte[] XmlAcuseCancelacion { get; set; }
        public string SelloCancelacion { get; set; }
        public byte[] PdfAcuseCancelacion { get; set; }
        public long AcuseReporteEnviado { get; set; }
        public DateTime? FechaCancelacionPac { get; set; }
        public byte Status { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCfd { get; set; }
        public long? IdServicioFacturacion { get; set; }
        public byte? Tipo { get; set; }
        public long? NumeroParcialidades { get; set; }
        public long? IdTipoProyecto { get; set; }
        public string NumeroCuentaPago { get; set; }
        public string FolioFiscalOrigen { get; set; }
        public string SerieFolioFiscalOrigen { get; set; }
        public DateTime? FechaFolioFiscalOrigen { get; set; }
        public decimal? MontoFolioFiscalOrigen { get; set; }
        public string LugarExpedicion { get; set; }
        public byte EsParcialidad { get; set; }
        public long? Parcialidad { get; set; }
        public decimal ImportePagado { get; set; }
        public long? IdPolizaCostoVendido { get; set; }
        public string Ventas { get; set; }
        public long? IdVentaCancelacion { get; set; }
        public byte TipoFactura { get; set; }
        public byte? OrigenFactura { get; set; }
        public byte? ModoGeneracion { get; set; }
        public byte SaldoInicial { get; set; }
        public long? IdCfdjr { get; set; }
        public string Adenda { get; set; }
        public byte IncluyeCxc { get; set; }
        public byte? UltimaParcialidadGenerada { get; set; }
        public DateTime? FechaVentas { get; set; }
        public string Identificador { get; set; }
        public long? IdCondicionNomina { get; set; }
        public decimal? Remuneracion { get; set; }
        public decimal? ComisionTotal { get; set; }
        public decimal? ComisionMatriz { get; set; }
        public decimal? ComisionComisionistaExterno { get; set; }
        public decimal? ComisionComisionistaInterno { get; set; }
        public decimal? Ivamatriz { get; set; }
        public decimal? Ivaexterno { get; set; }
        public decimal? Ivainterno { get; set; }
        public string TipoNomina { get; set; }
        public decimal? RemuneracionOperacionEspecial { get; set; }
        public decimal? Ish { get; set; }
        public byte? ComplementoIne { get; set; }
        public byte? TipoOperacion { get; set; }
        public byte? TipoComite { get; set; }
        public string DescripcionMetodoPago { get; set; }
        public decimal? ComisionSa { get; set; }
        public decimal? Ivasa { get; set; }
        public long? IdTurnoAdministrativo { get; set; }
        public decimal? TretIsn { get; set; }
        public string Contrato { get; set; }
        public long? IdUsoComprobanteSat { get; set; }
        public long? IdTipoPagoSat { get; set; }
        public long? IdMetodoPagoSat { get; set; }
        public string ClaveConfirmacion { get; set; }
        public byte EsPrueba { get; set; }
        public decimal? ImporteBaseCuotaObrera { get; set; }
        public decimal? ImporteBaseCuotaPatronal { get; set; }
        public decimal? ImporteBaseInfonavit { get; set; }
        public decimal? ImporteBaseIsr { get; set; }
        public decimal? ImporteBaseIsn { get; set; }
        public DateTime? FechaSolicitudCancelacion { get; set; }
        public byte? StatusCancelacion { get; set; }
        public byte? TipoCancelacion { get; set; }
        public string MotivoSolicitudCancelacion { get; set; }
        public string FolioReserva { get; set; }
        public string PlanCode { get; set; }
        public byte? EnvioCorreoFacturacionConsumos { get; set; }
        public byte GeneraContabilidad { get; set; }
        public decimal? ImpuestoLocalTrasladado { get; set; }
        public decimal? ImpuestoLocalRetenido { get; set; }
        public byte? Prepolizas { get; set; }
        public byte? PrepolizasCancelacion { get; set; }
    }
}
