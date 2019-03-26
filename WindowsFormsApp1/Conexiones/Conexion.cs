using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEADOR.Conexiones
{
    public class Conexion
    {
        public string Host;
        public string Port;
        public string Database;
        public string User;
        public string Password;

        public string Ruta;

        public Conexion(string ruta)
        {
            this.Ruta = ruta;
        }

        public Conexion(string host, string port, string db, string user, string pass)
        {
            this.Host = host;
            this.Port = port;
            this.Database = db;
            this.User = user;
            this.Password = pass;
        }

        public string[] FoxproInfo()
        {
            string[] res = { Ruta };
            return res;
        }
        public string[] MysqlInfo()
        {
            string[] res = { Host, Port, Database, User, Password };
            return res;
        }
    }
}
