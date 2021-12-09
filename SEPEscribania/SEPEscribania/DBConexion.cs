using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SEPEscribania
{
    class DBConexion
    {
        private MySqlConnection conMysql;
        private MySqlCommand cmm;

        public DBConexion()
        {
            Initialize();
        }

        //Inicializar conexion
        private void Initialize()
        {  //Capturo los datos de la conexion alojados en un archivo ini en la raiz del disco C:
            string sPath = System.IO.File.ReadAllText(@"C:\Escribania.ini");
            conMysql = new MySqlConnection(sPath); //Paso la info al connection
                                                   // https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        }
        public bool AbrirConexion()
        {/*
            Esta funcion se encarga de abri la conexion a la BD
             */
            bool lOk = false;
            try
            {
                conMysql.Close();//Cierro la conexion por si hay algun proceso trancado y la vuelvo a abrir
                conMysql.Open();
                lOk = true;
            }
            catch (MySqlException ex)
            {//Capturo los errores mas frecuentes
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("NO SE PUDO CONECTAR AL SERVIDOR. CONTACTE A SOPORTE TECNICO");
                        break;
                    case 1:
                        MessageBox.Show("USUARIO o CONTRASEÑA INCORRECTA ");
                        break;
                    case 2:
                        MessageBox.Show("ERROR CONEXION " + ex.Message);
                        break;
                    case 1042:
                        MessageBox.Show("ERROR CONEXION NO SE PUDO CONECTAR AL HOST ESPECIFICADO" + ex.Message);
                        break;

                }
            }

            return lOk;
        }
        public bool CerrarConexion()
        {/*
            Esta funcion se encarga de cerrar la conexion a la BD
             */
            bool lOk = false;
            try
            {
                conMysql.Close();
                lOk = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
            }

            return lOk;
        }
        public bool AsignarComando()
        {/*
            Esta funcion asigna la conexion al objeto command
            encargado de ejecutar las sentencias
             */
            {
                bool lOk = false;
                try
                {
                    if (this.AbrirConexion())
                    {
                        cmm = new MySqlCommand();
                        cmm.Connection = conMysql;
                        lOk = true;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
                }

                return lOk;
            }
        }

        public MySqlDataReader TraerTabla(string tabla)
        {/*
            Funcion Generica
            Esta funcion devuelve un datareader con todos los campos
            de la tabla buscada
             */
            MySqlDataReader dataReader = null;
            string sSQL = "Select * from " + tabla;
            try
            {
                if (this.AbrirConexion())
                {
                    cmm = new MySqlCommand(sSQL, conMysql);
                    dataReader = cmm.ExecuteReader();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
            }

            return dataReader;

        }


        public MySqlDataReader TraerLike(string sTabla, string sCampo, string sValor)
        {/*
            Funcion Generica
            Esta funcion devuelve un datareader con todos los objetos
            que van coincidiendo con los campos de busqueda ingresados
            en la sentencia LIKE
             */
            MySqlDataReader dataReader = null;
            string sSQL = "Select * from " + sTabla + " where " + sCampo + " like '%" + sValor + "%'";
            try
            {
                if (this.AbrirConexion())
                {
                    cmm = new MySqlCommand(sSQL, conMysql);
                    dataReader = cmm.ExecuteReader();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
            }
            return dataReader;
        }

        public int TraerUltimoTabla(string sTabla)
        { /*
                Funcion Generica
                Esta funcion trea el id del ultimo valor 
                registrado para la tabla
                         */
            int nUltimo = 0;
            MySqlDataReader dataReader = null;
            string sSQL = "Select id from " + sTabla;
            try
            {
                if (this.AbrirConexion())
                {
                    cmm = new MySqlCommand(sSQL, conMysql);
                    dataReader = cmm.ExecuteReader();
                    while (dataReader.Read()) {
                        nUltimo = dataReader.GetInt32("id");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
            }
            return nUltimo;
        }

        public MySqlDataReader TraerObjetoCampo(string sTabla, string sCampo, string sValor)
        {/*
            Funcion Generica
            Esta funcion trea todos los campos de sTabla donde sCampo sea igual a sValor
            y los devuelve como un datareader para poder ser usado por todos los objetos
             */
            MySqlDataReader dataReader = null;
            string sSQL = "Select * from " + sTabla + " where " + sCampo + " = " + sValor;
            try
            {
                if (this.AbrirConexion())
                {
                    cmm = new MySqlCommand(sSQL, conMysql);
                    dataReader = cmm.ExecuteReader();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
            }
            return dataReader;
        }

        public MySqlDataReader EjecutarSQL(string sSQL) {
            MySqlDataReader dataReader = null;
            try {
                if (this.AbrirConexion()) {
                    cmm = new MySqlCommand(sSQL, conMysql);
                    dataReader = cmm.ExecuteReader();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show("ERROR "+ex.Message+". CONTACTE A SOPORTE TECNICO");
            }

            return dataReader;
        }

        public bool Insertar(string sSQL)
        {/*
            Funcion Generica
            Esta funcion inserta los valor del los objetos a la BD
             */
            {
                bool lOk = false;
                try
                {
                    cmm.CommandText = sSQL;
                    cmm.ExecuteNonQuery();

                    //cierro la conexion
                    lOk = true;
                    CerrarConexion();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
                }

                return lOk;
            }
        }

        public bool Eliminar(string sQuery)
        {/*
            Funcion Generica
            Esta funcion elimina un objeto de la BD
             */
            bool lOk = false;
            if (this.AbrirConexion())
            {
                MySqlCommand cmm = new MySqlCommand();

                //Asigno el la sentencia
                cmm.CommandText = sQuery;

                //Paso la conexion al command la conexion
                cmm.Connection = conMysql;

                //Ejecuto la sentencia
                cmm.ExecuteNonQuery();
                lOk = true;

                //cierro la conexion
                CerrarConexion();
            }
            return lOk;
        }
        public bool Existe(int nCi, string sTabla, string sCampo)
        {/*
            Funcion Generica
            Esta funcion devuelve un booleano si un objeto que coincida
            con el campo de busqueda, existe en BD
             */
            bool lOk = false;
            int si = 0;
            string sSQL = "Select * from " + sTabla + " where " + sCampo + " =" + nCi;
            {
                try
                {
                    if (this.AbrirConexion())
                    {
                        cmm = new MySqlCommand(sSQL, conMysql);
                        MySqlDataReader dataReader = cmm.ExecuteReader();
                        while (dataReader.Read())
                        {
                            si = dataReader.GetInt32("id");
                            if (si > 0)
                            {
                                lOk = true;
                            }
                        }
                        CerrarConexion();

                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("ERROR " + ex.Message + ". CONTACTE A SOPORTE TECNICO");
                }

                return lOk;
            }
        }
    }
}
