using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace SEPEscribania
{
    class Tipo_Doc
    {
        private int id;
        private string Tipo;
        private string Descripcion;

        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public int Id { get => id; set => id = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

        public Tipo_Doc DevolverTipo(int nId)
        {/*
            Esta funcion devuelve un tipo_doc si existe en la BD
             */
            DBConexion db = new DBConexion();

            //esta operacion abre la conexion y le asigna el command para ejecutar la sentencia
            db.AsignarComando();
            MySqlDataReader dataReader = db.TraerObjetoCampo("tipo_doc", "id", nId.ToString());
            while (dataReader.Read())
            {
                Id = dataReader.GetInt32("id");
                Tipo1 = dataReader.GetString("Tipo");
                Descripcion1 = dataReader.GetString("Descripcion");
            }
            db.CerrarConexion();
            return this;
        }
        public bool ExisteTipo(int nId)
        {/*
            Esta funcion consulta si existe Tipo_Doc con id igual a nId
             */
            bool lOk = false;
            DBConexion db = new DBConexion();
            lOk = db.Existe(nId, "tipo_doc", "id");
            return lOk;
        }
        public bool Guardar()
        {/*
            Esta funcion guarda un objeto Tipo_Doc en la BD
             */
            bool lOk = false;
            DBConexion conMysql = new DBConexion();

            //esta operacion abre la conexion y le asigna el command para ejecutar la sentencia
            conMysql.AsignarComando();
            string sSQL = @"Insert Into tipo_doc (Tipo, Descripcion) Values
                              ('" + this.Tipo1 + "','" + this.Descripcion1 + "');";
            // esta operacion ejecuta la sentecia
            if (conMysql.Insertar(sSQL))
            {
                lOk = true;
            }


            return lOk;
        }
        public bool ModificarTipo()
        {/*
            Esta funcion modifica los valores de un Tipo_doc existente en la BD
             */
            bool lOk = false;
            DBConexion conMysql = new DBConexion();

            //esta operacion abre la conexion y le asigna el command para ejecutar la sentencia
            conMysql.AsignarComando();
            string sSQL = @"UPDATE tipo_doc SET Tipo='" + this.Tipo1 + "', " +
                            "Descripcion='" + this.Descripcion1 + "'" +
                            " WHERE id=" + this.Id;
            // esta operacion ejecuta la sentecia
            if (conMysql.Insertar(sSQL))
            {
                lOk = true;
            }
            return lOk;
        }

        public List<Tipo_Doc> TraerListaTipos()
        {/*
            Esta funcion devuelve una lista con todos los Tipo_doc de la BD
             */
            DBConexion db = new DBConexion();
            List<Tipo_Doc> lista = new List<Tipo_Doc>();
            MySqlDataReader dataReader = db.TraerTabla("tipo_doc");
            while (dataReader.Read())
            {
                Tipo_Doc tip = new Tipo_Doc();
                tip.Id = dataReader.GetInt32("id");
                tip.Tipo1 = dataReader.GetString("Tipo");
                tip.Descripcion1 = dataReader.GetString("Descripcion");
                lista.Add(tip);

            }
            db.CerrarConexion();
            return lista;
        }


    }
}
