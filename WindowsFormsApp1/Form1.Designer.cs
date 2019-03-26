namespace SQLEADOR
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.msPassword = new System.Windows.Forms.TextBox();
            this.msTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.msDatabase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.msUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.msPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.msServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpTest = new System.Windows.Forms.Button();
            this.fpPath = new System.Windows.Forms.TextBox();
            this.fpFindDB = new System.Windows.Forms.Button();
            this.wcontinue = new System.Windows.Forms.Button();
            this.fpTested = new System.Windows.Forms.CheckBox();
            this.msTested = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.msPassword);
            this.groupBox1.Controls.Add(this.msTest);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.msDatabase);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.msUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.msPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.msServer);
            this.groupBox1.Location = new System.Drawing.Point(34, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mysql";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Base de datos";
            // 
            // msPassword
            // 
            this.msPassword.Location = new System.Drawing.Point(104, 161);
            this.msPassword.Name = "msPassword";
            this.msPassword.Size = new System.Drawing.Size(133, 20);
            this.msPassword.TabIndex = 9;
            // 
            // msTest
            // 
            this.msTest.Location = new System.Drawing.Point(255, 115);
            this.msTest.Name = "msTest";
            this.msTest.Size = new System.Drawing.Size(111, 23);
            this.msTest.TabIndex = 8;
            this.msTest.Text = "Probar Conexión";
            this.msTest.UseVisualStyleBackColor = true;
            this.msTest.Click += new System.EventHandler(this.msTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contraseña";
            // 
            // msDatabase
            // 
            this.msDatabase.Location = new System.Drawing.Point(104, 82);
            this.msDatabase.Name = "msDatabase";
            this.msDatabase.Size = new System.Drawing.Size(133, 20);
            this.msDatabase.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario";
            // 
            // msUser
            // 
            this.msUser.Location = new System.Drawing.Point(104, 122);
            this.msUser.Name = "msUser";
            this.msUser.Size = new System.Drawing.Size(133, 20);
            this.msUser.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Puerto";
            // 
            // msPort
            // 
            this.msPort.Location = new System.Drawing.Point(293, 37);
            this.msPort.Name = "msPort";
            this.msPort.Size = new System.Drawing.Size(73, 20);
            this.msPort.TabIndex = 2;
            this.msPort.Text = "3306";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor";
            // 
            // msServer
            // 
            this.msServer.Location = new System.Drawing.Point(104, 37);
            this.msServer.Name = "msServer";
            this.msServer.Size = new System.Drawing.Size(133, 20);
            this.msServer.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fpTest);
            this.groupBox2.Controls.Add(this.fpPath);
            this.groupBox2.Controls.Add(this.fpFindDB);
            this.groupBox2.Location = new System.Drawing.Point(34, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 111);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FoxPro";
            // 
            // fpTest
            // 
            this.fpTest.Location = new System.Drawing.Point(255, 71);
            this.fpTest.Name = "fpTest";
            this.fpTest.Size = new System.Drawing.Size(111, 23);
            this.fpTest.TabIndex = 2;
            this.fpTest.Text = "Probar Conexión";
            this.fpTest.UseVisualStyleBackColor = true;
            this.fpTest.Click += new System.EventHandler(this.fpTest_Click);
            // 
            // fpPath
            // 
            this.fpPath.Enabled = false;
            this.fpPath.Location = new System.Drawing.Point(124, 31);
            this.fpPath.Name = "fpPath";
            this.fpPath.Size = new System.Drawing.Size(242, 20);
            this.fpPath.TabIndex = 1;
            // 
            // fpFindDB
            // 
            this.fpFindDB.Location = new System.Drawing.Point(26, 29);
            this.fpFindDB.Name = "fpFindDB";
            this.fpFindDB.Size = new System.Drawing.Size(75, 23);
            this.fpFindDB.TabIndex = 0;
            this.fpFindDB.Text = "Buscar BDD";
            this.fpFindDB.UseVisualStyleBackColor = true;
            this.fpFindDB.Click += new System.EventHandler(this.fpFindDB_Click);
            // 
            // wcontinue
            // 
            this.wcontinue.Location = new System.Drawing.Point(222, 382);
            this.wcontinue.Name = "wcontinue";
            this.wcontinue.Size = new System.Drawing.Size(102, 23);
            this.wcontinue.TabIndex = 4;
            this.wcontinue.Text = "Continuar";
            this.wcontinue.UseVisualStyleBackColor = true;
            this.wcontinue.Click += new System.EventHandler(this.continue_Click);
            // 
            // fpTested
            // 
            this.fpTested.AutoSize = true;
            this.fpTested.Enabled = false;
            this.fpTested.Location = new System.Drawing.Point(73, 370);
            this.fpTested.Name = "fpTested";
            this.fpTested.Size = new System.Drawing.Size(59, 17);
            this.fpTested.TabIndex = 5;
            this.fpTested.Text = "FoxPro";
            this.fpTested.UseVisualStyleBackColor = true;
            // 
            // msTested
            // 
            this.msTested.AutoSize = true;
            this.msTested.Enabled = false;
            this.msTested.Location = new System.Drawing.Point(73, 396);
            this.msTested.Name = "msTested";
            this.msTested.Size = new System.Drawing.Size(53, 17);
            this.msTested.TabIndex = 6;
            this.msTested.Text = "Mysql";
            this.msTested.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 455);
            this.Controls.Add(this.msTested);
            this.Controls.Add(this.fpTested);
            this.Controls.Add(this.wcontinue);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Conexión";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox msServer;
        private System.Windows.Forms.Button msTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox msDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox msUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox msPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button fpTest;
        private System.Windows.Forms.TextBox fpPath;
        private System.Windows.Forms.Button fpFindDB;
        private System.Windows.Forms.Button wcontinue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox msPassword;
        private System.Windows.Forms.CheckBox fpTested;
        private System.Windows.Forms.CheckBox msTested;
    }
}

