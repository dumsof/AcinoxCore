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
            this.BtnSaveSetting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinutos = new System.Windows.Forms.TextBox();
            this.txtHoraEjecucion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSaveSetting
            // 
            this.BtnSaveSetting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveSetting.ForeColor = System.Drawing.Color.Green;
            this.BtnSaveSetting.Location = new System.Drawing.Point(32, 357);
            this.BtnSaveSetting.Name = "BtnSaveSetting";
            this.BtnSaveSetting.Size = new System.Drawing.Size(169, 29);
            this.BtnSaveSetting.TabIndex = 2;
            this.BtnSaveSetting.Text = "Save Setting";
            this.BtnSaveSetting.UseVisualStyleBackColor = true;
            this.BtnSaveSetting.Click += new System.EventHandler(this.BtnSaveSetting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMinutos);
            this.groupBox1.Controls.Add(this.txtHoraEjecucion);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(32, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cofiguración Hora Ejecución";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minutos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hora 24:";
            // 
            // txtMinutos
            // 
            this.txtMinutos.Location = new System.Drawing.Point(116, 78);
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(125, 25);
            this.txtMinutos.TabIndex = 1;
            // 
            // txtHoraEjecucion
            // 
            this.txtHoraEjecucion.Location = new System.Drawing.Point(116, 47);
            this.txtHoraEjecucion.Name = "txtHoraEjecucion";
            this.txtHoraEjecucion.Size = new System.Drawing.Size(125, 25);
            this.txtHoraEjecucion.TabIndex = 0;
            // 
            // frmSettingFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSaveSetting);
            this.Name = "frmSettingFile";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmSettingFile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSaveSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMinutos;
        private System.Windows.Forms.TextBox txtHoraEjecucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

