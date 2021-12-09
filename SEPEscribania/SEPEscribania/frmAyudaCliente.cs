using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPEscribania
{
    public partial class frmAyudaCliente : Form
    {
        public IContract contrato { get; set; }//declara la clase contrato para luego pasar el valor 
        DataTable dt;

        public frmAyudaCliente()
        {
            InitializeComponent();
            TituloColumna();
        }

        private void TituloColumna()
        {/*
            Esta funcion carga el titulo para las columnas de la tabla
             */
            dt = new DataTable();
            dt.Columns.Add("Cedula");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Celular");
            dataGridView1.DataSource = dt;
        }

        private void txNomAyuda_TextChanged(object sender, EventArgs e)
        {/*
            Esta funcion toma el texto ingresado en la cedula y hace la consulta a la BD
            Se ejecuta cuando ya se hayan ingresado 2 o mas caracteres en la caja de texto
            Hace una consulta LIKE por lo que cuantos mas caracteres se ingrese
            mas exacta es la consulta
             */
            string sDato = txNomAyuda.Text;
            if (sDato.Length > 1)
            {
                dt.Rows.Clear();

                Cliente cliente = new Cliente();
                List<Cliente> clientes = new List<Cliente>();
                clientes = cliente.TraerClienteCedula(Int32.Parse(txNomAyuda.Text));
                foreach (Cliente cli in clientes)
                {
                    DataRow dr = dt.NewRow();
                    dr["Cedula"] = cli.CI1;
                    dr["Nombre"] = cli.Nombre1;
                    dr["Apellido"] = cli.Apellido1;
                    dr["Direccion"] = cli.Direccion1;
                    dr["Telefono"] = cli.Telefono1;
                    dr["Celular"] = cli.Celular1;
                    dt.Rows.Add(dr);

                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {/*
            En esta funcion se obtiene el valor de la primera celda de la tabla 
            y lo pasa al la clase IContract para mantener el valor y mostrarlo en el otro form.
            Luego de eso se cierra el formulario de ayuda
             */
            string valorPrimerCelda = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            contrato.Ejecutar(valorPrimerCelda);
            this.Close();
        }

        private void txNomAyuda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //Si se presiona otro digito que no sea un numero, esto controla que no se escriba en el textbox
            }
        }

        private void txNom_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            Esta funcion toma el texto ingresado en el apellido y hace la consulta a la BD
            Se ejecuta cuando ya se hayan ingresado 2 o mas caracteres en la caja de texto
            Hace una consulta LIKE por lo que cuantos mas caracteres se ingrese
            mas exacta es la consulta
             */
            string sDato = txNom.Text;
            if (sDato.Length > 1)
            {
                dt.Rows.Clear();

                Cliente cliente = new Cliente();
                List<Cliente> clientes = new List<Cliente>();
                clientes = cliente.TraerClienteApellido(txNomAyuda.Text);
                foreach (Cliente cli in clientes)
                {
                    DataRow dr = dt.NewRow();
                    dr["Cedula"] = cli.CI1;
                    dr["Nombre"] = cli.Nombre1;
                    dr["Apellido"] = cli.Apellido1;
                    dr["Direccion"] = cli.Direccion1;
                    dr["Telefono"] = cli.Telefono1;
                    dr["Celular"] = cli.Celular1;
                    dt.Rows.Add(dr);

                }
            }

        }
    }
}
        