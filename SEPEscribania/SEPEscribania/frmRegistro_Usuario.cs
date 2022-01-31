using System;
using System.Windows.Forms;

namespace SEPEscribania
{
    public partial class frmRegistro_Usuario : Form
    {
        Usuario usu;
        public frmRegistro_Usuario()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = Application.StartupPath + @"\img\usuarios.png";
            
            this.ttMensaje.SetToolTip(this.txNomCompleto, "NOMBRE COMPLETO DEL USUARIO");
            this.ttMensaje.SetToolTip(this.txPass, "PASSWORD DE INICIO DE SESSION");
            this.ttMensaje.SetToolTip(this.txRepitPass, "REPITA PASSWORD DE INICIO DE SESSION");
            this.ttMensaje.SetToolTip(this.txUsuario, "USUARIO PARA INICIO DE SESSION (CEDULA)");
            this.ttMensaje.SetToolTip(this.txCodigo, "CODIGO DE USUARIO");

            HabPanel(false);
        }

        public void HabPanel(bool lOk)
        {
            pnMain.Enabled = lOk;
            pnHeader.Enabled = !lOk;
            if (lOk)
            {
                txUsuario.Focus();
            }
            else
            {
                txCodigo.Focus();
            }
        }

        private void txCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//Con esto, se controla que ingrese solo numeros.
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {//en esta parte, captura si fue presionada la tecla enter 
                if ((txCodigo.Text == "") || (txCodigo.Text == "\r\n"))//Si la caja de texto esta vacia, habilita el panel y le asigna un codigo al guardar
                {
                    HabPanel(true);
                }
                else
                { //si la caja de texto no está vacia, trae el tipo desde la bd y lo carga en sus respectivas cajas

                    usu = new Usuario();
                    if (usu.ExisteUsuario(Int32.Parse(txCodigo.Text)))
                    {
                        usu.DevolverUsuario(Int32.Parse(txCodigo.Text));
                        HabPanel(true);
                        txUsuario.Text = Convert.ToString(usu.Usuario1);
                        txNomCompleto.Text = usu.Nombre_Completo1;
                    }
                    else
                    {
                        MessageBox.Show("CODIGO NO EXISTE EN LA BASE DE DATOS","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        IniPan();
                        usu = null;
                    }

                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool lOk =Utils.Validar(txUsuario,"USUARIO");
            if (lOk) {
                lOk = Utils.Validar(txPass,"CONTRASEÑA");
            }
            if (lOk) {
                lOk = Utils.Validar(txRepitPass,"REPETIR CONTRASEÑA");
            }
            if (lOk) {
                lOk = Utils.Validar(txPass,txRepitPass);
            }
            if (lOk) {
                lOk = Utils.Validar(txNomCompleto,"NOMBRE COMPLETO DEL USUARIO");
            }
            if (lOk) {
                    try {
                        if (usu is null)
                        {
                            usu = new Usuario();
                            usu.Usuario1 = Int32.Parse(txUsuario.Text);
                            usu.Password1 = Utils.EncriptarPass(txPass);
                            usu.Nombre_Completo1 = txNomCompleto.Text;
                            lOk = usu.GuardarUsuario();
                        }
                        else {
                            usu.Id = Int32.Parse(txCodigo.Text);
                            usu.Usuario1 = Int32.Parse(txUsuario.Text);
                            usu.Password1 = Utils.EncriptarPass(txPass);
                            usu.Nombre_Completo1 = txNomCompleto.Text;
                            lOk = usu.ModificarUsuario();
                        }
                        if (lOk) {
                            MessageBox.Show("USUARIO GUARDADO CON EXITO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IniPan();
                        }
                    
                    } catch (Exception ex) {
                        MessageBox.Show("ERROR AL GUARDAR USUARIO. "+ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                 
            }
            
        }

        public void IniPan() {
            txUsuario.Clear();
            txCodigo.Clear();
            txPass.Clear();
            txRepitPass.Clear();
            txNomCompleto.Clear();
            HabPanel(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SE PERDERA TODA LA INFORMACION QUE NO SE GUARDO", "CANCELAR OPERACION", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK) {
                IniPan();
            }
        }

        private void txUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //Si se presiona otro digito que no sea un numero, esto controla que no se escriba en el textbox
            } else if (e.KeyChar==Convert.ToChar(Keys.Enter)) {
                txPass.Focus();
            }
        }

        private void txPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //Si se presiona otro digito que no sea un numero, esto controla que no se escriba en el textbox
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txRepitPass.Focus();
            }

        }

        private void txRepitPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //Si se presiona otro digito que no sea un numero, esto controla que no se escriba en el textbox
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txNomCompleto.Focus();
            }
        }

        private void txNomCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter)) {
                btnGuardar.Focus();
            }
        }
    }
}
