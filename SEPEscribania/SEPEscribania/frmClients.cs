using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace SEPEscribania
{
    using Word = Microsoft.Office.Interop.Word;

    public partial class frmClients : Form, IContract
    {
        List<Cliente> clientes = new List<Cliente>(); //Guardo los clientes de la bd
        Word.Application oWord; //Sirve para abrir un proceso de word
        Word.Document oDoc; //sirve para visualizar el documento de word
        object missing = System.Reflection.Missing.Value;
        object readOnly = false;
        object isVisible = true;
        String sPath = "";
        Documento documento;
        public String ObtenerParamConexion()
        { /*
            Esta funcion lee el archivo donde se encuentra la informacion
            sobre la conexion a BD
             */
            String res = "";
            res = System.IO.File.ReadAllText(@"C:\Escribania.ini");

            return res;
        }
        public frmClients()
        {
            InitializeComponent();
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat="yyyy";
            dtpFecha.ShowUpDown = true;
            InicializarWord(); //Inicializo aunque dejo vacio la instancia de proceso word
            trwCliente.ImageList = imgList; //Esto setea las imagenes al twcliente
            trwDoc.ImageList = imgListDir;
            trwDoc.SelectedImageIndex = 1;
            
            LlenarCliente(); //esto agrega al tw cliente, todos clientes que se encuentran en bd
            pnBusquedaDoc.Visible = false;
        }
        private void InicializarWord()
        { /*
            Esta funcion es la encargada de inicializar los objetos Interop
             */
            try
            {
                if (oWord != null)
                {
                    oWord.Quit();
                    oDoc.Close();
                }
            }
            catch
            {
            }
            oWord = new Word.Application();
            oDoc = new Word.Document();
        }
        private void LlenarCliente()
        {/*
            Esta funcion se encarga de llenar la grilla de clientes desde BD
             */
            trwCliente.Nodes.Clear();
            
            Cliente cli = new Cliente();
            clientes = cli.TraerClientes();
            foreach (Cliente cl in clientes)
            {
                TreeNode node = new TreeNode();
                node.Tag = cl.Id.ToString();
                node.Text = cl.CI1.ToString();
                trwCliente.Nodes.Add(node);
                trwCliente.SelectedImageIndex = 0;
            }
        }

        private void LlenarClienteAnio()
        {/*
            Esta funcion se encarga de llenar la grilla de clientes desde BD
             */
            trwCliente.Nodes.Clear();
            Cliente cli = new Cliente();
            clientes = cli.EjecutarSQL(dtpFecha.Text);
            foreach (Cliente cl in clientes)
            {
                TreeNode node = new TreeNode();
                node.Tag = cl.Id.ToString();
                node.Text = cl.CI1.ToString();
                trwCliente.Nodes.Add(node);
                trwCliente.SelectedImageIndex = 0;

            }
        }

        private void Cerrar()
        {/*
          Esta funcion oculta el panel que contiene los objetos para guardar los documentos  
             */
            if (pnGuardar.Visible)
            {
                lbPath.Text = "";
                txNombre.Text = "";
            }
            HabSave(false);
            InicializarWord();

        }
        private void Inicializar(Button btn)
        {
            btn.PerformClick();
        }

        public void LlamarLlenarNodos(TreeNode nodoPrincipal, string[] dir)
        {

            foreach (string di in dir)
            {
                TreeNode Hijo = new TreeNode();
                FileInfo fileInf = new FileInfo(di);
                Hijo.Text = fileInf.Name;
                Hijo.Tag = fileInf.FullName;
                Hijo.ImageKey = "icono_word32.png";
                nodoPrincipal.Nodes.Add(Hijo);
                string[] sHijos = Directory.GetFiles(di);
                LlenarNodos(Hijo, sHijos);
                string[] dire = Directory.GetDirectories(di);
                if (dire.Length > 0)
                {
                    LlamarLlenarNodos(Hijo, dire);
                }


            }

        }
        public void LlenarNodos(TreeNode nodo, string[] sDir)
        {

            foreach (string Path in sDir)
            {
                TreeNode nodoHijo = new TreeNode();
                FileInfo fileInfo = new FileInfo(Path);

                nodoHijo.Text = fileInfo.Name;
                if (fileInfo.Extension == ".docx")
                {
                    nodoHijo.SelectedImageKey = "icono_word32.png";
                    nodoHijo.ImageKey = "icono_word32.png";
                }
                else
                {
                    nodoHijo.SelectedImageKey = "icono_excel.png";
                    nodoHijo.ImageKey = "icono_excel.png";
                }


                nodo.Nodes.Add(nodoHijo);
            }

        }

        private void AbrirDocumento(string sDoc)
        {/*
            Esta funcion abre el documento word seleccionado
             */

            oDoc = oWord.Documents.Open(sDoc, false, false, false);//abro el documento en la aplicacion word

            oWord.Visible = true;//hago visible el documento
            oWord.Activate();
            oDoc.Activate();//pongo este documento como activo
        }

        private void HabSave(bool lOk)
        {/*
            Esta funcion se encarga de ocultar o mostrar el
            panel para el guardado de los documentos
             */
            pnGrillas.Visible = !lOk;
            pnFoo.Enabled = !lOk;
            pnGuardar.Visible = lOk;
            
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (oWord.Documents.Count > 0)
                {
                    MessageBox.Show(oDoc.FullName);
                }
            }
            catch { }
        }

        private void dtpFecha_MouseDown(object sender, MouseEventArgs e)
        {/*
            Esta funcion crea un directorio para el año seleccionado en el datepicker
            si la carpeta no existe
 *          */
            string sPath = @"C:\Euresis_Escribania\"+dtpFecha.Text;
            if (!Directory.Exists(sPath)) {
                Directory.CreateDirectory(sPath);
            }

            LlenarClienteAnio();

        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {/*
            Esta funcion permite visualizar el panel desde donde se
            podra guardar el documento, permitiendo seleccionar la carpeta, 
            el cliente, el año es por default, el que está seleccionado en el combobox,
            el path del documento, el tipo d edocumetno, el titulo y las palabras relacionadas para la busqueda.
             */
                try
                {
                    if (oWord.Documents.Count > 0)
                    {
                        HabSave(true);
                    Tipo_Doc tipo = new Tipo_Doc();
                    List<Tipo_Doc> tipos = new List<Tipo_Doc>();
                    tipos = tipo.TraerListaTipos();
                    Dictionary<Int32, string> dictionary = new Dictionary<Int32, string>();

                    foreach (Tipo_Doc ti in tipos) {
                        dictionary.Add(ti.Id,ti.Tipo1);
                    }
                    cbCliente.DataSource = new BindingSource(dictionary,null);
                    cbCliente.DisplayMember = "Value";
                    cbCliente.ValueMember = "Key";
                    ///cbCliente.Items.Add(ti.Tipo1);
                    cbCliente.SelectedIndex = 0;
                    lbDocRuta.Text = @"C:\Euresis_Escribania\" + dtpFecha.Text;
                    Documento doc = new Documento();
                    doc.TraerPath(oDoc.FullName);
                    
                    
                    if (doc.Id > 0)
                    {
                        documento = doc;
                        MessageBox.Show(documento.Path1);
                        btnEliminar.Enabled = true;
                        string[] nombre = doc.Titulo1.Split('.');
                        txNombre.Text = nombre[0];
                        lbDocRuta.Text = doc.Path1;
                        cbCliente.SelectedIndex = doc.IdTipo - 1;
                        Cliente cli = new Cliente();

                        if (cli != null)
                        {
                            cli.TraerClienteID(doc.IdCliente);
                            txtCedula.Text = cli.CI1.ToString();
                            lbViewDatos.Text = cli.Nombre1 + "  " + cli.Apellido1;
                            lbViewDir.Text = "DIRECCION : " + cli.Direccion1;
                            lbViewTel.Text = "CONTACTOS : " + cli.Telefono1 + " - " + cli.Celular1;
                            txIdC.Text = cli.Id.ToString();
                        }
                        Palabras_Busqueda palabras = new Palabras_Busqueda();
                        int cont = 0;
                        string coma = "";
                        foreach (Palabras_Busqueda pal in palabras.TraerID(doc.Id))
                        {
                            if (cont > 0)
                            {
                                coma = ", ";
                            }
                            txPalabras.Text = txPalabras.Text + coma + pal.Busqueda_Palabra1;
                            cont += 1;
                        }
                    }
                    else { btnEliminar.Enabled = false; }

                }
                    else
                    {
                        MessageBox.Show("SELECCIONE ARCHIVO", "SEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    Cerrar();
                }
            }

        private void btnNew_Click(object sender, EventArgs e)
        {/*
            Esta funcion abre un documento word en blanco
             */

                object missing = System.Reflection.Missing.Value;
            try {
                oDoc = oWord.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                oDoc.Activate();
                oWord.Visible = true;
                oWord.Activate();
            } catch (Exception ex) {
                InicializarWord();
            }

                  
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {/*
            Esta funcion es la encargada de guardar el documento word abierto desde el programa.
            Guarda el documento en la carpeta desde la que fué abierto.    
             */
            try
                {
                    if (oWord.Documents.Count > 0)
                    {
                        object saveAs = oDoc.FullName;
                    oWord.ActiveDocument.SaveAs(ref saveAs,
                                                ref missing, ref missing, ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing, ref missing);
                    oWord.Documents.Close();

                }
                    else
                    {
                        MessageBox.Show("NO HAY DOCUMENTOS ABIERTOS", "SEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                }
                Cerrar();
            

        }
        public void LimpiarSave() {
            if (pnGuardar.Visible == true)
            {
                txNombre.Clear();
                lbPath.Text = "";
                HabSave(false);
                Cerrar();
            }
        }

        private void btnpCancelar_Click(object sender, EventArgs e)
        {
            LimpiarSave();
        }

        private void btnSaveDatos_Click_1(object sender, EventArgs e)
        {/*
            Esta funcion es la encargada de guardar el documento en una 
            carpeta distinta de la que fue abierto.
             */

            bool lOk;
            string[] palabras;
            lbDocRuta.Text = @"C:\\Euresis_Escribania\\" + dtpFecha.Text;
            fbDialog.Description = "SELECCIONE CARPETA";
            fbDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            fbDialog.SelectedPath = lbPath.Text;
            Int32 nIdT = ((KeyValuePair<Int32, string>)cbCliente.SelectedItem).Key;//obtiene id tipo del combobox
            lOk = ValidarTexto(txNombre,"NOMBRE");
            if (lOk) {
                lOk = ValidarTexto(txPalabras, "PALABRAS BUSQUEDA");
            }
            if (lOk) {
                if (txtCedula.Text == " .   .   -")
                {
                    MessageBox.Show("BUSCAR CLIENTE POR CI", "SEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCedula.Focus();
                    lOk = false;
                }
            }

            if (lOk) {
                if (lbDocRuta.Text == "")
                {
                    MessageBox.Show("SELECCIONE UN DIRECTORIO DONDE GUARDAR EL ARCHIVO", "SEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPath.Focus();
                    lOk = false;
                }
            }
            if(lOk)
            {
                try
                {
                    string sRuta = lbDocRuta.Text;
                    sRuta = sRuta.Replace(@"\\", @"/");//Esta operacion escapa la barra invertida para poder guardarla en BD
                    Documento doc = new Documento();
                    doc.Titulo1 = txNombre.Text;
                    doc.Path1 = sRuta + @"/" + txNombre.Text + ".docx";
                    doc.IdCliente = Int32.Parse(txIdC.Text);
                    doc.IdTipo = nIdT;
                    doc.Anio1 = dtpFecha.Text;
                    int nIdDoc = doc.Guardar();
                    if (txPalabras.Text!="") {
                        Palabras_Busqueda pl = new Palabras_Busqueda();
                       lOk = pl.Guardar_Palabras(txPalabras.Text, nIdDoc);
                    }
                    
                    if (nIdDoc > 0) {
                        object saveAs = lbDocRuta.Text + "\\" + txNombre.Text + ".docx";
                        oWord.ActiveDocument.SaveAs(ref saveAs,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing);
                        MessageBox.Show("ARCHIVO GUARDADO CON EXITO", "SEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL GUARDAR ARCHIVO. VERIFIQUE  "+ex.Message, "SEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                IniPat();
                Cerrar();
            }
            

        }
        public void IniPat() {
            txIdC.Clear();
            txNombre.Clear();
            txPalabras.Clear();
            txtCedula.Clear();
            lbViewDatos.Text = "";
            lbViewDir.Text = "";
            lbViewTel.Text = "";
        }



        public bool ValidarTexto(TextBox tx, string sTexto) {
            bool lOk = true;
            if (tx.Text=="") {
                lOk = false;
                MessageBox.Show("EL CAMPO "+sTexto+" NO PUEDE SER VACIO.", "SEP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tx.Focus();
            }
            return lOk;
        }

        private void trwCliente_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {/*
            Esta funcion se encarga de traer todos los archivos para este cliente
             */
                trwDoc.ImageList = imgListDir;
                trwDoc.Nodes.Clear();
                string s = e.Node.Text;
                Cliente cliente = clientes.FirstOrDefault(x => x.CI1 == Int32.Parse(s));
                lbNom_Cli.Text = "Nombre: " + cliente.Nombre1;
                lbApellido.Text = "Apellido: " + cliente.Apellido1;
                lbDireccion.Text = "Direccion: " + cliente.Direccion1;
                lbTelefono.Text = "Telefonos: " + cliente.Telefono1 + " - " + cliente.Celular1;
                sPath = cliente.Carpeta1;
                TreeNode nodoPrincipal = new TreeNode();
                nodoPrincipal.Text = cliente.CI1.ToString();
                nodoPrincipal.ImageKey = "icono_word32.png";
                trwDoc.Nodes.Add(nodoPrincipal);
            if (sPath!="") {
                string[] sFile = Directory.GetFiles(sPath);
                string[] dir = Directory.GetDirectories(sPath);

                Utils utils = new Utils();
                utils.LlenarNodos(nodoPrincipal, sFile);
                if (dir.Length > 0)
                {
                    utils.LlamarLlenarNodos(nodoPrincipal, dir);
                }
            }
                
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {/*
            Esta funcion permite abrir la aplicacion EURESIS para la facturacion.
             */
            Process p = new Process();
            p.StartInfo.FileName = "C:\\Aplicaciones\\EURESIS.exe";
            //p.StartInfo.Arguments = "http://www.microsoft.com";
            p.Start();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {/*
            Esta funcion es la encargada de abrir un documento de word.
             */
            try
            {
                if (oWord.Documents.Count > 0)//si count es >0, hay algun archivo word abierto
                {
                    MessageBox.Show("YA EXISTE UNA INSTANCIA ABIERTA DE WORD. CIERRELA O CONTINUE TRABAJANDO CON LA MISMA", "SEP",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    openFileDialog1.InitialDirectory = @"C:\Euresis_Escribania\";//Esto le dice al programa en que directorio comenzar a buscar.
                    openFileDialog1.FileName = "";
                    openFileDialog1.Filter = "Office | *.docx;*.DOCX;*.doc;*.DOC";//con esto filtro el tipo de documento que permito abrir, en este caso solo documentos word
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        sPath = openFileDialog1.FileName;//capturo el pat completo del documento que intento abrir
                        AbrirDocumento(sPath);
                    };
                }


            }
            catch
            {
                Cerrar();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog fbDial = new FolderBrowserDialog()) {
                fbDial.Description = "SELECCIONE CARPETA";

                if (fbDial.ShowDialog() == DialogResult.OK)
                {
                  /*  fbDial.RootFolder = Environment.SpecialFolder.MyComputer;
                    fbDial.SelectedPath = lbPath.Text;*/
                    lbDocRuta.Text = fbDial.SelectedPath;
                    MessageBox.Show(fbDial.SelectedPath);
                }
            }
            
        }

        public void Ejecutar(string texto)
        {
            txtCedula.Text = texto;
        }

        public void Ejecutar(string texto, string sPath)
        {
            throw new NotImplementedException();
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                using (frmAyudaCliente form = new frmAyudaCliente())
                {
                    form.contrato = this;
                    form.ShowDialog(this);
                }
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
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
                    MessageBox.Show("ERROR EN CEDULA, VERIFICAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cliente cli = new Cliente();
                        cli.TraerCliente(CedulaSinPuntos(dato));
                    if (cli != null)
                    {
                        lbViewDatos.Text = cli.Nombre1 + "  " + cli.Apellido1;
                        lbViewDir.Text = "DIRECCION : "+cli.Direccion1;
                        lbViewTel.Text = "CONTACTOS : "+cli.Telefono1 + " - " + cli.Celular1;
                        txIdC.Text = cli.Id.ToString();
                    }

                }
                btnSaveDatos.Focus();
            }
            
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {/*
            En esta funcion obtengo los parametros de busqueda para el documento
            y verifico que se ingrese el texto a buscar en la BD
             */
            trwDoc.Nodes.Clear();
            int i;
            string sAnd = " and ", sParam = "", sInner = "";
            string sSQL = " select DISTINCT d.* from documento d ";
            bool lOk=false,s=false,w=false;
            for (i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    switch (i) {
                        case 0:
                            s = true;
                            w = true;
                            sParam = " Anio='"+dtpFecha.Text+"' ";
                            break;
                        case 1:
                            if (Utils.Validar(txT,"TITULO")) {
                                w = true;
                                if (s)
                                {
                                    sParam = sParam + " " + sAnd;
                                }
                                sParam = " Titulo ='" + txT.Text + "'";
                            }
                            
                            break;
                        case 2:
                            if (Utils.Validar(txP, "PALABRAS BUSQUEDA"))
                            {
                                w = true;
                                sInner = " Inner Join busqueda_palabra b on b.idDocumento=d.id ";
                                if (s)
                                {
                                    sParam = sParam + " " + sAnd;
                                }
                                string[] arr = txP.Text.Split(',');
                                int a = 0;
                                foreach (string ar in arr) {
                                    if (a > 0) {
                                        sParam = sParam + " OR ";
                                    }
                                    sParam = sParam + " b.Palabra like  '%" + ar.Trim() + "%'";
                                    a += 1;
                                }
                                //sParam = sParam + " Palabra like'%" + txP.Text + "%'";
                            }
                            break;
                    }
                    lOk = true;
                }
            }
            if (!lOk)
            {
                MessageBox.Show("SELECCIONE AL MENOS UN PARAMETRO DE BUSQUEDA");
            }
            else {
                if (w) {
                   sInner = sInner + " Where ";
                }
                sSQL = sSQL + sInner + sParam;

                Documento doc = new Documento();
                foreach (Documento d in doc.TraerDocParametros(sSQL)) {
                    TreeNode node = new TreeNode();
                    node.Tag = d.Path1;
                    node.Text = d.Titulo1 + ".docx";
                    trwDoc.Nodes.Add(node);
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {/*
            En esta funcion muestro u oculto las cajas de texto de la 
            busqueda segun la seleccion en los checkbox
             */
            if (e.Index == 1)
            {
                if (e.CurrentValue == System.Windows.Forms.CheckState.Checked)
                {
                    txT.Clear();
                    pnTit.Visible=false;
                }
                else
                {
                    pnTit.Visible = true;
                }
            }

            if (e.Index == 2)
            {
                if (e.CurrentValue == System.Windows.Forms.CheckState.Checked)
                {
                    txP.Clear();
                    pnPal.Visible = false; 
                }
                else
                {
                    pnPal.Visible = true;
                }
            }
        }

        private void trwCliente_DoubleClick(object sender, EventArgs e)
        {
           // MessageBox.Show();
            
        }

        private void trwCliente_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cliente cli = new Cliente();
            string sId = e.Node.Tag.ToString();
            cli.TraerClienteID(Int32.Parse(sId));
            lbNom_Cli.Text = cli.Nombre1 + "  " + cli.Apellido1;
            lbDireccion.Text = cli.Direccion1;
        }

        private void chBuscar_CheckedChanged(object sender, EventArgs e)
        {
            if (chBuscar.Checked)
            {
                pnBusquedaDoc.Visible = true;
            }
            else {
                pnBusquedaDoc.Visible = false;
            }
        }

        private void trwDoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            InicializarWord();
            string sP = e.Node.Tag.ToString();
            AbrirDocumento(sP);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            Documento doc = new Documento();
            doc.TraerPath(oDoc.FullName);
            int nId = doc.Id;
            if (nId > 0){
                if (MessageBox.Show("ESTA ACCION ELIMINARA EL DOCUMENTO EN DISCO Y EN BASE DE DATOS DE FORMA PERMANENTE.\n DESEA CONTINUAR?",
                               " ELIMINAR DOCUMENTO ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (doc.EliminarId(nId))
                    {
                        Palabras_Busqueda pal = new Palabras_Busqueda();
                        pal.EliminarId(nId);

                        MessageBox.Show("DOCUMENTO ELIMINADO CON EXITO", "SEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarSave();
                        File.Delete(doc.Path1);

                    }
                }
            }
            
        }
    }
}
