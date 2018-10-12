using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    class mysql
    {
        string connectionString = "server={0};port={1};database={2};uid={3};pwd={4};SslMode=none";
        MySqlConnection cnn;
        public mysql(String server, String Port, String database, String user, String password)
        {
            cnn = new MySqlConnection(String.Format(connectionString, server, Port, database, user, password));
            cnn.Open();
        }

        public void cleandb() {
            MySqlCommand cmnd = new MySqlCommand();
            cmnd.Connection = cnn;
            cmnd.CommandText = "TRUNCATE TABLE alumnos";
            cmnd.ExecuteNonQuery();
            cmnd.CommandText = "TRUNCATE TABLE calificaciones";
            cmnd.ExecuteNonQuery();
            cmnd.CommandText = "TRUNCATE TABLE horario";
            cmnd.ExecuteNonQuery();
            cmnd.CommandText = "TRUNCATE TABLE kardexes";
            cmnd.ExecuteNonQuery();
        }

        public void subirAlumno(DataRow Alumno) {
            string sql = "INSERT INTO " +
                "alumnos(matricula,contrasena,nombre,carrera,creditos,situacion,pdo_cve,pdo_ini,pdo_ter,curp,nacimiento,direccion,tel_domicilio,tel_movil,correo) " +
                "VALUES(@matricula,@contrasena,@nombre,@carrera,@creditos,@situacion,@pdo_cve,@pdo_ini,@pdo_ter,@curp,@nacimiento,@direccion,@tel_domicilio,@tel_movil,@correo)";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@matricula", limpiarData(Alumno,0));
            cmd.Parameters.AddWithValue("@contrasena", limpiarData(Alumno, 1));
            cmd.Parameters.AddWithValue("@nombre", String.Format("{0} {1} {2}", limpiarData(Alumno, 2), limpiarData(Alumno, 3), limpiarData(Alumno, 4)));
            cmd.Parameters.AddWithValue("@carrera", limpiarData(Alumno, 5));
            cmd.Parameters.AddWithValue("@creditos", limpiarData(Alumno, 6));
            cmd.Parameters.AddWithValue("@situacion", limpiarData(Alumno, 7));
            cmd.Parameters.AddWithValue("@pdo_cve", limpiarData(Alumno, 8));
            cmd.Parameters.AddWithValue("@pdo_ini", limpiarData(Alumno,9).Substring(0,10));
            cmd.Parameters.AddWithValue("@pdo_ter", limpiarData(Alumno, 10).Substring(0, 10));
            cmd.Parameters.AddWithValue("@curp", limpiarData(Alumno, 11));
            cmd.Parameters.AddWithValue("@nacimiento", limpiarData(Alumno, 12).Substring(0,10));
            String[] direccion = {
                limpiarData(Alumno, 13),
                limpiarData(Alumno, 14),
                limpiarData(Alumno, 15),
                limpiarData(Alumno, 16),
                limpiarData(Alumno, 17)
            };
            cmd.Parameters.AddWithValue("@direccion", String.Format("{0} {1} {2} {3}, {4}", direccion));
            cmd.Parameters.AddWithValue("@tel_domicilio", limpiarData(Alumno, 18));
            cmd.Parameters.AddWithValue("@tel_movil", limpiarData(Alumno, 19));
            cmd.Parameters.AddWithValue("@correo", limpiarData(Alumno, 20));

            cmd.ExecuteNonQuery();

        }

        public void subirCalificaciones(DataTable Calificaciones) {
            if (Calificaciones.Rows.Count <= 0)
            {
                return;
            }
            StringBuilder sql = new StringBuilder(
                "insert into " +
                "calificaciones(matricula,nombre_mat,grupo,calificacion,parcial_1,parcial_2,parcial_3,parcial_4,parcial_5) " +
                "values ");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;

            for (int i = 0; i < Calificaciones.Rows.Count; i++) {
                DataRow Calificacion = Calificaciones.Rows[i];
                sql.Append(
                    String.Format("( @m{0},@n{0},@g{0},@c{0},@p1{0},@p2{0},@p3{0},@p4{0},@p5{0}),", i)
                );
                cmd.Parameters.AddWithValue("@m" + i, limpiarData(Calificacion, 0));
                cmd.Parameters.AddWithValue("@n" + i, limpiarData(Calificacion, 1));
                cmd.Parameters.AddWithValue("@g" + i, limpiarData(Calificacion, 2));
                cmd.Parameters.AddWithValue("@c" + i, limpiarData(Calificacion, 3));
                cmd.Parameters.AddWithValue("@p1" + i, limpiarData(Calificacion, 4));
                cmd.Parameters.AddWithValue("@p2" + i, limpiarData(Calificacion, 5));
                cmd.Parameters.AddWithValue("@p3" + i, limpiarData(Calificacion, 6));
                cmd.Parameters.AddWithValue("@p4" + i, limpiarData(Calificacion, 7));
                cmd.Parameters.AddWithValue("@p5" + i, limpiarData(Calificacion, 8));
            }
            sql.Length--;
            cmd.CommandText = sql.ToString();

            cmd.ExecuteNonQuery();
        }

        public void subirKardex(DataTable Kardex) {
            if (Kardex.Rows.Count <= 0)
            {
                return;
            }
            StringBuilder sql = new StringBuilder(
                "insert into " +
                "kardexes(matricula,nombre_mat,calificacion,periodo,cuatrimestre) " +
                "values ");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;

            for (int i = 0; i < Kardex.Rows.Count; i++)
            {
                DataRow kardex = Kardex.Rows[i];
                sql.Append(
                    String.Format("( @m{0},@n{0},@c{0},@p{0},@cu{0}),", i)
                );
                cmd.Parameters.AddWithValue("@m" + i, limpiarData(kardex, 0));
                cmd.Parameters.AddWithValue("@n" + i, limpiarData(kardex, 1));
                cmd.Parameters.AddWithValue("@c" + i, limpiarData(kardex, 2));
                cmd.Parameters.AddWithValue("@p" + i, limpiarData(kardex, 3));
                cmd.Parameters.AddWithValue("@cu" + i, limpiarData(kardex, 4));
            }
            sql.Length--;
            cmd.CommandText = sql.ToString();

            cmd.ExecuteNonQuery();
        }

        public void subirHorario(DataTable Horario) {
            if (Horario.Rows.Count <= 0) {
                return;
            }

            StringBuilder sql = new StringBuilder(
                "insert into " +
                "horario(matricula,clave_mat,nombre_mat,profesor,lunes,martes,miercoles,jueves,viernes) " +
                "values ");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;

            for (int i = 0; i < Horario.Rows.Count; i++)
            {
                DataRow horario = Horario.Rows[i];
                sql.Append(
                    String.Format("( @m{0},@cm{0},@nm{0},@p{0},@lu{0},@ma{0},@mi{0},@ju{0},@vi{0}),", i)
                );

                String[] profesor = {
                    limpiarData(horario,3),
                    limpiarData(horario,4),
                    limpiarData(horario,5)
                };
                cmd.Parameters.AddWithValue("@m" + i, limpiarData(horario, 0));
                cmd.Parameters.AddWithValue("@cm" + i, limpiarData(horario, 1));
                cmd.Parameters.AddWithValue("@nm" + i, limpiarData(horario, 2));
                cmd.Parameters.AddWithValue("@p" + i, String.Format("{0} {1} {2}",profesor).Trim());
                cmd.Parameters.AddWithValue("@lu" + i, limpiarData(horario, 6));
                cmd.Parameters.AddWithValue("@ma" + i, limpiarData(horario, 7));
                cmd.Parameters.AddWithValue("@mi" + i, limpiarData(horario, 8));
                cmd.Parameters.AddWithValue("@ju" + i, limpiarData(horario, 9));
                cmd.Parameters.AddWithValue("@vi" + i, limpiarData(horario, 10));
            }
            sql.Length--;
            cmd.CommandText = sql.ToString();

            cmd.ExecuteNonQuery();
        }

        public void terminar() {
            if (cnn != null)
            {
                cnn.Close();
            }
        }


        public String limpiarData(DataRow row, int index) {
            return row[index].ToString().Trim();
        }
    }
}
