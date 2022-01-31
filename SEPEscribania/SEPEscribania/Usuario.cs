using System;
using MySql.Data.MySqlClient;

namespace SEPEscribania
{
    class Usuario
    {
        private int id;
        private int NomUsuario;
        private string Password;
        private string Nombre_Completo;

        public Usuario()
        {
        }

        public int Id { get => id; set => id = value; }
        public int Usuario1 { get => NomUsuario; set => NomUsuario = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Nombre_Completo1 { get => Nombre_Completo; set => Nombre_Completo = value; }

        public bool ExisteUsuario(int nId) {
            bool lOk = false;
            DBConexion conMysql = new DBConexion();
            //esta operacion abre la conexion y le asigna el command para ejecutar la sentencia
            conMysql.AsignarComando();

            lOk = conMysql.Existe(nId,"usuario", "id");

            return lOk;
        }

        public Usuario DevolverUsuario(int nId) {
            MySqlDataReader dataReader = null;
            DBConexion db = new DBConexion();

            db.AsignarComando();

            dataReader = db.TraerObjetoCampo("usuario","id",nId.ToString());
            while (dataReader.Read()) {
                this.Usuario1 = dataReader.GetInt32("Usuario");
                this.Password1 = dataReader.GetString("Pass");
                this.Nombre_Completo1 = dataReader.GetString("Nombre_Completo");
            }
            return this;
        }

        public bool GuardarUsuario() {
            /*
            Esta funcion guarda un objeto de documento en BD
         */
            bool lOk = false;
            DBConexion db = new DBConexion();
            db.AsignarComando();
            string sSQL = "Insert Into usuario (Usuario,Pass,Nombre_Completo)" +
                          " Values " +
                          " (" + Usuario1 + ",'" + Password1 + "','" + Nombre_Completo1 + "')";

            if (db.Insertar(sSQL))
            {
                lOk = true;
            }

            return lOk;
        }

        public bool ModificarUsuario()
        {
            /*
            Esta funcion guarda un objeto de documento en BD
         */
            bool lOk = false;
            DBConexion db = new DBConexion();
            db.AsignarComando();
            string sSQL = "Update usuario Set" +
                          " Usuario =" +Usuario1+","+
                          " Pass ='" +Password1+"',"+
                          " Nombre_Completo ='" +Nombre_Completo1+"'"+
                          " Where id= "+Id;

            if (db.Insertar(sSQL))
            {
                lOk = true;
            }

            return lOk;
        }
        public int LoginUsuario() {
            /*
             Esta funcion vericica que el usuario exista en la BD y  
             que sean correctos los valores de login
             */
            bool lOk = false;
            string sSQL = "Select * From usuario Where Usuario= " + this.Usuario1 +
                        " and Pass= '" + this.Password1+"'";
            int nId = 0;
            DBConexion db = new DBConexion();
            db.AsignarComando();
            MySqlDataReader dataReader = db.EjecutarSQL(sSQL);
            while (dataReader.Read()) {
                nId = dataReader.GetInt32("id");
            }
          /*  if (nId>0) {
                lOk = true;
            }*/
            return nId;
        }
    }
}
