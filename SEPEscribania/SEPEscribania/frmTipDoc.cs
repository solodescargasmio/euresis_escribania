using System;
using System.Windows.Forms;

namespace SEPEscribania
{
    public partial class frmTipDoc : Form
    {
        public frmTipDoc()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = Application.StartupPath + @"\img\requisito.png";
            pnMain.Enabled = false;
        }
        public void HabPanel(bool lOk)
        {
            pnMain.Enabled = lOk;
            pnHeader.Enabled = !lOk;
            if (lOk)
            {
                txTipo.Focus();
            }
            else
            {
                txCodigo.Focus();
            }
        }

        public void IniPant()
        {
            txTipo.Clear();
            txDescripcion.Clear();
            HabPanel(false);
        }

        private void txCodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {/*
            Esta funcion es la encargada de verificar si el id ingresado
            existe en la base de datos y cargar la informacion si existe
             */
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//Con esto, se controla que ingrese solo numeros.
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {//en esta parte, captura si fue presionada la tecla enter 
                if (txCodigo.Text == "")//Si la caja de texto esta vacia, habilita el panel y le asigna un codigo al guardar
                {
                    HabPanel(true);
                }
                else
                { //si la caja de texto no está vacia, trae el tipo desde la bd y lo carga en sus respectivas cajas
                    Tipo_Doc tip = new Tipo_Doc();

                    if (tip.ExisteTipo(Int32.Parse(txCodigo.Text)))
                    {
                        tip.DevolverTipo(Int32.Parse(txCodigo.Text));
                        HabPanel(true);
                        txTipo.Text = tip.Tipo1;
                        txDescripcion.Text = tip.Descripcion1;
                    }
                    else
                    {
                        MessageBox.Show("CODIGO NO EXISTE EN LA BASE DE DATOS", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }


        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            IniPant();
        }

        private void btGuardar_Click_1(object sender, EventArgs e)
        {/*
            Esta funcion se encarga de guardar el tipo de documento
            en la base de datos
             */
            bool lOk = Utils.Validar(txTipo, "TIPO");

            if(lOk)
            {
                Tipo_Doc tip = new Tipo_Doc();
                tip.Tipo1 = txTipo.Text;
                tip.Descripcion1 = txDescripcion.Text;
                if (txCodigo.Text == "")
                {
                    lOk = tip.Guardar();
                }
                else
                {
                    tip.Id = Int32.Parse(txCodigo.Text);
                }
                if (lOk) {
                    MessageBox.Show("EL TIPO SE GUARDO CON EXITO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniPant();
                }
            }
        }

        private void txTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                txDescripcion.Focus();
            }
        }

        private void txDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                btGuardar.Focus();
            }
        }
    }
}
