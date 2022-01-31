using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SEPEscribania
{
    public partial class frmPrincipal : Form
    {
        LinkLabel link = new LinkLabel();
        
        public frmPrincipal()
        {
            InitializeComponent();
            link.Text = Session.User;
            
            this.Text = this.Text + "                                                                  " +
                "                                               Bienvenido " + Session.Nombre;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Muestro el modificar");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Muestro el Eliminar");
        }

        private void tipoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
              Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmTipDoc").SingleOrDefault<Form>();

                        if (existe != null)
                        {
                            existe.WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            frmTipDoc frmT = new frmTipDoc();
                            frmT.MdiParent = this;
                            frmT.Show();
                        }
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmClients").SingleOrDefault<Form>();

            if (existe != null)

            {
                Form otro = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmClients").SingleOrDefault<Form>();
                existe.WindowState = FormWindowState.Normal;
            }
            else
            {
                frmClients fCli = new frmClients();
                fCli.MdiParent = this;
                fCli.Show();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmClient").SingleOrDefault<Form>();

            if (existe != null)

            {

                existe.Close();

            }
            Form existeC = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmClient_new").SingleOrDefault<Form>();

            if (existeC != null)
            {
                existeC.WindowState = FormWindowState.Normal;
            }
            else
            {
                frmClient_new nuevo = new frmClient_new();
                nuevo.MdiParent = this;
                nuevo.Show();
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmRegistro_Usuario").SingleOrDefault<Form>();

            if (existe != null)

            {
                Form otro = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmRegistro_Usuario").SingleOrDefault<Form>();
                existe.WindowState = FormWindowState.Normal;
            }
            else
            {
                frmRegistro_Usuario fCli = new frmRegistro_Usuario();
                fCli.MdiParent = this;
                fCli.Show();
            }

        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmLogin").SingleOrDefault<Form>();

            if (existe != null)

            {
                existe.Close();
            }
        }

        private void frmPrincipal_Shown(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmClients").SingleOrDefault<Form>();
            if (existe == null) {
                frmClients frm = new frmClients();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
