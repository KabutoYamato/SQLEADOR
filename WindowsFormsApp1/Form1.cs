using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEADOR.Conexiones;
using System.Windows.Forms;


namespace SQLEADOR
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fpTest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fpPath.Text))
            {
                if (Directory.GetFiles(fpPath.Text, "*.dbf").Length > 0)
                {
                    fpTested.Checked = true;
                    MessageBox.Show(null,"Carpeta con archivos validos","Éxito");
                }
                else
                {
                    fpTested.Checked = false;
                    MessageBox.Show(null,"La carpeta no contiene archivos validos","Error");
                }
            }
            else {
                fpTested.Checked = false;
                MessageBox.Show(null,"Debe seleccionar una ruta valida","Error");
            }
            
        }

        private void msTest_Click(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrWhiteSpace(msDatabase.Text) && 
                !string.IsNullOrWhiteSpace(msPassword.Text) &&
                !string.IsNullOrWhiteSpace(msPort.Text)     &&
                !string.IsNullOrWhiteSpace(msServer.Text)   &&
                !string.IsNullOrWhiteSpace(msUser.Text)
            ) {
                Conexion msTest = new Conexion(msServer.Text,msPort.Text,msDatabase.Text,msUser.Text,msPassword.Text);
                bool ok = Mysql.testConnection(msTest);
                if (ok)
                {
                    msTested.Checked = true;
                    MessageBox.Show(null,"Conexion Establecida correctamente","Éxito");
                }
                else
                {
                    msTested.Checked = false;
                    MessageBox.Show(null,"Error al iniciar la conexión","Error");
                }
            }
            else
            {
                msTested.Checked = false;
                MessageBox.Show(null,"Alguno de los campos esta vacio","Error");
            }
        }

        private void fpFindDB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Seleccione la carpeta donde están los archivos del sie";
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                    fpPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void continue_Click(object sender, EventArgs e)
        {
            if (msTested.Checked) {
                if (fpTested.Checked)
                {
                    Conexion ms = new Conexion(msServer.Text, msPort.Text, msDatabase.Text, msUser.Text, msPassword.Text);
                    Conexion fp = new Conexion(fpPath.Text);
                    Main m = new Main(this,ms,fp);
                    m.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show(null, "Debe escoger una ruta valida con archivos dbf antes de continuar", "Error");
                }
            }
            else {
                MessageBox.Show(null, "Debe crear una conexion con mysql valida antes de continuar", "Error");
            }
        }
    }
}
