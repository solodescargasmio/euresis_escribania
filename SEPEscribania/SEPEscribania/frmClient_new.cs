using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace SEPEscribania
{
    public partial class frmClient_new : Form, IContract
    {        
        public frmClient_new()
        {
            InitializeComponent();
            imgNuevoCliente.ImageLocation = Application.StartupPath +@"\img\usuarios.png";
            /*
             Esta parte se encarga de mostrar un cartel indicando el dato que se 
             espera, sea ingresado en la caja de texto en la que se encuentra el foco
             */
            this.ttMensaje.SetToolTip(this.txtCedula, "CEDULA CLIENTE PRESIONE F1 PARA OBTENER AYUDA");
            this.ttMensaje.SetToolTip(this.txtNombre, "NOMBRE DEL CLIENTE.");
            this.ttMensaje.SetToolTip(this.txtApellido, "APELLIDO DEL CLIENTE.");
            this.ttMensaje.SetToolTip(this.txtDire, "DIRECCION DEL CLIENTE.");
            this.ttMensaje.SetToolTip(this.txtTel, "TELEFONO DE CONTACTO DEL CLIENTE.");
            this.ttMensaje.SetToolTip(this.txtCel, "CELULAR DE CONTACTO DEL CLIENTE.");
            this.ttMensaje.SetToolTip(this.btnFolder, "DIRECTORIO DONDE SE ALMACENAN LOS ARCHIVOS DEL CLIENTE.");
            this.ttMensaje.SetToolTip(this.btnGuardar, "GUARDA LA INFORMACION DEL CLIENTE EN LA BASE DE DATOS.");
            this.ttMensaje.SetToolTip(this.btnCancelar, "CIERRA EL FORMULARIO ACTUAL SIN REGISTRA LOS DATOS.");


        }

        private void btnFolder_Click(object sender, EventArgs e)
        {/*
             Esta funcion, ademas de seleccionar donde va a guardarse la carpeta del usuario creado, verifica que el campo cedula este completado
             */

            String sPath;
            using (var fldrDlg = new FolderBrowserDialog())
            {
                if (fldrDlg.ShowDialog() == DialogResult.OK)
                {
                    sPath = fldrDlg.SelectedPath;
                    //lblFolder.Text = sPath;
                    if (txtCedula.Text == " .   .   -")
                    {
                        MessageBox.Show("INGRESE EL DOCUMENTO DEL CLIENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCedula.Focus();
                    }
                    else
                    {
                        if (!Directory.Exists(sPath + @"\" + CedulaSinPuntos(txtCedula.Text)))
                        {
                            lblFolder.Text = sPath + @"\" + CedulaSinPuntos(txtCedula.Text);
                        }
                    }

                }
            }
        }

        private void IniPant()
        {/*
            Esta funcion limpia las cajas de texto
            */

            txtNombre.Clear();
            txtApellido.Clear();
            txtDire.Clear();
            txtTel.Clear();
            txtCel.Clear();
            lblFolder.Text = "";

        }

        private int CedulaSinPuntos(string sCI)
        { /*
            Esta funcion elimina los puntos y el guion de la mascara de la cedula
            y devuelve un entero
            */
            sCI = sCI.Replace(".", "");
            sCI = sCI.Replace("-", "");

            return Int32.Parse(sCI);
        }

        public void Ejecutar(string texto)
        {/*
            Esta funcion esta declarada en IContract, es la 
            encargada de pasar valores de un form a otro
             */
            txtCedula.Text = texto;
        }
        

        public void Ejecutar(string texto, string sPath)
        {
            throw new NotImplementedException();
        }

        
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            Esta funcion verifica que si existe el cliente rellena los campos de texto.
            Si presionan enter obtiene el texto del TextBox,
            comprueba que el tamaño sea 11 ya que con puntos y guiones 
            el tamaño es ese. si cliente existe en BD, lo muestra, sino pasa al otro text box.
             */
            if (e.KeyChar == (char)13)//si true, presionaron ENTER
            {

                string dato = txtCedula.Text; 
                if (dato.Length != 11)
                {
                    MessageBox.Show("ERROR EN CEDULA, VERIFICAR","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cliente cli = new Cliente();
                    cli.TraerCliente(CedulaSinPuntos(dato));
                    if (cli != null)
                    {
                        txtNombre.Text = cli.Nombre1;
                        txtApellido.Text = cli.Apellido1;
                        txtDire.Text = cli.Direccion1;
                        txtTel.Text = cli.Telefono1;
                        txtCel.Text = cli.Celular1;
                        lblFolder.Text = cli.Carpeta1;
                    }

                }
                txtNombre.Focus();
            }
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {/*
            Esta es la funcion de ayuda para encontrar cliente 
             Al presionar F1, muestra el formulario de ayuda para buscar
             en la lista de clientes.
             */
            if (e.KeyCode == Keys.F1)
            {
                using (frmAyudaCliente form = new frmAyudaCliente())
                {
                    form.contrato = this;
                    form.ShowDialog(this);
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        { /*
            Antes de guardar, verifica las cajas de texto para que no esten vacias (solo 
            las que son obligatorias). Si pasa la validacion, guarda el cliente en BD.
             */
            bool lOk;
            //Aca comeinza la validacion de las cajas de texto
            lOk = Utils.Validar(txtCedula, "CI");
            if (lOk)
            {
                lOk = Utils.Validar(txtNombre, "NOMBRE");
            }
            if (lOk)
            {
                lOk = Utils.Validar(txtApellido, "APELLIDO");
            }
            if (lOk)
            {
                lOk = Utils.Validar(txtDire, "DIRECCION");
            }

            if (lOk)
            {
                Cliente cli = new Cliente();
                cli.CI1 = CedulaSinPuntos(txtCedula.Text);
                cli.Nombre1 = txtNombre.Text;
                cli.Apellido1 = txtApellido.Text;
                cli.Direccion1 = txtDire.Text;
                cli.Telefono1 = txtTel.Text;
                cli.Celular1 = txtCel.Text;
                cli.Fecha_Registro1 = Convert.ToString(DateTime.Now);
                cli.Usuario1 = Int32.Parse(Session.User);


                cli.Carpeta1 = lblFolder.Text.Replace(@"\", @"\\");
                if (cli.Guardar())
                {
                    IniPant();
                    MessageBox.Show("CLIENTE INGRESADO CON EXITO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmClients").SingleOrDefault<Form>();
                    if (existe != null) {
                        string cedula = cli.CI1.ToString(); 
                        Ejecutar(cedula);
                        this.Close();
                    }
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                txtApellido.Focus();
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDire.Focus();
            }
        }

        private void txtDire_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                txtTel.Focus();
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                txtCel.Focus();
            }
        }
    }
}
