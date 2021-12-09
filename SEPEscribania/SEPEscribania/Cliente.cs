using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SEPEscribania
{
    class Cliente
    {
        private int id;
        private int CI;
        private string Nombre;
        private string Apellido;
        private string Direccion;
        private string Carpeta;
        private string Telefono;
        private string Celular;
        private string Otro;

        public int Id { get => id; set => id = value; }
        public int CI1 { get => CI; set => CI = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public string Carpeta1 { get => Carpeta; set => Carpeta = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string Celular1 { get => Celular; set => Celular = value; }
        public string Otro1 { get => Otro; set => Otro = value; }

        public Cliente()
        {
        }
       
        public bool Guardar()
        {/*
            Esta funcion se encarga de guardar el cliente en BD
             */
            bool lOk = false;
            DBConexion conMysql = new DBConexion();

            //esta operacion abre la conexion y le asigna el command para ejecutar la sentencia
            conMysql.AsignarComando();
            string sSQL = @"Insert Into cliente (CI,Nombre,Apellido,Direccion,Carpeta,Telefono,Celular,Otro) Values
                              (" + this.CI1 + ",'" + this.Nombre1 + "','" + this.Apellido1 + "'," +
                          "'" + this.Direccion1 + "','" + this.Carpeta1 + "','" + this.Telefono1 + "'," +
                          "'" + this.Celular1 + "','" + this.Otro1 + "');";
            // esta operacion ejecuta la sentecia
            if (conMysql.Insertar(sSQL))
            {
                lOk = true;
            }


            return lOk;
        }

        public bool ExisteCliente(int sCedula)
        {/*
            Esta funcion verifica que cliente con cedula sCedula exista en BD
             */
            bool lOk = false;
            DBConexion conMysql = new DBConexion();

            //esta operacion abre la conexion y le asigna el command para ejecutar la sentencia
            conMysql.AsignarComando();

            lOk = conMysql.Existe(sCedula, "cliente", "CI");

            return lOk;
        }

        public bool ModificarCliente(Cliente cli)
        {/*
            Esta funcion modifica los valores de cli en BD
             */
            bool lOk = false;
            DBConexion db = new DBConexion();

            db.AsignarComando();
            string sSQL = @"Update cliente Set 
                           CI=" + cli.CI1 +
                           ",Nombre = " + cli.Nombre1 +
                           ",Apellido = " + cli.Apellido1 +
                           ",Direccion = " + cli.Direccion1 +
                           ",Carpeta = " + cli.Carpeta1 +
                           ",Telefono = " + cli.Telefono1 +
                           ",Celular = " + cli.Celular1 +
                           ",Otro = " + cli.Celular1 +
                           " Where id=" + cli.Id;
            if (db.Insertar(sSQL))
            {
                lOk = true;
            }

            return lOk;
        }
        public List<Cliente> TraerClientes()
        {/*
            Esta funcion trae todos los clientes en BD
             */
            List<Cliente> clientes = new List<Cliente>();
            MySqlDataReader dataReader;
            DBConexion db = new DBConexion();

            db.AsignarComando();
            dataReader = db.TraerTabla("cliente");
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    Cliente cli = new Cliente();
                    cli.Id = dataReader.GetInt32("id");
                    cli.CI1 = dataReader.GetInt32("CI");
                    cli.Nombre1 = dataReader.GetString("Nombre");
                    cli.Apellido1 = dataReader.GetString("Apellido");
                    cli.Direccion1 = dataReader.GetString("Direccion");
                    cli.Carpeta1 = dataReader.GetString("Carpeta");
                    cli.Telefono1 = dataReader.GetString("Telefono");
                    cli.Celular1 = dataReader.GetString("Celular");
                    cli.Otro1 = dataReader.GetString("Otro");
                    clientes.Add(cli);

                }
                db.CerrarConexion();
            }
            return clientes;

        }
        public List<Cliente> TraerClienteCedula(int nCedula)
        {/*
            Esta funcion trae los clientes que van coincidiendo con el 
            criterio de busqueda sentencia LIKE para el campo cedula
             */
            List<Cliente> clientes = new List<Cliente>();
            DBConexion db = new DBConexion();
            MySqlDataReader dataReader;
            db.AsignarComando();
            dataReader = db.TraerLike("cliente", "CI", nCedula.ToString());
            while (dataReader.Read())
            {
                Cliente cli = new Cliente();
                cli.Id = dataReader.GetInt32("id");
                cli.CI1 = dataReader.GetInt32("CI");
                cli.Nombre1 = dataReader.GetString("Nombre");
                cli.Apellido1 = dataReader.GetString("Apellido");
                cli.Direccion1 = dataReader.GetString("Direccion");
                cli.Carpeta1 = dataReader.GetString("Carpeta");
                cli.Telefono1 = dataReader.GetString("Telefono");
                cli.Celular1 = dataReader.GetString("Celular");
                cli.Otro1 = dataReader.GetString("Otro");
                clientes.Add(cli);

            }
            db.CerrarConexion();
            return clientes;

        }
        public List<Cliente> TraerClienteApellido(string sApellido)
        {/*
            Esta funcion lísta todos los clientes que van coincidiendo con el
            criterio de busqueda LIKE para el campo apellido
             */
            List<Cliente> clientes = new List<Cliente>();
            DBConexion db = new DBConexion();
            MySqlDataReader dataReader;
            db.AsignarComando();
            dataReader = db.TraerLike("cliente", "Apellido", sApellido);
            while (dataReader.Read())
            {
                Cliente cli = new Cliente();
                cli.Id = dataReader.GetInt32("id");
                cli.CI1 = dataReader.GetInt32("CI");
                cli.Nombre1 = dataReader.GetString("Nombre");
                cli.Apellido1 = dataReader.GetString("Apellido");
                cli.Direccion1 = dataReader.GetString("Direccion");
                cli.Carpeta1 = dataReader.GetString("Carpeta");
                cli.Telefono1 = dataReader.GetString("Telefono");
                cli.Celular1 = dataReader.GetString("Celular");
                cli.Otro1 = dataReader.GetString("Otro");
                clientes.Add(cli);
            }
            db.CerrarConexion();
            return clientes;

        }
        public Cliente TraerCliente(int nCedula)
        { /*
            Esta funcion trae el cliente con cedula = nCedula 
             */
            DBConexion db = new DBConexion();
            db.AsignarComando();
            MySqlDataReader dataReader = db.TraerObjetoCampo("cliente", "CI", nCedula.ToString());
            while (dataReader.Read())
            {
                this.Id = dataReader.GetInt32("id");
                this.CI1 = dataReader.GetInt32("CI");
                this.Nombre1 = dataReader.GetString("Nombre");
                this.Apellido1 = dataReader.GetString("Apellido");
                this.Direccion1 = dataReader.GetString("Direccion");
                this.Carpeta1 = dataReader.GetString("Carpeta");
                this.Telefono1 = dataReader.GetString("Telefono");
                this.Celular1 = dataReader.GetString("Celular");
                this.Otro1 = dataReader.GetString("Otro");
            }
            db.CerrarConexion();



            return this;

        }
        public List<Cliente> EjecutarSQL(string sAnio) {
            List<Cliente> clientes = new List<Cliente>();
            DBConexion db = new DBConexion();
            db.AsignarComando();
            string sSQL = "Select * From cliente c " +
                          "Inner Join documento d on d.idCliente=c.id " +
                          "Where Anio = " + sAnio;
            MySqlDataReader dataReader = db.EjecutarSQL(sSQL);
            while (dataReader.Read()) {
                Cliente cli = new Cliente();
                cli.Id = dataReader.GetInt32("id");
                cli.CI1 = dataReader.GetInt32("CI");
                cli.Nombre1 = dataReader.GetString("Nombre");
                cli.Apellido1 = dataReader.GetString("Apellido");
                cli.Direccion1 = dataReader.GetString("Direccion");
                cli.Carpeta1 = dataReader.GetString("Carpeta");
                cli.Telefono1 = dataReader.GetString("Telefono");
                cli.Celular1 = dataReader.GetString("Celular");
                cli.Otro1 = dataReader.GetString("Otro");
                clientes.Add(cli);
            }
            return clientes;
        }

        public Cliente TraerClienteID(int nId) {
            DBConexion db = new DBConexion();
            db.AsignarComando();
            MySqlDataReader dataReader = db.TraerObjetoCampo("cliente","id",nId.ToString());
            while (dataReader.Read()) {
                this.Id = dataReader.GetInt32("id");
                this.CI1 = dataReader.GetInt32("CI");
                this.Nombre1 = dataReader.GetString("Nombre");
                this.Apellido1 = dataReader.GetString("Apellido");
                this.Direccion1 = dataReader.GetString("Direccion");
                this.Carpeta1 = dataReader.GetString("Carpeta");
                this.Telefono1 = dataReader.GetString("Telefono");
                this.Celular1 = dataReader.GetString("Celular");
                this.Otro1 = dataReader.GetString("Otro");
            }
            return this;
        }

    }
}

