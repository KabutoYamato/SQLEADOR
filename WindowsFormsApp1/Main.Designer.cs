namespace SQLEADOR
{
    partial class Main
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
            this.Alumnos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.aluCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.Button();
            this.aluTotal = new System.Windows.Forms.Label();
            this.bw1 = new System.ComponentModel.BackgroundWorker();
            this.periodotb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // Alumnos
            // 
            this.Alumnos.AllowUserToAddRows = false;
            this.Alumnos.AllowUserToDeleteRows = false;
            this.Alumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Alumnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Alumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Alumnos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Alumnos.Location = new System.Drawing.Point(0, 168);
            this.Alumnos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Alumnos.Name = "Alumnos";
            this.Alumnos.ReadOnly = true;
            this.Alumnos.Size = new System.Drawing.Size(567, 307);
            this.Alumnos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subiendo alumno";
            // 
            // aluCount
            // 
            this.aluCount.Location = new System.Drawing.Point(124, 115);
            this.aluCount.Name = "aluCount";
            this.aluCount.Size = new System.Drawing.Size(57, 23);
            this.aluCount.TabIndex = 2;
            this.aluCount.Text = "0";
            this.aluCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "de";
            // 
            // upload
            // 
            this.upload.Enabled = false;
            this.upload.Location = new System.Drawing.Point(383, 114);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(135, 23);
            this.upload.TabIndex = 4;
            this.upload.Text = "Subir Informacion";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // aluTotal
            // 
            this.aluTotal.Location = new System.Drawing.Point(212, 114);
            this.aluTotal.Name = "aluTotal";
            this.aluTotal.Size = new System.Drawing.Size(57, 23);
            this.aluTotal.TabIndex = 5;
            this.aluTotal.Text = "0";
            this.aluTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bw1
            // 
            this.bw1.WorkerReportsProgress = true;
            this.bw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw1_DoWork);
            this.bw1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw1_ProgressChanged);
            // 
            // periodotb
            // 
            this.periodotb.Location = new System.Drawing.Point(142, 50);
            this.periodotb.Name = "periodotb";
            this.periodotb.Size = new System.Drawing.Size(104, 20);
            this.periodotb.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Periodo";
            // 
            // fill
            // 
            this.fill.Location = new System.Drawing.Point(383, 47);
            this.fill.Name = "fill";
            this.fill.Size = new System.Drawing.Size(135, 23);
            this.fill.TabIndex = 8;
            this.fill.Text = "Obtener Alumnos";
            this.fill.UseVisualStyleBackColor = true;
            this.fill.Click += new System.EventHandler(this.fill_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 475);
            this.Controls.Add(this.fill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.periodotb);
            this.Controls.Add(this.aluTotal);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aluCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Alumnos);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_closing);
            ((System.ComponentModel.ISupportInitialize)(this.Alumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Alumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label aluCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Label aluTotal;
        private System.ComponentModel.BackgroundWorker bw1;
        private System.Windows.Forms.TextBox periodotb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fill;
    }
}