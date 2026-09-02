namespace CasaSchimbValutar.Forms
{
    partial class FormTranzactie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbValuta = new System.Windows.Forms.ComboBox();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.numSumaValuta = new System.Windows.Forms.NumericUpDown();
            this.lblSumaRON = new System.Windows.Forms.Label();
            this.dtpDataTranzactie = new System.Windows.Forms.DateTimePicker();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.epTranzactie = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCursActual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSumaValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTranzactie)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbValuta
            // 
            this.cmbValuta.FormattingEnabled = true;
            this.cmbValuta.Location = new System.Drawing.Point(162, 67);
            this.cmbValuta.Name = "cmbValuta";
            this.cmbValuta.Size = new System.Drawing.Size(121, 21);
            this.cmbValuta.TabIndex = 0;
            this.cmbValuta.SelectedIndexChanged += new System.EventHandler(this.cmbValuta_SelectedIndexChanged);
            // 
            // cmbTip
            // 
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Location = new System.Drawing.Point(161, 140);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(121, 21);
            this.cmbTip.TabIndex = 1;
            // 
            // numSumaValuta
            // 
            this.numSumaValuta.DecimalPlaces = 2;
            this.numSumaValuta.Location = new System.Drawing.Point(162, 210);
            this.numSumaValuta.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numSumaValuta.Name = "numSumaValuta";
            this.numSumaValuta.Size = new System.Drawing.Size(120, 20);
            this.numSumaValuta.TabIndex = 2;
            this.numSumaValuta.ValueChanged += new System.EventHandler(this.numSumaValuta_ValueChanged);
            // 
            // lblSumaRON
            // 
            this.lblSumaRON.AutoSize = true;
            this.lblSumaRON.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumaRON.Location = new System.Drawing.Point(123, 296);
            this.lblSumaRON.Name = "lblSumaRON";
            this.lblSumaRON.Size = new System.Drawing.Size(203, 20);
            this.lblSumaRON.TabIndex = 4;
            this.lblSumaRON.Text = "Suma calculata automat";
            // 
            // dtpDataTranzactie
            // 
            this.dtpDataTranzactie.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDataTranzactie.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataTranzactie.Location = new System.Drawing.Point(126, 372);
            this.dtpDataTranzactie.Name = "dtpDataTranzactie";
            this.dtpDataTranzactie.Size = new System.Drawing.Size(200, 20);
            this.dtpDataTranzactie.TabIndex = 5;
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalveaza.Location = new System.Drawing.Point(156, 420);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(125, 61);
            this.btnSalveaza.TabIndex = 6;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click_1);
            // 
            // epTranzactie
            // 
            this.epTranzactie.ContainerControl = this;
            // 
            // lblCursActual
            // 
            this.lblCursActual.AutoSize = true;
            this.lblCursActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursActual.Location = new System.Drawing.Point(123, 256);
            this.lblCursActual.Name = "lblCursActual";
            this.lblCursActual.Size = new System.Drawing.Size(102, 20);
            this.lblCursActual.TabIndex = 7;
            this.lblCursActual.Text = "Curs curent";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valuta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cantitate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tip tranzactie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data";
            // 
            // FormTranzactie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 493);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCursActual);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.dtpDataTranzactie);
            this.Controls.Add(this.lblSumaRON);
            this.Controls.Add(this.numSumaValuta);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.cmbValuta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTranzactie";
            this.Text = "FormTranzactie";
            ((System.ComponentModel.ISupportInitialize)(this.numSumaValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTranzactie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbValuta;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.NumericUpDown numSumaValuta;
        private System.Windows.Forms.Label lblSumaRON;
        private System.Windows.Forms.DateTimePicker dtpDataTranzactie;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.ErrorProvider epTranzactie;
        private System.Windows.Forms.Label lblCursActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}