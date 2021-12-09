using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SEPEscribania
{
    class Palabras_Busqueda
    {
        private int id;
        private int idDocumento;
        private string Busqueda_Palabra;
        public int Id { get => id; set => id = value; }
        public int IdDocumento { get => idDocumento; set => idDocumento = value; }
        public string Busqueda_Palabra1 { get => Busqueda_Palabra; set => Busqueda_Palabra = value; }

        public List<Palabras_Busqueda> EjecutarSQL(string sPalabras) {
            List<Palabras_Busqueda> palabras_Busquedas=null;
            DBConexion db = new DBConexion();
            string[] palabras = sPalabras.Split(',');
            string sParam = "",sSQL="Select * from ";
            int count = 0;
            foreach (string cadena in palabras) {
                if (count>0) {
                    sParam = sParam + " OR "; 
                }
                sParam = sParam + " Palabra LIKE %'" + cadena + "'% ";
                count += 1;
            }
            MySqlDataReader dataReader = db.EjecutarSQL(sSQL);
            return palabras_Busquedas;
        }
        public bool Guardar_Palabras(string sPalabras,int nId)
        {/*
            Esta funcion guarda un objeto busuqeda_palabras asociado a un doumneto en BD
             */
            bool lOk = false;
            string[] palabras = sPalabras.Split(',');
            int count = 0;
            string sSQL = "Insert Into busqueda_palabra (idDocumento,Palabra) Values";
            foreach (string cadena in palabras)
            {
                if (count>0) {
                    sSQL = sSQL + ",";
                }
                sSQL = sSQL+" ("+nId+",'"+cadena+"')";
                count += 1;
            }
            DBConexion db = new DBConexion();
            db.AsignarComando();
            lOk = db.Insertar(sSQL);
            return lOk;
        }
        public List<Palabras_Busqueda> TraerID(int nId) {
            List<Palabras_Busqueda> palabras = new List<Palabras_Busqueda>();
            DBConexion db = new DBConexion();
            db.AsignarComando();
            MySqlDataReader dataReader = db.TraerObjetoCampo("busqueda_palabra","idDocumento",nId.ToString());
            while (dataReader.Read()) {
                Palabras_Busqueda palabra = new Palabras_Busqueda();
                palabra.Id = dataReader.GetInt32("id");
                palabra.IdDocumento = dataReader.GetInt32("idDocumento");
                palabra.Busqueda_Palabra1 = dataReader.GetString("Palabra");
                palabras.Add(palabra);
            }
            
            return palabras;
        }
        public bool EliminarId(int nId) {
            bool lOk = false;
            DBConexion db = new DBConexion();
            db.AsignarComando();
            string sSQL = "Delete From busqueda_palabra Where idDocumento=" + nId.ToString();
            lOk = db.Eliminar(sSQL);
            return lOk;
        }


    }
}
