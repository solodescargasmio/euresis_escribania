using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;

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
            
            this.ttMensaje.SetToolTip(this.dtpFecha, "SELECCIONE AÑO PARA FILTRAR DOCUMENTOS");
            this.ttMensaje.SetToolTip(this.txNombre, "NOMBRE DE DOCUMENTO EN BASE DE DATOS");
            this.ttMensaje.SetToolTip(this.cbCliente, "SELECCIONE EL TIPO DE DOCUMENTO QUE SE GUARDA");
            this.ttMensaje.SetToolTip(this.txPalabras, "INGRESE LAS PALABRAS CON LAS QUE LUEGO SE BUSCARA EL DOCUMENTO");
            this.ttMensaje.SetToolTip(this.txtCedula, "INGRESE CEDULA CLIENTE AL QUE PERTENECE EL DOCUMENTO");
            this.ttMensaje.SetToolTip(this.txT, "TITULO DEL DOCUMENTO A FILTRAR");
            this.ttMensaje.SetToolTip(this.txP, "PALABRAS INGRESADAS PARA FILTRAR DOCUMENTO");
            this.ttMensaje.SetToolTip(this.chBuscar, "MOSTRAR OPCIONES DOCUMENTO A FILTRAR");
            this.ttMensaje.SetToolTip(this.btnActClient,"ACTUALIZA LISTA CLIENTES (SI AGREGA NUEVO Y NO APARECE)");
            //this.ttMensaje.SetToolTip(this.txT, "TITULO DEL DOCUMENTO A FILTRAR");
            //pcbRecargar.ImageLocation = Application.StartupPath + @"\img\recargar.png";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat="yyyy";
            dtpFecha.ShowUpDown = true;
            InicializarWord(); //Inicializa aunque deja vacia la instancia de proceso word
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
            KillAllTasksByName("WINWORD");
            try
            {
                if (oWord != null)
                {
                    oWord.Quit(false);
                    oDoc.Close();
                }
            }
            catch
            {
            }
            oWord = new Word.Application();
            oDoc = new Word.Document(); 
        }

        private void KillAllTasksByName(string taskName)
        {
            try
            {
                foreach (Process proceso in Process.GetProcessesByName(taskName))
                {
                    proceso.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            trwDoc.Nodes.Clear();
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

        private void AbrirDocumento(string sDoc)
        {/*
            Esta funcion abre el documento word seleccionado
             */
            oDoc = oWord.Documents.Open(sDoc, false, false, false);//abre el documento en la aplicacion word

            oWord.Visible = true;//hace visible el documento
            oWord.Activate();
            oDoc.Activate();//pone este documento como activo
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

        public void AbrirSave() {
            /*
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

                    foreach (Tipo_Doc ti in tipos)
                    {
                        dictionary.Add(ti.Id, ti.Tipo1);
                    }
                    cbCliente.DataSource = new BindingSource(dictionary, null);
                    cbCliente.DisplayMember = "Value";
                    cbCliente.ValueMember = "Key";
                    cbCliente.SelectedIndex = 0;
                    lbDocRuta.Text = @"C:\Euresis_Escribania\" + dtpFecha.Text;
                    Documento doc = new Documento();
                    if (documento != null) {
                        doc.TraerPath(documento.Path1);
                    }
                    if (doc.Id > 0 )
                    {
                        btnEliminar.Enabled = true;
                        string[] fec = doc.Titulo1.Split('_');
                        string[] nombre = fec[1].Split('.');
                        txDate.Text = fec[0];
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
                    else { btnEliminar.Enabled = false;
                        txDate.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
                    }

                }
                else
                {
                    MessageBox.Show("SELECCIONE ARCHIVO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                Cerrar();
            }

        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {/*
            Esta funcion permite visualizar el panel desde donde se
            podra guardar el documento, permitiendo seleccionar la carpeta, 
            el cliente, el año es por default, el que está seleccionado en el combobox,
            el path del documento, el tipo d edocumetno, el titulo y las palabras relacionadas para la busqueda.
             */
            AbrirSave();
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
            chModificar.Checked = true;
            documento = new Documento();
            documento.TraerPath(oDoc.FullName);
            AbrirSave();   
        }
       

        private void btnSaveDatos_Click_1(object sender, EventArgs e)
        {/*
            Esta funcion es la encargada de guardar el documento en una 
            carpeta distinta de la que fue abierto.
             */

            bool lOk;
            string[] palabras;
            lbDocRuta.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//@"C:\\Euresis_Escribania\\" + dtpFecha.Text;
            Int32 nIdT = ((KeyValuePair<Int32, string>)cbCliente.SelectedItem).Key;//obtiene id tipo del combobox
            lOk = ValidarTexto(txNombre,"NOMBRE");
            if (lOk) {
                lOk = ValidarTexto(txPalabras, "PALABRAS BUSQUEDA");
            }
            if (lOk) {
                if (txtCedula.Text == " .   .   -")
                {
                    MessageBox.Show("BUSCAR CLIENTE POR CI", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCedula.Focus();
                    lOk = false;
                }
            }

            if (lOk) {
                if (lbDocRuta.Text == "")
                {
                    MessageBox.Show("SELECCIONE UN DIRECTORIO DONDE GUARDAR EL ARCHIVO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnFolder.Focus();
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
                    Palabras_Busqueda pl = new Palabras_Busqueda();
                    doc.Titulo1 = txDate.Text +"_"+ txNombre.Text;
                    doc.Path1 = sRuta + @"/" +txDate.Text +"_"+ txNombre.Text + ".docx";
                    doc.IdCliente = Int32.Parse(txIdC.Text);
                    doc.IdTipo = nIdT;
                    doc.Anio1 = dtpFecha.Text;
                    doc.Usuario1 = Int32.Parse(Session.User);
                    doc.Fecha = DateTime.Now.ToString();
                    
                    int nIdDoc = 0;
                    if (chModificar.Checked)//si true, se presionó el boton modificar
                    {
                        nIdDoc = documento.Id;
                        pl.EliminarId(nIdDoc);
                        doc.ModificarDocumento();  
                    }
                    else {
                        nIdDoc = doc.Guardar();//si false, se guarda como un nuevo registro
                    }

                    
                    if (txPalabras.Text!="") {
                        
                       lOk = pl.Guardar_Palabras(txPalabras.Text, nIdDoc);
                    }
                    
                    if (nIdDoc > 0) {
                        object saveAs = lbDocRuta.Text+ "\\" +txDate.Text + "_" + txNombre.Text + ".docx";
                        oWord.ActiveDocument.SaveAs(ref saveAs,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing);
                        MessageBox.Show("ARCHIVO GUARDADO CON EXITO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL GUARDAR ARCHIVO. VERIFIQUE  "+ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                IniPat();
                Cerrar();
            }
            chModificar.Checked = false;
            documento = null;

        }
        public void IniPat() {
            /*
             Esta funcion limpia los valores del panel de Save archivo
             */
            txIdC.Clear();
            txNombre.Clear();
            txPalabras.Clear();
            txtCedula.Clear();
            lbViewDatos.Text = "";
            lbViewDir.Text = "";
            lbViewTel.Text = "";
        }
        public void LimpiarSave()
        {
            /*
             Esta funcion limpia el panel 
             */
            if (pnGuardar.Visible == true)
            {
                documento = null;
                chModificar.Checked = false;
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


        public bool ValidarTexto(TextBox tx, string sTexto) {
            /*
             Esta funcion se encarga de validar el text box que creamos obligatorios.
             */
            bool lOk = true;
            if (tx.Text=="") {
                lOk = false;
                MessageBox.Show("EL CAMPO "+sTexto+" NO PUEDE SER VACIO.", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("YA EXISTE UNA INSTANCIA ABIERTA DE WORD. CIERRELA O CONTINUE TRABAJANDO CON LA MISMA", "INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    
                    openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;//Esto le dice al programa en que directorio comenzar a buscar.
                    openFileDialog1.FileName = "";
                    openFileDialog1.Filter = "Office | *.docx;*.DOCX;*.doc;*.DOC";//con esto filtro el tipo de documento que permito abrir, en este caso solo documentos word
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.FileName.Contains("C:\\Euresis_Escribania"))
                        {
                            MessageBox.Show("CARPETA RESTRINGIDA, SOLO USO INTERNO DEL SISTEMA");
                        }
                        else {
                            sPath = openFileDialog1.FileName;//captura el path completo del documento que intenta abrir
                            AbrirDocumento(sPath);
                        }
                        
                    };
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR CATCH "+ex,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
        {/*
            Esta funcion se encarga de capturar el valor devuelto del
            formulario client_new al ingresar un cliente nuevo desde el boton nuevo 
            de este formulario
             */
            Cliente cli = new Cliente();
            txtCedula.Text = texto;
            cli.TraerCliente(Int32.Parse(texto));
            txIdC.Text = Convert.ToString(cli.Id);
            lbViewDatos.Text = cli.Nombre1 + "  " + cli.Apellido1;
            lbViewDir.Text = "DIRECCION : " + cli.Direccion1;
            lbViewTel.Text = "CONTACTOS : " + cli.Telefono1 + " - " + cli.Celular1;

        }

        public void Ejecutar(string texto, string sPath)
        {
            throw new NotImplementedException();
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {/*
            Esta funcion llama el form ayuda cliente y 
            captura el valor devuelto por este
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
                    if (cli.CI1 > 0)
                    {
                        lbViewDatos.Text = cli.Nombre1 + "  " + cli.Apellido1;
                        lbViewDir.Text = "DIRECCION : " + cli.Direccion1;
                        lbViewTel.Text = "CONTACTOS : " + cli.Telefono1 + " - " + cli.Celular1;
                        txIdC.Text = cli.Id.ToString();
                        btnSaveDatos.Focus();
                    }
                    else {
                        MessageBox.Show("CLIENTE NO EXISTE. ","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtCedula.Clear();
                        txtCedula.Focus();
                    }

                }
                
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
            y verifico que se ingrese el texto a buscar en la base de datos
             */
            trwDoc.Nodes.Clear();
            int i;
            string sAnd = " and ", sParam = "", sInner = "";
            string sSQL = " select DISTINCT d.* from documento d ";
            bool lOk=false,s=false,w=false,tp=false;
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
                                tp = true;
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
                                if (s || tp)//Si alguna de las 2 variables es true, agrego el and para concatenar la consulta
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
                            }
                            break;
                    }
                    lOk = true;
                }
            }
            if (!lOk)
            {
                MessageBox.Show("SELECCIONE AL MENOS UN PARAMETRO DE BUSQUEDA", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                if (w) {
                   sInner = sInner + " Where ";
                }
                sSQL = sSQL + sInner + sParam;
                Documento doc = new Documento();
                List<Documento> documentos = new List<Documento>();
                documentos = doc.TraerDocParametros(sSQL);
                if (documentos.Count > 0)//Si es mayor a 0, trae resultados y los muestra en treeview
                {
                    foreach (Documento d in doc.TraerDocParametros(sSQL))
                    {
                        TreeNode node = new TreeNode();
                        node.Tag = d.Path1;
                        node.Text = d.Titulo1 + ".docx";
                        trwDoc.Nodes.Add(node);
                    }
                }
                else {
                    MessageBox.Show("NO SE ENCONTARON COINCIDENCIAS PARA LA BUSQUEDA ACTUAL.\n" +
                        " MODIFICAR PARAMETROS DE BUSQUEDA","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
        public void Visualizar_Panel(bool lOk) {
            pnPal.Visible = lOk;
            pnTit.Visible = !lOk;
        }

        private void trwCliente_DoubleClick(object sender, EventArgs e)
        {
           // MessageBox.Show();
            
        }

        private void trwCliente_AfterSelect(object sender, TreeViewEventArgs e)
        {/*
            Esta funcion trae los datos del cliente seleccionado en la grilla
            y los muestra en un panel en la parte superior
             */

            trwDoc.Nodes.Clear();
            Cliente cli = new Cliente();
            string sId = e.Node.Tag.ToString();
            cli.TraerClienteID(Int32.Parse(sId));
            lbNom_Cli.Text = cli.Nombre1 + "  " + cli.Apellido1;
            lbDireccion.Text = cli.Direccion1;
            Documento doc = new Documento();
            string sSQL = "Select * from documento where idCliente=" + cli.Id + " and Anio='" + dtpFecha.Text + "'";
            List<Documento> documentos = doc.TraerDocParametros(sSQL);
            foreach (Documento d in documentos) {
                TreeNode node = new TreeNode();
                node.Tag = d.Path1;
                node.Text = d.Titulo1;
                trwDoc.Nodes.Add(node);
            }
            foreach (TreeNode nod in trwCliente.Nodes) {
                nod.Checked = false;
            }
            
        }

        private void chBuscar_CheckedChanged(object sender, EventArgs e)
        {/*
               Esta funcion permite visualizar las opciones de busqueda de los documentos
               guardados en base de datos
             */
            HabSave(false);
            
            if (chBuscar.Checked)
            {   
                pnBusquedaDoc.Visible = true;
            }
            else {
                for (int i=0;i<checkedListBox1.Items.Count;i++) {
                    checkedListBox1.SetItemChecked(i,false);
                }
                pnBusquedaDoc.Visible = false;
            }
        }

        private void trwDoc_AfterSelect(object sender, TreeViewEventArgs e)
        {/*
            Esta funcion permite seleccionar un documento de la grilla y editarlo con
            la aplicacion word. En el campo tag de node, está guardado el path del documento
             */
            InicializarWord();
            string sP = e.Node.Tag.ToString();
            AbrirDocumento(sP);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {/*
            Esta funcion elimina de todo registro que haga referencia a el documento con id=doc.id
            de la base de datos y elimina el archivo de su ubicacion de forma permanente.  
             */

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

                        MessageBox.Show("DOCUMENTO ELIMINADO CON EXITO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarSave();
                        File.Delete(doc.Path1);

                    }
                }
            }
            
        }

        private void btnPath_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

        private void txNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) && (txNombre.Text != "")) {
                cbCliente.Focus();
            }
        }

        private void cbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txPalabras.Focus();
            }
        }

        private void txPalabras_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            Mueve el cursor al objeto siguiente
             */
            if ((e.KeyChar == (char)Keys.Enter) && (txPalabras.Text != "")) {
                txtCedula.Focus();
            }
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {/*
            Esta funcion llama al formulario para ingresar un cliente nuevo.
            Cuando se ingrese el cliente nuevo, se visualizaran los datos
            del nuevo cliente en este form.          
             */
            using (frmClient_new form = new frmClient_new())
            {
             //   form.cli_new = this;
                form.ShowDialog(this);
            }
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            trwDoc.Nodes.Clear();
            lbNom_Cli.Text = "";
            lbDireccion.Text = "";
            LlenarClienteAnio();
        }

        public void CrearDir()
        {/*
           Esta funcion crea un directorio en C://Euresis_Escribania mas el año del
           dtpFecha para guardar los documentos del año seleccionado
             * */
            string sDir = @"C:\\Euresis_Escribania\\" + dtpFecha.Text;
            if (!Directory.Exists(sDir))
            {
                Directory.CreateDirectory(sDir);
            }
            LlenarClienteAnio();
        }
        private void dtpFecha_MouseDown(object sender, MouseEventArgs e)
        {
            CrearDir();
        }

        private void btnActClient_Click(object sender, EventArgs e)
        {
            LlenarCliente();
        }
    }
}
