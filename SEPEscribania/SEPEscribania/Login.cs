using System;
using System.Windows.Forms;

namespace SEPEscribania
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            picLogo.ImageLocation = Application.StartupPath + @"\img\logo.png";
        }//PasswordPropertyTextAttribute

        public void MostrarError(TextBox tx,string sErr) {
            if (tx.Text == "")
            {
                mensajeError.Text = "Ingresar " + sErr;
                tx.Focus();
            }
            else {
                mensajeError.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool lOk = Utils.Validar(txUsuario, "USUARIO");
            if (lOk) {
                lOk = Utils.Validar(txPass,"CONTRASEÑA");
            }
            if (lOk) {
                Usuario usu = new Usuario();
                usu.Usuario1 = Int32.Parse(txUsuario.Text);
                
                usu.Password1 = Utils.EncriptarPass(txPass);
                int nId = usu.LoginUsuario();
                if (nId>0)
                {
                    usu = usu.DevolverUsuario(nId);
                    Session.User = Convert.ToString(usu.Usuario1);
                    Session.Nombre = usu.Nombre_Completo1;
                    frmPrincipal frm = new frmPrincipal();
                    frm.Show();
                    this.Hide();
                }
                else {
                    mensajeError.Text="Usuario o Contraseña incorrectos, Por favor Verifique";
                    txPass.Clear();
                    txPass.Focus();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SEGURO DESEA SALIR DEL SISTEMA?","CERRAR SISTEMA",MessageBoxButtons.OKCancel,MessageBoxIcon.Information)==DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                txUsuario.Focus();
            }
        }

        private void txPass_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //Si se presiona otro digito que no sea un numero, esto controla que no se escriba en el textbox
            }else
            if (e.KeyChar==(char)Keys.Enter) {
                MostrarError(txUsuario, "Contraseña");
                btnIniciar.Focus();
            }
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
                        txUsuario.Focus();
        }

        private void txUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //Si se presiona otro digito que no sea un numero, esto controla que no se escriba en el textbox
            }
            else if (e.KeyChar==(char)Keys.Enter) {
                    MostrarError(txUsuario, "Usuario");
                    if (txUsuario.Text != "")
                    {
                        txPass.Focus();
                    }
            }
        }


        private void btnIniciar_MouseHover_1(object sender, EventArgs e)
        {
            btnIniciar.BackColor = System.Drawing.Color.Green;
        }

        private void btnIniciar_MouseLeave(object sender, EventArgs e)
        {
            btnIniciar.BackColor = System.Drawing.Color.Navy;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor= System.Drawing.Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Navy;
        }
    }
}
