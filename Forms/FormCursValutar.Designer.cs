namespace CasaSchimbValutar.Forms
{
    partial class FormCursValutar
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
            this.dtpDataCurs = new System.Windows.Forms.DateTimePicker();
            this.numCursLaRON = new System.Windows.Forms.NumericUpDown();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.epCurs = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCursLaRON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCurs)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbValuta
            // 
            this.cmbValuta.FormattingEnabled = true;
            this.cmbValuta.Location = new System.Drawing.Point(104, 33);
            this.cmbValuta.Name = "cmbValuta";
            this.cmbValuta.Size = new System.Drawing.Size(200, 21);
            this.cmbValuta.TabIndex = 0;
            // 
            // dtpDataCurs
            // 
            this.dtpDataCurs.Location = new System.Drawing.Point(104, 100);
            this.dtpDataCurs.Name = "dtpDataCurs";
            this.dtpDataCurs.Size = new System.Drawing.Size(200, 20);
            this.dtpDataCurs.TabIndex = 1;
            // 
            // numCursLaRON
            // 
            this.numCursLaRON.DecimalPlaces = 4;
            this.numCursLaRON.Location = new System.Drawing.Point(104, 172);
            this.numCursLaRON.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numCursLaRON.Name = "numCursLaRON";
            this.numCursLaRON.Size = new System.Drawing.Size(200, 20);
            this.numCursLaRON.TabIndex = 2;
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalveaza.Location = new System.Drawing.Point(138, 235);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(137, 70);
            this.btnSalveaza.TabIndex = 3;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click_1);
            // 
            // epCurs
            // 
            this.epCurs.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valuta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Curs (RON)";
            // 
            // FormCursValutar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 353);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.numCursLaRON);
            this.Controls.Add(this.dtpDataCurs);
            this.Controls.Add(this.cmbValuta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCursValutar";
            this.Text = "FormCursValutar";
            ((System.ComponentModel.ISupportInitialize)(this.numCursLaRON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbValuta;
        private System.Windows.Forms.DateTimePicker dtpDataCurs;
        private System.Windows.Forms.NumericUpDown numCursLaRON;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.ErrorProvider epCurs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}