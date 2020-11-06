

namespace SettingAxesor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Newtonsoft.Json;

    public partial class frmSettingFile : Form
    {
        string fileSetting = "appsettings.json";
        string configuracionDato = "ConnectionStringsSQlServer";
        string keyNombreServidor = "NombreServidor";
        string keyBaseDato = "NombreBaseDato";
        string keyUsuario = "UsuarioBaseDato";
        string keyPassawordDataBase = "PasswordUsuarioBaseDato";
        string keyTimeOut = "Timeout";

        string configuracionEjecucion = "ConfiguracionHoraEjecucionProceso";
        string keyHora24 = "Hora24";
        string keyMinuto60 = "Minuto60";
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

            this.txtHoraEjecucion.Text = this.ValoresJson[configuracionEjecucion][keyHora24];
            this.txtMinutos.Text = this.ValoresJson[configuracionEjecucion][keyMinuto60];

        }

        private void SaveSetting()
        {
            this.ValoresJson[configuracionEjecucion][keyHora24] = this.txtHoraEjecucion.Text;
            this.ValoresJson[configuracionEjecucion][keyMinuto60] = this.txtMinutos.Text;

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
