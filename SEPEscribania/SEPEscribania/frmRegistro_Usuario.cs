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
            {//en esta parte, capturoa si fue presionada la tecla enter 
                if (txCodigo.Text == "")//Si la caja de texto esta vacia, habilita el panel y le asigna un codigo al guardar
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
                        txUsuario.Text = usu.Usuario1;
                        txNomCompleto.Text = usu.Nombre_Completo1;
                    }
                    else
                    {
                        MessageBox.Show("CODIGO NO EXISTE EN LA BASE DE DATOS");
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
                        usu.Usuario1 = txUsuario.Text;
                        usu.Password1 = Utils.EncriptarPass(txPass);
                        usu.Nombre_Completo1 = txNomCompleto.Text;
                        lOk = usu.GuardarUsuario();
                    }
                    else {
                        usu.Id = Int32.Parse(txCodigo.Text);
                        usu.Usuario1 = txUsuario.Text;
                        usu.Password1 = Utils.EncriptarPass(txPass);
                        usu.Nombre_Completo1 = txNomCompleto.Text;
                        lOk = usu.ModificarUsuario();
                    }
                    if (lOk) {
                        MessageBox.Show("USUARIO GUARDADO CON EXITO");
                        IniPan();
                    }
                    
                } catch (Exception ex) {
                    MessageBox.Show("ERROR AL GUARDAR USUARIO. "+ex.Message);
                }
                 
            }
            
        }

        public void IniPan() {
            txUsuario.Clear();
            txPass.Clear();
            txRepitPass.Clear();
            txNomCompleto.Clear();
            HabPanel(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SE PERDERA TODA LA INFORMACION QUE NO SE GUARDO", "CANCELAR OPERACION", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                IniPan();
            }
        }
    }
}
