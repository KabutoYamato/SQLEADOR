using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        public static string Periodo = "3172";
        public static Dictionary<String, String> Conexion = new Dictionary<string, string>
        {
            { "Host","den1.mysql6.gear.host" },
            { "Port","3306" },
            { "Database","kristensie" },
            { "User","kristensie" },
            { "Pass","Ef6jTY_7_00w" }
        };
        public static Dictionary<String, String> Obtener = new Dictionary<String, String>
        {
            {"Alumnos",
                "select distinct " +
                "A.aluctr, A.alupas, A.alunom, A.aluapp, A.aluapm, CAL.carcve, CAL.calcac, " +
                "CAL.calsit, P.pdocve, P.pdoini, P.pdoter, A.alucur, A.alunac, A.alucol, " +
                "A.alucll, A.alunum, A.aluciu, A.alucpo, A.alute1, A.alute2, A.alumai " +
                "from DALUMN A " +
                "inner join DCALUM CAL on CAL.aluctr = A.aluctr " +
                "inner join DPERIO P on P.pdocve = CAL.caling " +
                "inner join DLISTA C on C.aluctr = A.aluctr " +
                "where  CAL.calsit = \"1\" and C.pdocve = \"{0}\" " +
                "order by A.aluctr asc" },
            {"Calificaciones",
                "select " +
                "C.aluctr,M.matnom,C.gpocve,C.liscal,C.lispa1,C.lispa2,C.lispa3,C.lispa4, C.lispa5 " +
                "from DLISTA C " +
                "inner join DMATER M on M.matcve = C.matcve " +
                "where C.pdocve = \"{0}\" and C.aluctr = \"{1}\""},
            {"Kardex",
                "select " +
                "K.aluctr,M.matnom,K.pdocve1,K.karcal,K.tcacve " +
                "from DKARDE K " +
                "inner join DMATER M on M.matcve = K.matcve " +
                "where K.aluctr = \"{0}\""},
            {"Horario",
                "select " +
                "L.aluctr,H.matcve,M.matnom,P.persig,P.perape,P.pernom,H.lunhra,H.marhra,H.miehra,H.juehra,H.viehra " +
                "from DLISTA L " +
                "inner join DGRUPO H on H.gpocve = L.gpocve and H.pdocve = L.pdocve and H.matcve = L.matcve " +
                "inner join DMATER M on M.matcve = H.matcve " +
                "inner join DPERSO P on P.percve = H.percve " +
                "where L.pdocve = \"{0}\" and L.aluctr = \"{1}\""}
        };

        static void Main(string[] args)
        {
            DataTable Alumnos;
            DataTable Calificaciones;
            DataTable Kardex;
            DataTable Horario;

            OleDbConnection connectionHandler = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=C:\SIE\BD");

            connectionHandler.Open();

            if (connectionHandler.State == ConnectionState.Open)
            {
                Alumnos = getInfo(connectionHandler, Obtener["Alumnos"], Periodo);
                //Alumnos = getInfo(connectionHandler,"select * from DCALUM where aluctr = \"201500120\"","");
                //imprimirTabla(Alumnos);
                mysql clean = new mysql(Conexion["Host"], Conexion["Port"], Conexion["Database"], Conexion["User"], Conexion["Pass"]);
                clean.cleandb();
                clean.terminar();

                for (int i = 0; i < Alumnos.Rows.Count; i++)
                {
                    DataRow Alumno = Alumnos.Rows[i];
                    String Matricula = Alumno[0].ToString().Trim();
                    if (!String.IsNullOrWhiteSpace(Matricula))
                    {
                        try
                        {
                            mysql mybd = new mysql(Conexion["Host"], Conexion["Port"], Conexion["Database"], Conexion["User"], Conexion["Pass"]);
                                Kardex = getInfo(connectionHandler, Obtener["Kardex"], Matricula);
                                Calificaciones = getInfo(connectionHandler, Obtener["Calificaciones"], Periodo, Matricula);
                                Horario = getInfo(connectionHandler, Obtener["Horario"], Periodo, Matricula);
                                Console.WriteLine("subiendo Alumno " + Matricula);
                                mybd.subirAlumno(Alumno);
                                Console.WriteLine("subiendo Kardex");
                                mybd.subirKardex(Kardex);
                                Console.WriteLine("subiendo Calificaciones");
                                mybd.subirCalificaciones(Calificaciones);
                                Console.WriteLine("subiendo Horario");
                                mybd.subirHorario(Horario);
                            mybd.terminar();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    
                }
                connectionHandler.Close();
                Console.ReadKey();
            }

            
        }


        public static DataTable getInfo(OleDbConnection connection,String SQL,String var1) {
            DataTable Info;
            string mySQL = String.Format(SQL, var1);
            Info = new DataTable();
            OleDbCommand MyQuery = new OleDbCommand(mySQL, connection);
            OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);
            DA.Fill(Info);
            return Info;
        }

        public static DataTable getInfo(OleDbConnection connection,String SQL, String var1, String var2) {
            DataTable Info;
            string mySQL = String.Format(SQL, var1,var2);
            Info = new DataTable();
            OleDbCommand MyQuery = new OleDbCommand(mySQL, connection);
            OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);
            DA.Fill(Info);
            return Info;
        }
 

        public static void imprimirTabla(DataTable t)
        {
            int i;
            for (i = 0; i < t.Rows.Count; i++)
            {
                for (int j = 0; j < t.Columns.Count; j++)
                {
                    Console.Write(t.Rows[i][j].ToString().Trim() + " ");
                }
                Console.WriteLine();
            }
            if(i != 0)Console.WriteLine(i);
        }
    }
}
