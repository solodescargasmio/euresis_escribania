using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SEPEscribania
{
    class Documento
    {
        private int id;
        private int idCliente;
        private int idTipo;
        private string Path;
        private string Titulo;
        private string Anio;
        private int Usuario;
        private string fecha;

        public string Anio1 { get => Anio; set => Anio = value; }
        public string Titulo1 { get => Titulo; set => Titulo = value; }
        public string Path1 { get => Path; set => Path = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int Id { get => id; set => id = value; }
        public int Usuario1 { get => Usuario; set => Usuario = value; }
        public string Fecha { get => fecha; set => fecha = value; }

        public Documento()
        {
        }
        public int Guardar()
        {/*
            Esta funcion guarda un objeto de documento en BD
         */
            int lOk = 0;
            DBConexion db = new DBConexion();
            db.AsignarComando();
            string sSQL = "Insert Into documento (idTipo,idCliente,Path,Titulo,Anio,Usuario,Fecha)" +
                          " Values " +
                          " ("+IdTipo+","+IdCliente+",'"+Path1+"','"+Titulo1+"','"+Anio1+"'," + Usuario1 + ",'" + Fecha + "')";

            if (db.Insertar(sSQL)) {
                lOk = db.TraerUltimoTabla("documento");//Obtengo el id del documento actual para guardar las palabras de busqueda
            }

            return lOk;
        }

        public Documento DevolverDocumento(int nId) {
            /*
             Esta funcion devuelve un objeto documento con 
             id = nId que existe en BD
             */
            DBConexion db = new DBConexion();
            db.AsignarComando();

            MySqlDataReader dataReader = db.TraerObjetoCampo("documento","id",nId.ToString());
            while (dataReader.Read()) {
                Id = dataReader.GetInt32("id");
                IdCliente = dataReader.GetInt32("idCliente");
                IdTipo = dataReader.GetInt32("idTipo");
                Path1 = dataReader.GetString("Path");
                Titulo1 = dataReader.GetString("Titulo");
                Anio = dataReader.GetString("Anio");
            }
            db.CerrarConexion();
            return this;
        }

        public List<Documento> TraerDocAnio(string sAnio) {
            /*
             Esta funcion se encarga de devolver todos los documentos del año seleccionado
             */
            List<Documento> documentos = new List<Documento>();
            DBConexion db = new DBConexion();
            db.AsignarComando();

            MySqlDataReader dataReader = db.TraerObjetoCampo("documento","Anio",sAnio);
            while (dataReader.Read()) {
                Documento doc = new Documento();
                doc.Id = dataReader.GetInt32("id");
                doc.IdCliente = dataReader.GetInt32("IdCliente");
                doc.IdTipo = dataReader.GetInt32("IdTipo");
                doc.Anio1 = dataReader.GetString("Anio");
                doc.Path1 = dataReader.GetString("Path");
                doc.Titulo1 = dataReader.GetString("Titulo");
                documentos.Add(doc);
            }
            return documentos;
        }
        public List<Documento> TraerDocParametros(string sSQL) {
            List<Documento> documentos = new List<Documento>();
            DBConexion db = new DBConexion();
            db.AsignarComando();
            MySqlDataReader dataReader = db.EjecutarSQL(sSQL);
            while (dataReader.Read()) {
                Documento doc = new Documento();
                doc.Id = dataReader.GetInt32("id");
                doc.IdCliente = dataReader.GetInt32("IdCliente");
                doc.IdTipo = dataReader.GetInt32("IdTipo");
                doc.Anio1 = dataReader.GetString("Anio");
                doc.Path1 = dataReader.GetString("Path");
                doc.Titulo1 = dataReader.GetString("Titulo");
                documentos.Add(doc);

            }
            return documentos;
        }

        public Documento TraerPath(string sPath) {
            DBConexion db = new DBConexion();
            db.AsignarComando();
            sPath = sPath.Replace('\\','/');
            MySqlDataReader dataReader = db.TraerObjetoCampo("documento","Path","'"+sPath+"'");

                while (dataReader.Read())
                {
                    this.Id = dataReader.GetInt32("id");
                    this.IdCliente = dataReader.GetInt32("idCliente");
                    this.idTipo = dataReader.GetInt32("idTipo");
                    this.Path1 = dataReader.GetString("Path");
                    this.Titulo1 = dataReader.GetString("Titulo");
                    this.Anio1 = dataReader.GetString("Anio");
                }
    
            return this;
        }

        public bool EliminarId(int nId)
        {
            bool lOk = false;
            DBConexion db = new DBConexion();
            db.AsignarComando();
            string sSQL = "Delete From documento Where id = " + nId.ToString();
            lOk = db.Eliminar(sSQL);
            return lOk;
        }

        public bool ModificarDocumento()
        {
            /*
            Esta funcion modifica un objeto de documento en BD
         */
            bool lOk = false;
            DBConexion db = new DBConexion();
            db.AsignarComando();
            string sSQL = "Update documento Set" +
                          " idCliente =" + IdCliente + "," +
                          " idTipo =" + IdTipo + "," +
                          " Anio ='" + Anio + "'," +
                          " Path ='" + Path1 + "'," +
                          " Titulo ='" + Titulo1 + "'" +
                          " Where id= " + Id;
            if (db.Insertar(sSQL))
            {
                lOk = true;
            }

            return lOk;
        }

    }
}
