namespace File.Repositorie.DataAccessPqa
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    public partial class PQADbContext : DbContext
    {
        public PQADbContext()
        {
        }

        public PQADbContext(DbContextOptions<PQADbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriasClientes> CategoriasClientes { get; set; }
        public virtual DbSet<Cfd> Cfd { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ClientesCategoriasClientes> ClientesCategoriasClientes { get; set; }
        public virtual DbSet<ClientesSucursales> ClientesSucursales { get; set; }
        public virtual DbSet<ClientesSucursalesContactos> ClientesSucursalesContactos { get; set; }
        public virtual DbSet<ClientesSucursalesContactosInternets> ClientesSucursalesContactosInternets { get; set; }
        public virtual DbSet<ClientesSucursalesContactosTelefonos> ClientesSucursalesContactosTelefonos { get; set; }
        public virtual DbSet<CondicionesCreditosClientes> CondicionesCreditosClientes { get; set; }
        public virtual DbSet<CondicionesCreditosClientesEmpresas> CondicionesCreditosClientesEmpresas { get; set; }
        public virtual DbSet<CondicionesPagos> CondicionesPagos { get; set; }
        public virtual DbSet<Cxcabonos> Cxcabonos { get; set; }
        public virtual DbSet<Cxccargos> Cxccargos { get; set; }
        public virtual DbSet<DetalleEntradasSalidas> DetalleEntradasSalidas { get; set; }
        public virtual DbSet<DetallesEntradasSalidasFacturas> DetallesEntradasSalidasFacturas { get; set; }
        public virtual DbSet<DevolucionesPos> DevolucionesPos { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Internets> Internets { get; set; }
        public virtual DbSet<Monedas> Monedas { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
        public virtual DbSet<TiposCargosAbonosCxcs> TiposCargosAbonosCxcs { get; set; }
        public virtual DbSet<TiposPagosPos> TiposPagosPos { get; set; }
        public virtual DbSet<TiposPagosPosempresasSucursales> TiposPagosPosempresasSucursales { get; set; }
        public virtual DbSet<Titulos> Titulos { get; set; }
        public virtual DbSet<VentasPos> VentasPos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DARWIN-PC;user=sa;password=123;database=PQA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriasClientes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CategoriasClientes", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdCategoriaCliente).HasColumnName("ID_CategoriaCliente");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdPadre).HasColumnName("ID_Padre");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreCategoriaCliente)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiCategoriaCliente).HasColumnName("UI_CategoriaCliente");
            });

            modelBuilder.Entity<Cfd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CFD", "Facturacion");

                entity.Property(e => e.Adenda).HasColumnType("text");

                entity.Property(e => e.Aduana)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.CadenaOriginal).IsUnicode(false);

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CertificadoSat)
                    .HasColumnName("CertificadoSAT")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveConfirmacion)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Colonia)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ComisionComisionistaExterno).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ComisionComisionistaInterno).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ComisionMatriz).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ComisionSa)
                    .HasColumnName("ComisionSA")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ComisionTotal).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ComplementoIne).HasColumnName("ComplementoINE");

                entity.Property(e => e.CondicionesPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrato)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionMetodoPago)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EfectoCfd)
                    .IsRequired()
                    .HasColumnName("EfectoCFD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCancelacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCancelacionPac)
                    .HasColumnName("FechaCancelacionPAC")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCfd)
                    .HasColumnName("FechaCFD")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaFolioFiscalOrigen).HasColumnType("datetime");

                entity.Property(e => e.FechaPedimento)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.FechaSolicitudCancelacion).HasColumnType("datetime");

                entity.Property(e => e.FechaTimbrado).HasColumnType("datetime");

                entity.Property(e => e.FechaVentas).HasColumnType("datetime");

                entity.Property(e => e.FolioFiscal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FolioFiscalOrigen)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FolioReserva)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCacxc).HasColumnName("ID_CACXC");

                entity.Property(e => e.IdCertificado).HasColumnName("ID_Certificado");

                entity.Property(e => e.IdCfd).HasColumnName("ID_CFD");

                entity.Property(e => e.IdCfdjr).HasColumnName("ID_CFDJR");

                entity.Property(e => e.IdClienteSucursal).HasColumnName("ID_ClienteSucursal");

                entity.Property(e => e.IdCondicionNomina).HasColumnName("ID_CondicionNomina");

                entity.Property(e => e.IdEmpresaSucursal).HasColumnName("ID_EmpresaSucursal");

                entity.Property(e => e.IdMetodoPagoSat).HasColumnName("ID_MetodoPagoSAT");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdPoliza).HasColumnName("ID_Poliza");

                entity.Property(e => e.IdPolizaCancelacion).HasColumnName("ID_PolizaCancelacion");

                entity.Property(e => e.IdPolizaCostoVendido).HasColumnName("ID_PolizaCostoVendido");

                entity.Property(e => e.IdRuCfd).HasColumnName("ID_RU_CFD");

                entity.Property(e => e.IdRuCxcabono).HasColumnName("ID_RU_CXCAbono");

                entity.Property(e => e.IdRuCxccargo).HasColumnName("ID_RU_CXCCargo");

                entity.Property(e => e.IdServicioFacturacion).HasColumnName("ID_ServicioFacturacion");

                entity.Property(e => e.IdTipoPagoSat).HasColumnName("ID_TipoPagoSAT");

                entity.Property(e => e.IdTipoProyecto).HasColumnName("ID_TipoProyecto");

                entity.Property(e => e.IdTurnoAdministrativo).HasColumnName("ID_TurnoAdministrativo");

                entity.Property(e => e.IdUsoComprobanteSat).HasColumnName("ID_UsoComprobanteSAT");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdUsuarioCancelo).HasColumnName("ID_UsuarioCancelo");

                entity.Property(e => e.IdVentaCancelacion).HasColumnName("ID_VentaCancelacion");

                entity.Property(e => e.IdZonaIva).HasColumnName("ID_ZonaIva");

                entity.Property(e => e.Identificador)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ImporteBaseCuotaObrera).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteBaseCuotaPatronal).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteBaseInfonavit).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteBaseIsn)
                    .HasColumnName("ImporteBaseISN")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteBaseIsr)
                    .HasColumnName("ImporteBaseISR")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImportePagado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ImpuestoLocalRetenido).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ImpuestoLocalTrasladado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IncluyeCxc).HasColumnName("IncluyeCXC");

                entity.Property(e => e.Ish)
                    .HasColumnName("ISH")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ivaexterno)
                    .HasColumnName("IVAExterno")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Ivainterno)
                    .HasColumnName("IVAInterno")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Ivamatriz)
                    .HasColumnName("IVAMatriz")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Ivasa)
                    .HasColumnName("IVASA")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LugarExpedicion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MontoFolioFiscalOrigen).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MotivoCancelacion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MotivoSolicitudCancelacion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.NumExterior)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumInterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCfd).HasColumnName("NumeroCFD");

                entity.Property(e => e.NumeroCuentaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pdf)
                    .HasColumnName("PDF")
                    .HasColumnType("image");

                entity.Property(e => e.PdfAcuseCancelacion)
                    .HasColumnName("PDF_AcuseCancelacion")
                    .HasColumnType("image");

                entity.Property(e => e.Pedimento)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PlanCode)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Referencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.Remuneracion).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RemuneracionOperacionEspecial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SelloCancelacion).HasColumnType("text");

                entity.Property(e => e.SelloSat)
                    .HasColumnName("SelloSAT")
                    .HasColumnType("text");

                entity.Property(e => e.SerieCfd)
                    .IsRequired()
                    .HasColumnName("SerieCFD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerieFolioFiscalOrigen)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tdescuento)
                    .HasColumnName("TDescuento")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tieps).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Timporte).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoNomina)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tiva).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TretIsn)
                    .HasColumnName("TretISN")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tretieps).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tretisr).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tretiva).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TsubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ttotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UiCfd).HasColumnName("UI_CFD");

                entity.Property(e => e.ValorCambio).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Xml)
                    .HasColumnName("XML")
                    .HasColumnType("image");

                entity.Property(e => e.XmlAcuseCancelacion)
                    .HasColumnName("XML_AcuseCancelacion")
                    .HasColumnType("image");

                entity.Property(e => e.XmlTimbrado)
                    .HasColumnName("XML_Timbrado")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Clientes", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cedula).HasColumnType("image");

                entity.Property(e => e.Clasificacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .HasColumnName("CURP")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.EnvioDocumentosFiscales)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdActividadEconomica).HasColumnName("ID_ActividadEconomica");

                entity.Property(e => e.IdCategoriaCliente).HasColumnName("ID_CategoriaCliente");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdClienteGrupo).HasColumnName("ID_ClienteGrupo");

                entity.Property(e => e.IdClienteRevendedor).HasColumnName("ID_ClienteRevendedor");

                entity.Property(e => e.IdClienteSucursalAfacturar).HasColumnName("ID_ClienteSucursalAFacturar");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdEmpresaSucursalAfacturar).HasColumnName("ID_EmpresaSucursalAFacturar");

                entity.Property(e => e.IdFormatoImpresionEtiqueta).HasColumnName("ID_FormatoImpresionEtiqueta");

                entity.Property(e => e.IdNacionalidad).HasColumnName("ID_Nacionalidad");

                entity.Property(e => e.IdPaisNacimiento).HasColumnName("ID_PaisNacimiento");

                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("ID_TipoIdentificacion");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdentificacionOtro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImagenCliente).HasColumnType("image");

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.Materno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotivoSuspension)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NoIdentificado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.NombreComercial)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartidoPolitico)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Paterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.RetieneIsn).HasColumnName("RetieneISN");

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("RFC")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UiCliente).HasColumnName("UI_Cliente");
            });

            modelBuilder.Entity<ClientesCategoriasClientes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClientesCategoriasClientes", "Corporativo");

                entity.Property(e => e.IdCategoriaCliente).HasColumnName("ID_CategoriaCliente");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdClienteCategoriaCliente).HasColumnName("ID_ClienteCategoriaCliente");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdEmpresaSucursal).HasColumnName("ID_EmpresaSucursal");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.UiClienteCategoriaCliente).HasColumnName("UI_ClienteCategoriaCliente");
            });

            modelBuilder.Entity<ClientesSucursales>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClientesSucursales", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostalIntegracion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRelacionLayout)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Colonia)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdClienteSucursal).HasColumnName("ID_ClienteSucursal");

                entity.Property(e => e.IdCodigoPostal).HasColumnName("ID_CodigoPostal");

                entity.Property(e => e.IdColoniaSat).HasColumnName("ID_ColoniaSAT");

                entity.Property(e => e.IdEmpresaSucursalNomina).HasColumnName("ID_EmpresaSucursalNomina");

                entity.Property(e => e.IdLocalidadSat).HasColumnName("ID_LocalidadSAT");

                entity.Property(e => e.IdMunicipioSat).HasColumnName("ID_MunicipioSAT");

                entity.Property(e => e.IdPais).HasColumnName("ID_Pais");

                entity.Property(e => e.IdPaisEstado).HasColumnName("ID_PaisEstado");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdZonaIva).HasColumnName("ID_ZonaIVA");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreClienteSucursal)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumExterior)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumInterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesDiaPago)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesDiaRecepcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Referencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiClienteSucursal).HasColumnName("UI_ClienteSucursal");
            });

            modelBuilder.Entity<ClientesSucursalesContactos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClientesSucursalesContactos", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DepartamentoContacto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimientoContacto).HasColumnType("date");

                entity.Property(e => e.FotoContacto).HasColumnType("image");

                entity.Property(e => e.IdClienteSucursal).HasColumnName("ID_ClienteSucursal");

                entity.Property(e => e.IdClienteSucursalContacto).HasColumnName("ID_ClienteSucursalContacto");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdTitulo).HasColumnName("ID_Titulo");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreContacto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PuestoContacto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiClienteSucursalContacto).HasColumnName("UI_ClienteSucursalContacto");
            });

            modelBuilder.Entity<ClientesSucursalesContactosInternets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClientesSucursalesContactosInternets", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CuentaDireccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnviarInformacion)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdClienteSucursalContacto).HasColumnName("ID_ClienteSucursalContacto");

                entity.Property(e => e.IdClienteSucursalContactoInternet).HasColumnName("ID_ClienteSucursalContactoInternet");

                entity.Property(e => e.IdInternet).HasColumnName("ID_Internet");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiClienteSucursalContactoInternet).HasColumnName("UI_ClienteSucursalContactoInternet");
            });

            modelBuilder.Entity<ClientesSucursalesContactosTelefonos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClientesSucursalesContactosTelefonos", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CodigoArea)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdClienteSucursalContacto).HasColumnName("ID_ClienteSucursalContacto");

                entity.Property(e => e.IdClienteSucursalContactoTelefono).HasColumnName("ID_ClienteSucursalContactoTelefono");

                entity.Property(e => e.IdPais).HasColumnName("ID_Pais");

                entity.Property(e => e.IdTelefono).HasColumnName("ID_Telefono");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NumeroLocal)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiClienteSucursalContactoTelefono).HasColumnName("UI_ClienteSucursalContactoTelefono");
            });

            modelBuilder.Entity<CondicionesCreditosClientes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CondicionesCreditosClientes", "Facturacion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CargoPorMora).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IdCacxc).HasColumnName("ID_CACXC");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdClienteSucursal).HasColumnName("ID_ClienteSucursal");

                entity.Property(e => e.IdCondicionCreditoCliente).HasColumnName("ID_CondicionCreditoCliente");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PorcentajeMora).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiCondicionCreditoCliente).HasColumnName("UI_CondicionCreditoCliente");
            });

            modelBuilder.Entity<CondicionesCreditosClientesEmpresas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CondicionesCreditosClientesEmpresas", "Facturacion");

                entity.Property(e => e.IdCondicionCreditoCliente).HasColumnName("ID_CondicionCreditoCliente");

                entity.Property(e => e.IdCondicionCreditoClienteEmpresa).HasColumnName("ID_CondicionCreditoClienteEmpresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiCondicionCreditoClienteEmpresa).HasColumnName("UI_CondicionCreditoClienteEmpresa");
            });

            modelBuilder.Entity<CondicionesPagos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CondicionesPagos", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdCondicionPago).HasColumnName("ID_CondicionPago");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreCondicionPago)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiCondicionPago).HasColumnName("UI_CondicionPago");
            });

            modelBuilder.Entity<Cxcabonos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CXCAbonos", "Facturacion");

                entity.Property(e => e.ConceptoCxc)
                    .HasColumnName("ConceptoCXC")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAbono).HasColumnType("datetime");

                entity.Property(e => e.IdCacxc).HasColumnName("ID_CACXC");

                entity.Property(e => e.IdCfd).HasColumnName("ID_CFD");

                entity.Property(e => e.IdCxccargo).HasColumnName("ID_CXCCargo");

                entity.Property(e => e.IdCxccargoFactura).HasColumnName("ID_CXCCargoFactura");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdRuCxcabono).HasColumnName("ID_RU_CXCAbono");

                entity.Property(e => e.IdRuCxcabonoFactura).HasColumnName("ID_RU_CXCAbonoFactura");

                entity.Property(e => e.IdTasaIva).HasColumnName("ID_TasaIVA");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdZonaIva).HasColumnName("ID_ZonaIVA");

                entity.Property(e => e.Ieps)
                    .HasColumnName("IEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ish)
                    .HasColumnName("ISH")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Iva)
                    .HasColumnName("IVA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeIsh)
                    .HasColumnName("PorcentajeISH")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PorcentajeIva)
                    .HasColumnName("PorcentajeIVA")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.ProcedenciaDocumento)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.RetencionIeps)
                    .HasColumnName("RetencionIEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RetencionIsr)
                    .HasColumnName("RetencionISR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RetencionIva)
                    .HasColumnName("RetencionIVA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ttotal)
                    .HasColumnName("TTotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UiCxcabono).HasColumnName("UI_CXCAbono");

                entity.Property(e => e.ValorCambio).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<Cxccargos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CXCCargos", "Facturacion");

                entity.Property(e => e.ConceptoCxc)
                    .HasColumnName("ConceptoCXC")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CondicionesPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorContabilidad).IsUnicode(false);

                entity.Property(e => e.FechaDocumento).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.IdCacxc).HasColumnName("ID_CACXC");

                entity.Property(e => e.IdCategoriaCliente).HasColumnName("ID_CategoriaCliente");

                entity.Property(e => e.IdCategoriaClienteAbonos).HasColumnName("ID_CategoriaClienteAbonos");

                entity.Property(e => e.IdCfd).HasColumnName("ID_CFD");

                entity.Property(e => e.IdCfdauxiliar).HasColumnName("ID_CFDAuxiliar");

                entity.Property(e => e.IdClienteSucursal).HasColumnName("ID_ClienteSucursal");

                entity.Property(e => e.IdContratoDetalle).HasColumnName("ID_ContratoDetalle");

                entity.Property(e => e.IdCuentaContableSaldoInicial).HasColumnName("ID_CuentaContableSaldoInicial");

                entity.Property(e => e.IdCxccargo).HasColumnName("ID_CXCCargo");

                entity.Property(e => e.IdCxccargoAnticipoDevolucion).HasColumnName("ID_CXCCargoAnticipoDevolucion");

                entity.Property(e => e.IdCxccargoCancelo).HasColumnName("ID_CXCCargoCancelo");

                entity.Property(e => e.IdCxpabono).HasColumnName("ID_CXPAbono");

                entity.Property(e => e.IdEmpresaSucursal).HasColumnName("ID_EmpresaSucursal");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdRuCxccargo).HasColumnName("ID_RU_CXCCargo");

                entity.Property(e => e.IdRuCxpcargo).HasColumnName("ID_RU_CXPCargo");

                entity.Property(e => e.IdTasaImpuestoSobreHospedaje).HasColumnName("ID_TasaImpuestoSobreHospedaje");

                entity.Property(e => e.IdTasaIva).HasColumnName("ID_TasaIVA");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdUsuarioVendedor).HasColumnName("ID_UsuarioVendedor");

                entity.Property(e => e.IdZonaIva).HasColumnName("ID_ZonaIVA");

                entity.Property(e => e.Ieps)
                    .HasColumnName("IEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ish)
                    .HasColumnName("ISH")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Iva)
                    .HasColumnName("IVA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeIsh)
                    .HasColumnName("PorcentajeISH")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PorcentajeIva)
                    .HasColumnName("PorcentajeIVA")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.RetencionIeps)
                    .HasColumnName("RetencionIEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RetencionIsr)
                    .HasColumnName("RetencionISR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RetencionIva)
                    .HasColumnName("RetencionIVA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Saldada).HasColumnType("date");

                entity.Property(e => e.SerieDocumento)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Ttotal)
                    .HasColumnName("TTotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UiCxccargo).HasColumnName("UI_CXCCargo");

                entity.Property(e => e.ValorCambio).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<DetalleEntradasSalidas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DetalleEntradasSalidas", "Inventarios");

                entity.Property(e => e.AgenteAduanal)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ancho).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Calibre).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CantidadCambiada).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CantidadKilo).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CantidadMetro).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CantidadRollo).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Concepto).HasColumnType("text");

                entity.Property(e => e.ConstanteDensidad).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CostoProrrateo).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CostoUnitarioCambiado).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CostoUnitarioKilo).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CostoUnitarioMetro).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CostoUnitarioRollo).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DistanciaHileras).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DistanciaPlantas).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DistanciaPlantasLineaCentral).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EnlazadaApedido).HasColumnName("EnlazadaAPedido");

                entity.Property(e => e.FechaAplicarKardex).HasColumnType("datetime");

                entity.Property(e => e.FechaCancelo).HasColumnType("datetime");

                entity.Property(e => e.FechaFinalDescargue).HasColumnType("datetime");

                entity.Property(e => e.FechaGeneracionArchivo).HasColumnType("datetime");

                entity.Property(e => e.FechaInicioDescargue).HasColumnType("datetime");

                entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");

                entity.Property(e => e.FechaOperacion).HasColumnType("date");

                entity.Property(e => e.IdAlmacen).HasColumnName("ID_Almacen");

                entity.Property(e => e.IdCacxp).HasColumnName("ID_CACXP");

                entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CentroCosto");

                entity.Property(e => e.IdClienteTimbre).HasColumnName("ID_ClienteTimbre");

                entity.Property(e => e.IdCompra).HasColumnName("ID_Compra");

                entity.Property(e => e.IdContratoDetalleJr).HasColumnName("ID_ContratoDetalleJR");

                entity.Property(e => e.IdCxccargoAnticipo).HasColumnName("ID_CXCCargoAnticipo");

                entity.Property(e => e.IdCxccargoPropina).HasColumnName("ID_CXCCargoPropina");

                entity.Property(e => e.IdCxpabonoRedondeo).HasColumnName("ID_CXPAbonoRedondeo");

                entity.Property(e => e.IdEmpresaSucursal).HasColumnName("ID_EmpresaSucursal");

                entity.Property(e => e.IdEscontrol).HasColumnName("ID_ESControl");

                entity.Property(e => e.IdEsdetalle).HasColumnName("ID_ESDetalle");

                entity.Property(e => e.IdEsdetalleDevolucionAutomatica).HasColumnName("ID_ESDetalleDevolucionAutomatica");

                entity.Property(e => e.IdEsdetalleVentaAutomatica).HasColumnName("ID_ESDetalleVentaAutomatica");

                entity.Property(e => e.IdEsorigen).HasColumnName("ID_ESOrigen");

                entity.Property(e => e.IdEventoBuffet).HasColumnName("ID_EventoBuffet");

                entity.Property(e => e.IdFabricante).HasColumnName("ID_Fabricante");

                entity.Property(e => e.IdGasto).HasColumnName("ID_Gasto");

                entity.Property(e => e.IdGastoCostoVenta).HasColumnName("ID_GastoCostoVenta");

                entity.Property(e => e.IdGastoDepartamental).HasColumnName("ID_GastoDepartamental");

                entity.Property(e => e.IdGastoDepartamentalCancelacion).HasColumnName("ID_GastoDepartamentalCancelacion");

                entity.Property(e => e.IdIngreso).HasColumnName("ID_Ingreso");

                entity.Property(e => e.IdIngresoDepartamental).HasColumnName("ID_IngresoDepartamental");

                entity.Property(e => e.IdIngresoDepartamentalCancelacion).HasColumnName("ID_IngresoDepartamentalCancelacion");

                entity.Property(e => e.IdKardex).HasColumnName("ID_Kardex");

                entity.Property(e => e.IdKardexCancelacion).HasColumnName("ID_KardexCancelacion");

                entity.Property(e => e.IdLibroBanco).HasColumnName("ID_LibroBanco");

                entity.Property(e => e.IdListaPrecio).HasColumnName("ID_ListaPrecio");

                entity.Property(e => e.IdMedida).HasColumnName("ID_Medida");

                entity.Property(e => e.IdMovimientoAlmacen).HasColumnName("ID_MovimientoAlmacen");

                entity.Property(e => e.IdOrdenCompraDetalle).HasColumnName("ID_OrdenCompraDetalle");

                entity.Property(e => e.IdPedidoDetalle).HasColumnName("ID_PedidoDetalle");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.IdProductoCambiado).HasColumnName("ID_ProductoCambiado");

                entity.Property(e => e.IdProductoVehiculo).HasColumnName("ID_ProductoVehiculo");

                entity.Property(e => e.IdRequisicionDetalle).HasColumnName("ID_RequisicionDetalle");

                entity.Property(e => e.IdRuCxcabonoAnticipo).HasColumnName("ID_RU_CXCAbonoAnticipo");

                entity.Property(e => e.IdRuCxcabonoAnticipoBanco).HasColumnName("ID_RU_CXCAbonoAnticipoBanco");

                entity.Property(e => e.IdRuCxcabonoAnticipoCancelo).HasColumnName("ID_RU_CXCAbonoAnticipoCancelo");

                entity.Property(e => e.IdRuCxpcargo).HasColumnName("ID_RU_CXPCargo");

                entity.Property(e => e.IdRuCxpcargoAnticipo).HasColumnName("ID_RU_CXPCargoAnticipo");

                entity.Property(e => e.IdRuCxpcargoAnticipoCancelo).HasColumnName("ID_RU_CXPCargoAnticipoCancelo");

                entity.Property(e => e.IdRuCxpcargoCancelo).HasColumnName("ID_RU_CXPCargoCancelo");

                entity.Property(e => e.IdRuGasto).HasColumnName("ID_RU_Gasto");

                entity.Property(e => e.IdRuInv).HasColumnName("ID_RU_INV");

                entity.Property(e => e.IdServicioGarantiaDetalleCostoAdicional).HasColumnName("ID_ServicioGarantiaDetalleCostoAdicional");

                entity.Property(e => e.IdSolicitudCompraDetalle).HasColumnName("ID_SolicitudCompraDetalle");

                entity.Property(e => e.IdTasaIsh).HasColumnName("ID_TasaISH");

                entity.Property(e => e.IdTasaIva).HasColumnName("ID_TasaIVA");

                entity.Property(e => e.IdTipoIeps).HasColumnName("ID_TipoIEPS");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdUsuarioCancelo).HasColumnName("ID_UsuarioCancelo");

                entity.Property(e => e.IdVenta).HasColumnName("ID_Venta");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteIeps)
                    .HasColumnName("ImporteIEPS")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteImpuestoHospedaje).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteRetencionIeps)
                    .HasColumnName("ImporteRetencionIEPS")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteRetencionIsr)
                    .HasColumnName("ImporteRetencionISR")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ImporteRetencionIva)
                    .HasColumnName("ImporteRetencionIVA")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Largo).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MotivoCancelo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoAduanaSeccion)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PedimentoImportacion)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.PesoBruto).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PorcentajeImpuestoHospedaje).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PorcentajeIva)
                    .HasColumnName("PorcentajeIVA")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Temporada)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIeps).HasColumnName("TipoIEPS");

                entity.Property(e => e.TotalImporte).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.UiEsdetalle).HasColumnName("UI_ESDetalle");

                entity.Property(e => e.ValorCambio).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ValorIeps)
                    .HasColumnName("ValorIEPS")
                    .HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<DetallesEntradasSalidasFacturas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DetallesEntradasSalidasFacturas", "Facturacion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CantidadCfd)
                    .HasColumnName("CantidadCFD")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CantidadCliente).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.IdCfddetalle).HasColumnName("ID_CFDDetalle");

                entity.Property(e => e.IdCfddetalleCliente).HasColumnName("ID_CFDDetalleCliente");

                entity.Property(e => e.IdEsdetalle).HasColumnName("ID_ESDetalle");

                entity.Property(e => e.IdEsdetalleDevolucion).HasColumnName("ID_ESDetalleDevolucion");

                entity.Property(e => e.IdEsdetalleFactura).HasColumnName("ID_ESDetalleFactura");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdVenta).HasColumnName("ID_Venta");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiEsdetalleFactura).HasColumnName("UI_ESDetalleFactura");
            });

            modelBuilder.Entity<DevolucionesPos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DevolucionesPOS", "Facturacion");

                entity.Property(e => e.Contrato)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCancelo).HasColumnType("datetime");

                entity.Property(e => e.FechaCerro).HasColumnType("datetime");

                entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");

                entity.Property(e => e.IdCaja).HasColumnName("ID_Caja");

                entity.Property(e => e.IdClienteSucursal).HasColumnName("ID_ClienteSucursal");

                entity.Property(e => e.IdCotizacion).HasColumnName("ID_Cotizacion");

                entity.Property(e => e.IdDevolucion).HasColumnName("ID_Devolucion");

                entity.Property(e => e.IdEmpresaSucursal).HasColumnName("ID_EmpresaSucursal");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdMovimientoAlmacen).HasColumnName("ID_MovimientoAlmacen");

                entity.Property(e => e.IdPeriodoAbrio).HasColumnName("ID_PeriodoAbrio");

                entity.Property(e => e.IdPeriodoCerro).HasColumnName("ID_PeriodoCerro");

                entity.Property(e => e.IdPoliza).HasColumnName("ID_Poliza");

                entity.Property(e => e.IdPolizaCancelacion).HasColumnName("ID_PolizaCancelacion");

                entity.Property(e => e.IdPolizaCostoVendido).HasColumnName("ID_PolizaCostoVendido");

                entity.Property(e => e.IdPolizaCostoVendidoCancelacion).HasColumnName("ID_PolizaCostoVendidoCancelacion");

                entity.Property(e => e.IdRuCfd).HasColumnName("ID_RU_CFD");

                entity.Property(e => e.IdTipoCambio).HasColumnName("ID_TipoCambio");

                entity.Property(e => e.IdTurnoAdministrativo).HasColumnName("ID_TurnoAdministrativo");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdUsuarioCancelo).HasColumnName("ID_UsuarioCancelo");

                entity.Property(e => e.IdUsuarioCerro).HasColumnName("ID_UsuarioCerro");

                entity.Property(e => e.IdUsuarioVendedor).HasColumnName("ID_UsuarioVendedor");

                entity.Property(e => e.Identificador)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Ish)
                    .HasColumnName("ISH")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MotivoCancelo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notas)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.Serie)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tdescuento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Terminal)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tieps)
                    .HasColumnName("TIEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Timporte).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Timpuesto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TretencionIeps)
                    .HasColumnName("TRetencionIEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TretencionIsr)
                    .HasColumnName("TRetencionISR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TretencionIva)
                    .HasColumnName("TRetencionIVA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tsubtotal)
                    .HasColumnName("TSubtotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ttotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UiDevolucion).HasColumnName("UI_Devolucion");

                entity.Property(e => e.Uuidcontrato).HasColumnName("UUIDContrato");

                entity.Property(e => e.ValorCambio).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Empresas", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cedula).HasColumnType("image");

                entity.Property(e => e.ConstLibro)
                    .HasColumnName("Const_Libro")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConstNotarioNom)
                    .HasColumnName("Const_NotarioNom")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ConstNotarioNum)
                    .HasColumnName("Const_NotarioNum")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ConstNotarioUbica)
                    .HasColumnName("Const_NotarioUbica")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ConstNumActa)
                    .HasColumnName("Const_NumActa")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ConstVolumen)
                    .HasColumnName("Const_Volumen")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .HasColumnName("CURP")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.CurprepresentanteLegal)
                    .HasColumnName("CURPRepresentanteLegal")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Fondo).HasColumnType("image");

                entity.Property(e => e.Icono).HasColumnType("image");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdNacionalidad).HasColumnName("ID_Nacionalidad");

                entity.Property(e => e.IdPersonaRepresentante).HasColumnName("ID_PersonaRepresentante");

                entity.Property(e => e.IdRegimenFiscal).HasColumnName("ID_RegimenFiscal");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.LogoRuta)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Materno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreComercial)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Paterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegimenFiscal)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.RepreFecha)
                    .HasColumnName("Repre_Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.RepreFirma)
                    .HasColumnName("Repre_Firma")
                    .HasColumnType("image");

                entity.Property(e => e.RepreLibro)
                    .HasColumnName("Repre_Libro")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RepreNombre)
                    .HasColumnName("Repre_Nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RepreNotarioNom)
                    .HasColumnName("Repre_NotarioNom")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RepreNotarioNum)
                    .HasColumnName("Repre_NotarioNum")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RepreNotarioUbica)
                    .HasColumnName("Repre_NotarioUbica")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RepreNumActa)
                    .HasColumnName("Repre_NumActa")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RepreRfc)
                    .HasColumnName("Repre_RFC")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.RepreVolumen)
                    .HasColumnName("Repre_Volumen")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("RFC")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TiposInterfazEmpresa)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UiEmpresa).HasColumnName("UI_Empresa");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Estados", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoInesat)
                    .HasColumnName("CodigoINESAT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdPais).HasColumnName("ID_Pais");

                entity.Property(e => e.IdPaisEstado).HasColumnName("ID_PaisEstado");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiPaisEstado).HasColumnName("UI_PaisEstado");
            });

            modelBuilder.Entity<Internets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Internets", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdInternet).HasColumnName("ID_Internet");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreInternet)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiInternet).HasColumnName("UI_Internet");
            });

            modelBuilder.Entity<Monedas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Monedas", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CodigoMoneda)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CodigoSat)
                    .HasColumnName("CodigoSAT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMoneda)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.SimboloDocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SimboloMoneda)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UiMoneda).HasColumnName("UI_Moneda");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Paises", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClaveTelefonica)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPais)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IdPais).HasColumnName("ID_Pais");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePais)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiPais).HasColumnName("UI_Pais");
            });

            modelBuilder.Entity<Telefonos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Telefonos", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdTelefono).HasColumnName("ID_Telefono");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreTelefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiTelefono).HasColumnName("UI_Telefono");
            });

            modelBuilder.Entity<TiposCargosAbonosCxcs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TiposCargosAbonosCXCs", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdCacxc).HasColumnName("ID_CACXC");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreCacxc)
                    .IsRequired()
                    .HasColumnName("NombreCACXC")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.TipoCacxc)
                    .IsRequired()
                    .HasColumnName("TipoCACXC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UiCacxc).HasColumnName("UI_CACXC");

                entity.Property(e => e.UsosCategorias).IsUnicode(false);
            });

            modelBuilder.Entity<TiposPagosPos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TiposPagosPOS", "Facturacion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AplicaSoloUnaTransaccion)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CodigoTipoPago)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EsApartado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EsFlotilla)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdBancoPagoEnLinea).HasColumnName("ID_BancoPagoEnLinea");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdTipoCambio).HasColumnName("ID_TipoCambio");

                entity.Property(e => e.IdTipoPago).HasColumnName("ID_TipoPago");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreTipoPago)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oblf).HasColumnName("OBLF");

                entity.Property(e => e.PagoCredito)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.RegresaCambio)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SolicitarDetalleDenominacionesCorte)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SolicitarFolio)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SolicitarNumeroCuentaPago)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SolicitarReferencia)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SolicitarSerie)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UiTipoPago).HasColumnName("UI_TipoPago");
            });

            modelBuilder.Entity<TiposPagosPosempresasSucursales>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TiposPagosPOSEmpresasSucursales", "Facturacion");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdEmpresaSucursal).HasColumnName("ID_EmpresaSucursal");

                entity.Property(e => e.IdTipoPago).HasColumnName("ID_TipoPago");

                entity.Property(e => e.IdTipoPagoPosempresaSucursal).HasColumnName("ID_TipoPagoPOSEmpresaSucursal");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiTipoPagoPosempresaSucursal).HasColumnName("UI_TipoPagoPOSEmpresaSucursal");
            });

            modelBuilder.Entity<Titulos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Titulos", "Corporativo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdTitulo).HasColumnName("ID_Titulo");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.NombreTitulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.UiTitulo).HasColumnName("UI_Titulo");
            });

            modelBuilder.Entity<VentasPos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VentasPOS", "Facturacion");

                entity.Property(e => e.AbonadoAmonedero).HasColumnName("AbonadoAMonedero");

                entity.Property(e => e.ContadorLitros).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Contrato)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DatosExtras).IsUnicode(false);

                entity.Property(e => e.FechaCancelo).HasColumnType("datetime");

                entity.Property(e => e.FechaCerro).HasColumnType("datetime");

                entity.Property(e => e.FechaGeneracionArchivo).HasColumnType("datetime");

                entity.Property(e => e.FechaVenta).HasColumnType("datetime");

                entity.Property(e => e.FechaVentaFueraLinea).HasColumnType("datetime");

                entity.Property(e => e.HardwareId)
                    .HasColumnName("HardwareID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdAlumno).HasColumnName("ID_Alumno");

                entity.Property(e => e.IdCaja).HasColumnName("ID_Caja");

                entity.Property(e => e.IdClienteSucursal).HasColumnName("ID_ClienteSucursal");

                entity.Property(e => e.IdContratoJr).HasColumnName("ID_ContratoJR");

                entity.Property(e => e.IdCotizacion).HasColumnName("ID_Cotizacion");

                entity.Property(e => e.IdCxccargoOh).HasColumnName("ID_CXCCargoOH");

                entity.Property(e => e.IdCxpabonoPropinasStaffTiempoCompartido).HasColumnName("ID_CXPAbonoPropinasStaffTiempoCompartido");

                entity.Property(e => e.IdDispensarioPosicionCargaManguera).HasColumnName("ID_DispensarioPosicionCargaManguera");

                entity.Property(e => e.IdEmpresaSucursal).HasColumnName("ID_EmpresaSucursal");

                entity.Property(e => e.IdEmpresaSucursalOrigen).HasColumnName("ID_EmpresaSucursalOrigen");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdPeriodoAbrio).HasColumnName("ID_PeriodoAbrio");

                entity.Property(e => e.IdPeriodoCerro).HasColumnName("ID_PeriodoCerro");

                entity.Property(e => e.IdPoliza).HasColumnName("ID_Poliza");

                entity.Property(e => e.IdPolizaCancelacion).HasColumnName("ID_PolizaCancelacion");

                entity.Property(e => e.IdPolizaCostoVendido).HasColumnName("ID_PolizaCostoVendido");

                entity.Property(e => e.IdPolizaCostoVendidoCancelacion).HasColumnName("ID_PolizaCostoVendidoCancelacion");

                entity.Property(e => e.IdRuCfd).HasColumnName("ID_RU_CFD");

                entity.Property(e => e.IdTipoCambio).HasColumnName("ID_TipoCambio");

                entity.Property(e => e.IdTurnoAdministrativo).HasColumnName("ID_TurnoAdministrativo");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("ID_UsuarioAlta");

                entity.Property(e => e.IdUsuarioCambio).HasColumnName("ID_UsuarioCambio");

                entity.Property(e => e.IdUsuarioCancelo).HasColumnName("ID_UsuarioCancelo");

                entity.Property(e => e.IdUsuarioCerro).HasColumnName("ID_UsuarioCerro");

                entity.Property(e => e.IdUsuarioVendedor).HasColumnName("ID_UsuarioVendedor");

                entity.Property(e => e.IdVenta).HasColumnName("ID_Venta");

                entity.Property(e => e.IdVentaOrigen).HasColumnName("ID_VentaOrigen");

                entity.Property(e => e.IdZonaIva).HasColumnName("ID_ZonaIVA");

                entity.Property(e => e.Identificador)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Kilometraje).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Mensajeoh)
                    .HasColumnName("mensajeoh")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.MotivoCancelo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notas)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroAlta).HasColumnType("datetime");

                entity.Property(e => e.RegistroCambio).HasColumnType("datetime");

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdescuento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Terminal)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tieps)
                    .HasColumnName("TIEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Timporte).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Timpuesto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TimpuestoHospedaje)
                    .HasColumnName("TImpuestoHospedaje")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoRegistro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipoVenta)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TotalVolumen).HasColumnType("decimal(12, 3)");

                entity.Property(e => e.TretencionIeps)
                    .HasColumnName("TRetencionIEPS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TretencionIsr)
                    .HasColumnName("TRetencionISR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TretencionIva)
                    .HasColumnName("TRetencionIVA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tsubtotal)
                    .HasColumnName("TSubtotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ttotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UiVenta).HasColumnName("UI_Venta");

                entity.Property(e => e.Uuidcontrato).HasColumnName("UUIDContrato");

                entity.Property(e => e.ValorCambio).HasColumnType("decimal(18, 6)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
