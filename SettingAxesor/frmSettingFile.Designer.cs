namespace SettingAxesor
{
    partial class frmSettingFile
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingFile));
            this.BtnSaveSetting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nupMinutos = new System.Windows.Forms.NumericUpDown();
            this.nudHoraEjecucion = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBaseDato = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreServidor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTipoArchivoFtp = new System.Windows.Forms.TextBox();
            this.txtPassawordFtp = new System.Windows.Forms.TextBox();
            this.txtUsuarioFtp = new System.Windows.Forms.TextBox();
            this.txtNombreServidorFtp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnCerrarFormulario = new System.Windows.Forms.Button();
            this.BtnProbarConexionBaseDato = new System.Windows.Forms.Button();
            this.BtnProbarConexionFtp = new System.Windows.Forms.Button();
            this.pbLoandig = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMinutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraEjecucion)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoandig)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSaveSetting
            // 
            this.BtnSaveSetting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSaveSetting.Location = new System.Drawing.Point(32, 483);
            this.BtnSaveSetting.Name = "BtnSaveSetting";
            this.BtnSaveSetting.Size = new System.Drawing.Size(169, 29);
            this.BtnSaveSetting.TabIndex = 2;
            this.BtnSaveSetting.Text = "Guardar";
            this.BtnSaveSetting.UseVisualStyleBackColor = true;
            this.BtnSaveSetting.Click += new System.EventHandler(this.BtnSaveSetting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nupMinutos);
            this.groupBox1.Controls.Add(this.nudHoraEjecucion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(32, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración Hora de Ejecución";
            // 
            // nupMinutos
            // 
            this.nupMinutos.Location = new System.Drawing.Point(116, 84);
            this.nupMinutos.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nupMinutos.Name = "nupMinutos";
            this.nupMinutos.Size = new System.Drawing.Size(88, 25);
            this.nupMinutos.TabIndex = 3;
            // 
            // nudHoraEjecucion
            // 
            this.nudHoraEjecucion.Location = new System.Drawing.Point(116, 47);
            this.nudHoraEjecucion.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHoraEjecucion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHoraEjecucion.Name = "nudHoraEjecucion";
            this.nudHoraEjecucion.Size = new System.Drawing.Size(88, 25);
            this.nudHoraEjecucion.TabIndex = 3;
            this.nudHoraEjecucion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minutos *:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hora 24 *:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBaseDato);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTimeOut);
            this.groupBox2.Controls.Add(this.txtContrasenia);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNombreServidor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(32, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 205);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración Conexión Datos";
            // 
            // txtBaseDato
            // 
            this.txtBaseDato.Location = new System.Drawing.Point(172, 65);
            this.txtBaseDato.MaxLength = 50;
            this.txtBaseDato.Name = "txtBaseDato";
            this.txtBaseDato.Size = new System.Drawing.Size(171, 25);
            this.txtBaseDato.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Base de Datos *:";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Enabled = false;
            this.txtTimeOut.Location = new System.Drawing.Point(172, 156);
            this.txtTimeOut.MaxLength = 5;
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(88, 25);
            this.txtTimeOut.TabIndex = 5;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(172, 125);
            this.txtContrasenia.MaxLength = 25;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.Size = new System.Drawing.Size(152, 25);
            this.txtContrasenia.TabIndex = 4;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(172, 94);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(171, 25);
            this.txtUsuario.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "TimeOut :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Contraseña *:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Usuario*:";
            // 
            // txtNombreServidor
            // 
            this.txtNombreServidor.Location = new System.Drawing.Point(172, 34);
            this.txtNombreServidor.MaxLength = 50;
            this.txtNombreServidor.Name = "txtNombreServidor";
            this.txtNombreServidor.Size = new System.Drawing.Size(214, 25);
            this.txtNombreServidor.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre Servidor *:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTipoArchivoFtp);
            this.groupBox3.Controls.Add(this.txtPassawordFtp);
            this.groupBox3.Controls.Add(this.txtUsuarioFtp);
            this.groupBox3.Controls.Add(this.txtNombreServidorFtp);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(480, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 199);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuración Conexión FTP";
            // 
            // txtTipoArchivoFtp
            // 
            this.txtTipoArchivoFtp.Enabled = false;
            this.txtTipoArchivoFtp.Location = new System.Drawing.Point(162, 125);
            this.txtTipoArchivoFtp.MaxLength = 50;
            this.txtTipoArchivoFtp.Name = "txtTipoArchivoFtp";
            this.txtTipoArchivoFtp.Size = new System.Drawing.Size(155, 25);
            this.txtTipoArchivoFtp.TabIndex = 1;
            // 
            // txtPassawordFtp
            // 
            this.txtPassawordFtp.Location = new System.Drawing.Point(162, 94);
            this.txtPassawordFtp.MaxLength = 25;
            this.txtPassawordFtp.Name = "txtPassawordFtp";
            this.txtPassawordFtp.PasswordChar = '*';
            this.txtPassawordFtp.Size = new System.Drawing.Size(165, 25);
            this.txtPassawordFtp.TabIndex = 1;
            // 
            // txtUsuarioFtp
            // 
            this.txtUsuarioFtp.Location = new System.Drawing.Point(162, 63);
            this.txtUsuarioFtp.MaxLength = 50;
            this.txtUsuarioFtp.Name = "txtUsuarioFtp";
            this.txtUsuarioFtp.Size = new System.Drawing.Size(189, 25);
            this.txtUsuarioFtp.TabIndex = 1;
            // 
            // txtNombreServidorFtp
            // 
            this.txtNombreServidorFtp.Location = new System.Drawing.Point(162, 31);
            this.txtNombreServidorFtp.MaxLength = 50;
            this.txtNombreServidorFtp.Name = "txtNombreServidorFtp";
            this.txtNombreServidorFtp.Size = new System.Drawing.Size(254, 25);
            this.txtNombreServidorFtp.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tipo Archivos :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Contraseña *:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Usuario *:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nombre Servidor *:";
            // 
            // BtnCerrarFormulario
            // 
            this.BtnCerrarFormulario.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCerrarFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnCerrarFormulario.Location = new System.Drawing.Point(750, 483);
            this.BtnCerrarFormulario.Name = "BtnCerrarFormulario";
            this.BtnCerrarFormulario.Size = new System.Drawing.Size(146, 29);
            this.BtnCerrarFormulario.TabIndex = 5;
            this.BtnCerrarFormulario.Text = "Cerrar";
            this.BtnCerrarFormulario.UseVisualStyleBackColor = true;
            this.BtnCerrarFormulario.Click += new System.EventHandler(this.BtnCerrarFormulario_Click);
            // 
            // BtnProbarConexionBaseDato
            // 
            this.BtnProbarConexionBaseDato.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnProbarConexionBaseDato.ForeColor = System.Drawing.Color.Green;
            this.BtnProbarConexionBaseDato.Location = new System.Drawing.Point(32, 260);
            this.BtnProbarConexionBaseDato.Name = "BtnProbarConexionBaseDato";
            this.BtnProbarConexionBaseDato.Size = new System.Drawing.Size(260, 29);
            this.BtnProbarConexionBaseDato.TabIndex = 6;
            this.BtnProbarConexionBaseDato.Text = "Probar Conexión Base de Datos";
            this.BtnProbarConexionBaseDato.UseVisualStyleBackColor = true;
            this.BtnProbarConexionBaseDato.Click += new System.EventHandler(this.BtnProbarConexionBaseDato_Click);
            // 
            // BtnProbarConexionFtp
            // 
            this.BtnProbarConexionFtp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnProbarConexionFtp.ForeColor = System.Drawing.Color.Green;
            this.BtnProbarConexionFtp.Location = new System.Drawing.Point(480, 260);
            this.BtnProbarConexionFtp.Name = "BtnProbarConexionFtp";
            this.BtnProbarConexionFtp.Size = new System.Drawing.Size(260, 29);
            this.BtnProbarConexionFtp.TabIndex = 6;
            this.BtnProbarConexionFtp.Text = "Probar Conexión FTP";
            this.BtnProbarConexionFtp.UseVisualStyleBackColor = true;
            this.BtnProbarConexionFtp.Click += new System.EventHandler(this.BtnProbarConexionFtp_Click);
            // 
            // pbLoandig
            // 
            this.pbLoandig.Image = ((System.Drawing.Image)(resources.GetObject("pbLoandig.Image")));
            this.pbLoandig.Location = new System.Drawing.Point(833, 370);
            this.pbLoandig.Name = "pbLoandig";
            this.pbLoandig.Size = new System.Drawing.Size(69, 62);
            this.pbLoandig.TabIndex = 7;
            this.pbLoandig.TabStop = false;
            this.pbLoandig.Visible = false;
            // 
            // frmSettingFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 535);
            this.Controls.Add(this.pbLoandig);
            this.Controls.Add(this.BtnProbarConexionFtp);
            this.Controls.Add(this.BtnProbarConexionBaseDato);
            this.Controls.Add(this.BtnCerrarFormulario);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSaveSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettingFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Crear Archivo Axesor";
            this.Load += new System.EventHandler(this.frmSettingFile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMinutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraEjecucion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoandig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSaveSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreServidor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtBaseDato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnCerrarFormulario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreServidorFtp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTipoArchivoFtp;
        private System.Windows.Forms.TextBox txtPassawordFtp;
        private System.Windows.Forms.TextBox txtUsuarioFtp;
        private System.Windows.Forms.NumericUpDown nudHoraEjecucion;
        private System.Windows.Forms.NumericUpDown nupMinutos;
        private System.Windows.Forms.Button BtnProbarConexionBaseDato;
        private System.Windows.Forms.Button BtnProbarConexionFtp;
        private System.Windows.Forms.PictureBox pbLoandig;
    }
}

