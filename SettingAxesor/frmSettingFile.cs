namespace SettingAxesor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Windows.Forms;

    public partial class frmSettingFile : Form
    {
        private string fileSetting = "appsettings.json";
        private string configuracionDato = "ConnectionStringsSQlServer";
        private string keyNombreServidor = "NombreServidor";
        private string keyBaseDato = "NombreBaseDato";
        private string keyUsuario = "UsuarioBaseDato";
        private string keyPassawordDataBase = "PasswordUsuarioBaseDato";
        private string keyTimeOut = "Timeout";

        private string configuracionFTP = "ConfiguracionFtp";
        private string keyServidorFtp = "ServidorFtp";
        private string keyUsuarioFtp = "UsuarioFtp";
        private string keyPasswordFtp = "PasswordFtp";
        private string keyTiposArchivoEnviarFtp = "TiposArchivoEnviarFtp";

        private string configuracionEjecucion = "ConfiguracionHoraEjecucionProceso";
        private string keyHora24 = "Hora24";
        private string keyMinuto60 = "Minuto60";
        public dynamic ValoresJson { get; set; }

        public frmSettingFile()
        {
            InitializeComponent();
        }

        private void BtnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveSetting();
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
                this.LoadValoresJson();
                this.LoadValueControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardar configuración: " + ex.Message);
            }
        }

        private void LoadValoresJson()
        {
            string json = File.ReadAllText(fileSetting);
            this.ValoresJson = JsonConvert.DeserializeObject(json);
        }

        private void LoadValueControl()
        {
            if (this.ValoresJson == null)
            {
                MessageBox.Show("No se pudo cargar la configuración, por favor verifique.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.txtNombreServidor.Text = this.ValoresJson[configuracionDato][keyNombreServidor];
            this.txtBaseDato.Text = this.ValoresJson[configuracionDato][keyBaseDato];
            this.txtUsuario.Text = this.ValoresJson[configuracionDato][keyUsuario];
            this.txtContrasenia.Text = this.ValoresJson[configuracionDato][keyPassawordDataBase];
            this.txtTimeOut.Text = this.ValoresJson[configuracionDato][keyTimeOut];

            this.txtNombreServidorFtp.Text = this.ValoresJson[configuracionFTP][keyServidorFtp];
            this.txtUsuarioFtp.Text = this.ValoresJson[configuracionFTP][keyUsuarioFtp];
            this.txtPassawordFtp.Text = this.ValoresJson[configuracionFTP][keyPasswordFtp];
            this.txtTipoArchivoFtp.Text = this.ValoresJson[configuracionFTP][keyTiposArchivoEnviarFtp];           

            this.nudHoraEjecucion.Text = this.ValoresJson[configuracionEjecucion][keyHora24];            
            this.nupMinutos.Text = this.ValoresJson[configuracionEjecucion][keyMinuto60];
        }

        private void SaveSetting()
        {
            this.ValoresJson[configuracionEjecucion][keyHora24] = this.nudHoraEjecucion.Text;            
            this.ValoresJson[configuracionEjecucion][keyMinuto60] = this.nupMinutos.Text;

            string output = JsonConvert.SerializeObject(this.ValoresJson, Formatting.Indented);
            File.WriteAllText(fileSetting, output);
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
    }
}