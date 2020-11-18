namespace SettingAxesor
{
    using SettingAxesor.AxesorBusiness.IBusiness;
    using SettingAxesor.AxesorCrossCutting.Entitie;
    using System;
    using System.Windows.Forms;

    public partial class frmSettingFile : Form
    {
        private readonly IConfigurationBusiness configurationBusiness;

        public dynamic ValoresJson { get; set; }

        public frmSettingFile(IConfigurationBusiness configurationBusiness)
        {
            InitializeComponent();
            this.configurationBusiness = configurationBusiness;
        }

        private void BtnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                string message = this.ValidateFieldDataBase();
                message += Environment.NewLine + this.ValidateFieldFtp();
                message += Environment.NewLine + this.ValidateFieldHoursMinuted();
                if (!string.IsNullOrEmpty(message.Trim()))
                {
                    MessageBox.Show(message, "Validación Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.configurationBusiness.SaveConfigurationHours(this.LoadDataHoursMinuted());
                MessageBox.Show("Configuración guardada con éxito.", "Guardar Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Aplicación: " + ex.Message);
            }
        }

        private void frmSettingFile_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadValueControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargar configuración: " + ex.Message);
            }
        }

        private void LoadValueControl()
        {
            var dataConfiguration = this.configurationBusiness.LoadValueControl();
            if (dataConfiguration == null)
            {
                MessageBox.Show("No se pudo cargar la configuración, por favor verifique.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.txtNombreServidor.Text = dataConfiguration.Item1.NombreServidor;
            this.txtBaseDato.Text = dataConfiguration.Item1.NombreBaseDato;
            this.txtUsuario.Text = dataConfiguration.Item1.UsuarioBaseDato;
            this.txtContrasenia.Text = dataConfiguration.Item1.PasswordUsuarioBaseDato;
            this.txtTimeOut.Text = dataConfiguration.Item1.TimeOut;

            this.txtNombreServidorFtp.Text = dataConfiguration.Item2.ServidorFtp;
            this.txtUsuarioFtp.Text = dataConfiguration.Item2.UsuarioFtp;
            this.txtPassawordFtp.Text = dataConfiguration.Item2.PasswordFtp;
            this.txtTipoArchivoFtp.Text = dataConfiguration.Item2.TipoArchivoFtp;

            this.nudHoraEjecucion.Text = dataConfiguration.Item3.Hora24;
            this.nupMinutos.Text = dataConfiguration.Item3.Minuto60;
        }

        private void BtnCerrarFormulario_Click(object sender, EventArgs e)
        {
            const string message = "¿Está seguro de cerrar la aplicación de configuración.?";
            const string caption = "Cerrar Formulario";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                // cancel the closure of the form.
                this.Close();
            }
        }

        private void BtnProbarConexionBaseDato_Click(object sender, EventArgs e)
        {
            string message = this.ValidateFieldDataBase();
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Validación Conexión Base de Dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool result = this.configurationBusiness.VerifyConnection(this.LoadDataDataBase());
            if (result)
            {
                // BtnProbarConexionBaseDato.ForeColor=Color
                MessageBox.Show("La conexión se realizo con éxito", "Conexión Base de Dato Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo conectar al servidor de base de datos, por favor verifique.", "Conexión Base de Dato Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ConfiguracionStringsServerDataBaseEntitie LoadDataDataBase()
        {
            return new ConfiguracionStringsServerDataBaseEntitie
            {
                NombreServidor = this.txtNombreServidor.Text.Trim(),
                NombreBaseDato = this.txtBaseDato.Text.Trim(),
                UsuarioBaseDato = this.txtUsuario.Text.Trim(),
                PasswordUsuarioBaseDato = this.txtContrasenia.Text.Trim(),
                TimeOut = this.txtTimeOut.Text.Trim()
            };
        }

        private ConfiguracionFtpEntitie LoadDataFtp()
        {
            return new ConfiguracionFtpEntitie
            {
                ServidorFtp = this.txtNombreServidorFtp.Text.Trim(),
                UsuarioFtp = this.txtUsuarioFtp.Text.Trim(),
                PasswordFtp = this.txtPassawordFtp.Text.Trim(),
                TipoArchivoFtp = this.txtTipoArchivoFtp.Text.Trim()
            };
        }

        private ConfiguracionHoraEjecucionProcesoEntitie LoadDataHoursMinuted()
        {
            return new ConfiguracionHoraEjecucionProcesoEntitie
            {
                Hora24 = this.nudHoraEjecucion.Text.Trim(),
                Minuto60 = this.nupMinutos.Text.Trim()
            };
        }

        private string ValidateFieldDataBase()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(this.txtNombreServidor.Text.Trim()))
            {
                message = "* El campo nombre del servidor es requerido, por favor verifique.";
            }
            if (string.IsNullOrEmpty(this.txtBaseDato.Text.Trim()))
            {
                message += Environment.NewLine + "* El campo Base de Dato es requerido, por favor verifique.";
            }
            if (string.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
            {
                message += Environment.NewLine + "* El campo Usuario es requerido, por favor verifique.";
            }
            if (string.IsNullOrEmpty(this.txtContrasenia.Text.Trim()))
            {
                message += Environment.NewLine + "* El campo Contraseña es requerido, por favor verifique.";
            }
            return message;
        }

        private string ValidateFieldFtp()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(this.txtNombreServidorFtp.Text.Trim()))
            {
                message = "* El campo nombre del servidor ftp es requerido, por favor verifique.";
            }
            if (string.IsNullOrEmpty(this.txtUsuarioFtp.Text.Trim()))
            {
                message += Environment.NewLine + "* El campo usuario ftp es requerido, por favor verifique.";
            }
            if (string.IsNullOrEmpty(this.txtPassawordFtp.Text.Trim()))
            {
                message += Environment.NewLine + "* El campo password ftp requerido, por favor verifique.";
            }

            return message;
        }

        private string ValidateFieldHoursMinuted()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(this.nudHoraEjecucion.Text.Trim()))
            {
                message = "* El campo horas es requerido, por favor verifique.";
            }
            if (string.IsNullOrEmpty(this.nupMinutos.Text.Trim()))
            {
                message += Environment.NewLine + "* El campo minuto es requerido, por favor verifique.";
            }

            return message;
        }
    }
}