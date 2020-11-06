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

namespace SettingAxesor
{
    public partial class frmSettingFile : Form
    {
        string fileSetting = "appsettings.json";
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
                MessageBox.Show("Configuración guardada con exito.");
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
                MessageBox.Show("No se pudo cargar la configuración, por favor verifique.");
                return;
            }
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
    }
}
