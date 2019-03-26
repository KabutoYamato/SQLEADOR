using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEADOR.Conexiones
{
    class Foxpro
    {
        OleDbConnection conn;


        public static Dictionary<String, String> Obtener = new Dictionary<String, String>
        {
            {"Matriculas",
                "select distinct " +
                "A.aluctr " +
                "from DALUMN A " +
                "inner join DCALUM CAL on CAL.aluctr = A.aluctr " +
                "inner join DLISTA C on C.aluctr = A.aluctr " +
                "where  CAL.calsit = \"1\" and C.pdocve = \"{0}\" " +
                "order by A.aluctr asc"
            },
            {"Alumnos",
                "select distinct " +
                "A.aluctr, A.alupas, A.alunom, A.aluapp, A.aluapm, CAL.carcve, CAL.calcac, " +
                "CAL.calsit, P.pdocve, P.pdoini, P.pdoter, A.alucur, A.alunac, A.alucol, " +
                "A.alucll, A.alunum, A.aluciu, A.alucpo, A.alute1, A.alute2, A.alumai " +
                "from DALUMN A " +
                "inner join DCALUM CAL on CAL.aluctr = A.aluctr " +
                "inner join DPERIO P on P.pdocve = CAL.caling " +
                "where  A.aluctr = \"{0}\""},
            {"Calificaciones",
                "select " +
                "C.aluctr,M.matnom,C.gpocve,C.liscal,C.lispa1,C.lispa2,C.lispa3,C.lispa4, C.lispa5 " +
                "from DLISTA C " +
                "inner join DMATER M on M.matcve = C.matcve " +
                "where C.pdocve = \"{0}\" and C.aluctr = \"{1}\""},
            {"Kardex",
                "select " +
                "K.aluctr,M.matnom,K.pdocve1,K.karcal,K.karnpe1 " +
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

        public Foxpro(Conexion foxpro)
        {
            string connectionString = "Provider=VFPOLEDB.1;Data Source={0}";
            conn = new OleDbConnection(String.Format(connectionString, foxpro.FoxproInfo()));
            conn.Open();
        }

        public void close()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }


        public Boolean isOpen()
        {
            return conn.State == ConnectionState.Open;
        }

        public DataTable getMatriculas(string periodo) {
            DataTable res = getInfo(Obtener["Matriculas"], periodo);
            return res;
        }

        public DataTable getAlumno(string matricula)
        {
            DataTable res = getInfo(Obtener["Alumnos"], matricula);
            return res;
        }

        public DataTable getKardex(string matricula)
        {
            DataTable res = getInfo(Obtener["Kardex"], matricula);
            return res;
        }
        public DataTable getHorario(string periodo, string matricula)
        {
            DataTable res = getInfo(Obtener["Horario"], periodo, matricula);
            return res;
        }
        public DataTable getCalificaciones(string periodo, string matricula)
        {
            DataTable res = getInfo(Obtener["Calificaciones"], periodo, matricula);
            return res;
        }



        private DataTable getInfo(String SQL, String var1)
        {
            DataTable Info;
            string mySQL = String.Format(SQL, var1);
            Info = new DataTable();
            OleDbCommand MyQuery = new OleDbCommand(mySQL, conn);
            OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);
            DA.Fill(Info);
            return Info;
        }

        private DataTable getInfo(String SQL, String var1, String var2)
        {
            DataTable Info;
            string mySQL = String.Format(SQL, var1, var2);
            Info = new DataTable();
            OleDbCommand MyQuery = new OleDbCommand(mySQL, conn);
            OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);
            DA.Fill(Info);
            return Info;
        }
        private DataTable getInfo(String SQL, String[] vars)
        {
            DataTable Info;
            string mySQL = String.Format(SQL, vars);
            Info = new DataTable();
            OleDbCommand MyQuery = new OleDbCommand(mySQL, conn);
            OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);
            DA.Fill(Info);
            return Info;
        }



        public static bool testConnection(Conexion foxpro) {
            string connectionString = "Provider=VFPOLEDB.1;Data Source={0}";
            try
            {
                using (var conn = new OleDbConnection(String.Format(connectionString, foxpro.FoxproInfo())))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
