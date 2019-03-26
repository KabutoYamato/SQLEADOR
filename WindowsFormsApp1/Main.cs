using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLEADOR.Conexiones;


/* Paradigmanizador */
namespace SQLEADOR
{
    public partial class Main : Form
    {

        Form1 padre;
        Conexion mscondata, fpcondata;
        Mysql msconn;
        Foxpro fpconn;

        //string Periodo_ant = "3172";
        //string Periodo = "3183";

        string periodo = ""; //variable para almacenar el periodo 
        private int cantAlumnos = 0; //El total de alumnos
        private string matricula = ""; //la matricula de cada alumno
        private int iterator = 0; //variable iteradora

        public Main(Form1 f, Conexion ms, Conexion fp)
        {
            mscondata = ms;
            fpcondata = fp;
            this.padre = f;
            InitializeComponent();
        }

        private void Main_closing(object sender, FormClosingEventArgs e)
        {
            fpconn.close();
            Application.Exit();
        }

        private void bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            msconn = new Mysql(mscondata);
            msconn.cleandb();
            while (iterator < cantAlumnos)
            {
                bool[] resultados = new bool[4];
                resultados[0] = msconn.subirAlumno(fpconn.getAlumno(matricula).Rows[0]);
                resultados[1] = msconn.subirCalificaciones(fpconn.getCalificaciones(periodo, matricula));
                resultados[2] = msconn.subirHorario(fpconn.getHorario(periodo, matricula));
                resultados[3] = msconn.subirKardex(fpconn.getKardex(matricula));
                
                bw1.ReportProgress(iterator,resultados);
                iterator++;
            }
            msconn.close();
            MessageBox.Show(null, "Proceso terminado", "Info");
        }

        private void bw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bool[] resultados = (bool[])e.UserState;
            int cont = e.ProgressPercentage;
            aluCount.Text = (cont + 1).ToString();
            aluCount.Update();
            for (int i = 0; i < resultados.Length; i++) {
                if (resultados[i] == true)
                {
                    Alumnos.Rows[cont].Cells[i + 1].Style.ForeColor = Color.Green;
                    Alumnos.Rows[cont].Cells[i + 1].Value = "Exito";
                }
                else {
                    Alumnos.Rows[cont].Cells[i + 1].Style.ForeColor = Color.Red;
                    Alumnos.Rows[cont].Cells[i + 1].Value = "Error";
                }
            }
            Alumnos.Update();
            if (cont + 1 < cantAlumnos) {
                matricula = Alumnos.Rows[cont + 1].Cells[0].Value.ToString().Trim();
            }
            
        }

        private void upload_Click(object sender, EventArgs e)
        {
            matricula = Alumnos.Rows[0].Cells[0].Value.ToString();
            if (!bw1.IsBusy) {
                bw1.RunWorkerAsync();
            }
        }

        private void fill_Click(object sender, EventArgs e)
        {
            try
            {
                fpconn = new Foxpro(fpcondata);
                periodo = periodotb.Text;
                DataTable dt = fpconn.getMatriculas(periodo);
                dt.Columns[0].ColumnName = "Matricula";
                dt.Columns.Add(new DataColumn("Informacion"));
                dt.Columns.Add(new DataColumn("Calificaciones"));
                dt.Columns.Add(new DataColumn("Horario"));
                dt.Columns.Add(new DataColumn("Kardex"));

                Alumnos.DataSource = dt;

                foreach (DataGridViewRow row in Alumnos.Rows)
                {
                    row.HeaderCell.Value = String.Format( "{0}", row.Index + 1);
                }

                //inicializar valores para el worker
                cantAlumnos = Alumnos.Rows.Count;
                aluTotal.Text = cantAlumnos.ToString();
                upload.Enabled = true;
            }
            catch (Exception exc) {
                MessageBox.Show(null,exc.Message,"Error");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
