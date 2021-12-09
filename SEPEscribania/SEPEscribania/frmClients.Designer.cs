namespace SEPEscribania
{
    partial class frmClients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClients));
            this.pnFoo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fbDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.imgListDir = new System.Windows.Forms.ImageList(this.components);
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.pnGrillas = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trwDoc = new System.Windows.Forms.TreeView();
            this.trwCliente = new System.Windows.Forms.TreeView();
            this.pnBusquedaDoc = new System.Windows.Forms.Panel();
            this.pnTit = new System.Windows.Forms.Panel();
            this.lbT = new System.Windows.Forms.Label();
            this.txT = new System.Windows.Forms.TextBox();
            this.pnPal = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbP = new System.Windows.Forms.Label();
            this.txP = new System.Windows.Forms.TextBox();
            this.btnCanBusqueda = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.chBuscar = new System.Windows.Forms.CheckBox();
            this.txNombre = new System.Windows.Forms.TextBox();
            this.btnSaveDatos = new System.Windows.Forms.Button();
            this.btnpCancelar = new System.Windows.Forms.Button();
            this.lbRuta = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txPalabras = new System.Windows.Forms.TextBox();
            this.lbDocRuta = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.lbViewDatos = new System.Windows.Forms.Label();
            this.lbViewDir = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.lbViewTel = new System.Windows.Forms.Label();
            this.txIdC = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnGuardar = new System.Windows.Forms.Panel();
            this.lbPath = new System.Windows.Forms.Label();
            this.lbNom_Cli = new System.Windows.Forms.Label();
            this.lbApellido = new System.Windows.Forms.Label();
            this.lbDireccion = new System.Windows.Forms.Label();
            this.lbTelefono = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chModificar = new System.Windows.Forms.CheckBox();
            this.pnFoo.SuspendLayout();
            this.pnGrillas.SuspendLayout();
            this.pnBusquedaDoc.SuspendLayout();
            this.pnTit.SuspendLayout();
            this.pnPal.SuspendLayout();
            this.pnGuardar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFoo
            // 
            this.pnFoo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnFoo.Controls.Add(this.button1);
            this.pnFoo.Controls.Add(this.btnNew);
            this.pnFoo.Controls.Add(this.btnSaveAs);
            this.pnFoo.Controls.Add(this.btnGuardar);
            this.pnFoo.Controls.Add(this.btnPath);
            this.pnFoo.Controls.Add(this.btnAbrir);
            this.pnFoo.Location = new System.Drawing.Point(119, 601);
            this.pnFoo.Name = "pnFoo";
            this.pnFoo.Size = new System.Drawing.Size(926, 60);
            this.pnFoo.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cerrar Activo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(779, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(133, 23);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "Doc. Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(623, 13);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(133, 23);
            this.btnSaveAs.TabIndex = 7;
            this.btnSaveAs.Text = "Guardar Como";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(471, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Modificar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(323, 13);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(133, 23);
            this.btnPath.TabIndex = 5;
            this.btnPath.Text = "Mostrar Path";
            this.btnPath.UseVisualStyleBackColor = true;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(170, 13);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(133, 23);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "Seleccionar Archivo";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "cliente.png");
            // 
            // imgListDir
            // 
            this.imgListDir.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListDir.ImageStream")));
            this.imgListDir.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListDir.Images.SetKeyName(0, "icono_word32.png");
            this.imgListDir.Images.SetKeyName(1, "w.ico");
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(62, 142);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 19;
            this.dtpFecha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpFecha_MouseDown);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(12, 555);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(133, 23);
            this.btnFacturar.TabIndex = 20;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // pnGrillas
            // 
            this.pnGrillas.Controls.Add(this.label2);
            this.pnGrillas.Controls.Add(this.label1);
            this.pnGrillas.Controls.Add(this.trwDoc);
            this.pnGrillas.Controls.Add(this.trwCliente);
            this.pnGrillas.Location = new System.Drawing.Point(199, 142);
            this.pnGrillas.Name = "pnGrillas";
            this.pnGrillas.Size = new System.Drawing.Size(685, 436);
            this.pnGrillas.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ruta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Clientes";
            // 
            // trwDoc
            // 
            this.trwDoc.Location = new System.Drawing.Point(227, 55);
            this.trwDoc.Name = "trwDoc";
            this.trwDoc.Size = new System.Drawing.Size(450, 336);
            this.trwDoc.TabIndex = 15;
            this.trwDoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwDoc_AfterSelect);
            // 
            // trwCliente
            // 
            this.trwCliente.Location = new System.Drawing.Point(7, 55);
            this.trwCliente.Name = "trwCliente";
            this.trwCliente.Size = new System.Drawing.Size(205, 336);
            this.trwCliente.TabIndex = 14;
            this.trwCliente.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwCliente_AfterSelect);
            this.trwCliente.DoubleClick += new System.EventHandler(this.trwCliente_DoubleClick);
            // 
            // pnBusquedaDoc
            // 
            this.pnBusquedaDoc.Controls.Add(this.pnTit);
            this.pnBusquedaDoc.Controls.Add(this.pnPal);
            this.pnBusquedaDoc.Controls.Add(this.btnCanBusqueda);
            this.pnBusquedaDoc.Controls.Add(this.btnBuscar);
            this.pnBusquedaDoc.Controls.Add(this.label6);
            this.pnBusquedaDoc.Controls.Add(this.checkedListBox1);
            this.pnBusquedaDoc.Location = new System.Drawing.Point(895, 142);
            this.pnBusquedaDoc.Name = "pnBusquedaDoc";
            this.pnBusquedaDoc.Size = new System.Drawing.Size(234, 436);
            this.pnBusquedaDoc.TabIndex = 22;
            // 
            // pnTit
            // 
            this.pnTit.Controls.Add(this.lbT);
            this.pnTit.Controls.Add(this.txT);
            this.pnTit.Location = new System.Drawing.Point(3, 106);
            this.pnTit.Name = "pnTit";
            this.pnTit.Size = new System.Drawing.Size(231, 68);
            this.pnTit.TabIndex = 28;
            this.pnTit.Visible = false;
            // 
            // lbT
            // 
            this.lbT.AutoSize = true;
            this.lbT.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbT.Location = new System.Drawing.Point(3, 1);
            this.lbT.Name = "lbT";
            this.lbT.Size = new System.Drawing.Size(71, 20);
            this.lbT.TabIndex = 22;
            this.lbT.Text = "Por Titulo";
            // 
            // txT
            // 
            this.txT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txT.Location = new System.Drawing.Point(3, 24);
            this.txT.Name = "txT";
            this.txT.Size = new System.Drawing.Size(225, 20);
            this.txT.TabIndex = 21;
            // 
            // pnPal
            // 
            this.pnPal.Controls.Add(this.label10);
            this.pnPal.Controls.Add(this.label9);
            this.pnPal.Controls.Add(this.lbP);
            this.pnPal.Controls.Add(this.txP);
            this.pnPal.Location = new System.Drawing.Point(3, 180);
            this.pnPal.Name = "pnPal";
            this.pnPal.Size = new System.Drawing.Size(228, 211);
            this.pnPal.TabIndex = 27;
            this.pnPal.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(200, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "(,)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Palabras separadas por comas ";
            // 
            // lbP
            // 
            this.lbP.AutoSize = true;
            this.lbP.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbP.Location = new System.Drawing.Point(0, 11);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(89, 20);
            this.lbP.TabIndex = 28;
            this.lbP.Text = "Por Palabras";
            // 
            // txP
            // 
            this.txP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txP.Location = new System.Drawing.Point(0, 34);
            this.txP.Multiline = true;
            this.txP.Name = "txP";
            this.txP.Size = new System.Drawing.Size(225, 97);
            this.txP.TabIndex = 27;
            // 
            // btnCanBusqueda
            // 
            this.btnCanBusqueda.Location = new System.Drawing.Point(141, 401);
            this.btnCanBusqueda.Name = "btnCanBusqueda";
            this.btnCanBusqueda.Size = new System.Drawing.Size(90, 23);
            this.btnCanBusqueda.TabIndex = 24;
            this.btnCanBusqueda.Text = "Cancelar";
            this.btnCanBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(3, 401);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 23);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Parametros de Busqueda";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "POR AÑO",
            "POR TITULO",
            "POR PALABRAS"});
            this.checkedListBox1.Location = new System.Drawing.Point(3, 55);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(228, 49);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // chBuscar
            // 
            this.chBuscar.AutoSize = true;
            this.chBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBuscar.Location = new System.Drawing.Point(898, 119);
            this.chBuscar.Name = "chBuscar";
            this.chBuscar.Size = new System.Drawing.Size(163, 21);
            this.chBuscar.TabIndex = 23;
            this.chBuscar.Text = "Buscar Documento";
            this.chBuscar.UseVisualStyleBackColor = true;
            this.chBuscar.CheckedChanged += new System.EventHandler(this.chBuscar_CheckedChanged);
            // 
            // txNombre
            // 
            this.txNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txNombre.Location = new System.Drawing.Point(142, 34);
            this.txNombre.Name = "txNombre";
            this.txNombre.Size = new System.Drawing.Size(341, 20);
            this.txNombre.TabIndex = 1;
            // 
            // btnSaveDatos
            // 
            this.btnSaveDatos.Location = new System.Drawing.Point(273, 401);
            this.btnSaveDatos.Name = "btnSaveDatos";
            this.btnSaveDatos.Size = new System.Drawing.Size(133, 23);
            this.btnSaveDatos.TabIndex = 3;
            this.btnSaveDatos.Text = "Salvar Datos";
            this.btnSaveDatos.UseVisualStyleBackColor = true;
            this.btnSaveDatos.Click += new System.EventHandler(this.btnSaveDatos_Click_1);
            // 
            // btnpCancelar
            // 
            this.btnpCancelar.Location = new System.Drawing.Point(532, 401);
            this.btnpCancelar.Name = "btnpCancelar";
            this.btnpCancelar.Size = new System.Drawing.Size(133, 23);
            this.btnpCancelar.TabIndex = 4;
            this.btnpCancelar.Text = "Cancelar";
            this.btnpCancelar.UseVisualStyleBackColor = true;
            this.btnpCancelar.Click += new System.EventHandler(this.btnpCancelar_Click);
            // 
            // lbRuta
            // 
            this.lbRuta.AutoSize = true;
            this.lbRuta.Location = new System.Drawing.Point(15, 41);
            this.lbRuta.Name = "lbRuta";
            this.lbRuta.Size = new System.Drawing.Size(0, 13);
            this.lbRuta.TabIndex = 6;
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(142, 63);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(385, 21);
            this.cbCliente.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(489, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ".docx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nombre Archivo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo Archivo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Palabras Busqueda";
            // 
            // txPalabras
            // 
            this.txPalabras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txPalabras.Location = new System.Drawing.Point(142, 106);
            this.txPalabras.Multiline = true;
            this.txPalabras.Name = "txPalabras";
            this.txPalabras.Size = new System.Drawing.Size(385, 89);
            this.txPalabras.TabIndex = 15;
            // 
            // lbDocRuta
            // 
            this.lbDocRuta.AutoSize = true;
            this.lbDocRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDocRuta.Location = new System.Drawing.Point(275, 317);
            this.lbDocRuta.Name = "lbDocRuta";
            this.lbDocRuta.Size = new System.Drawing.Size(0, 13);
            this.lbDocRuta.TabIndex = 16;
            // 
            // btnFolder
            // 
            this.btnFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnFolder.Image")));
            this.btnFolder.Location = new System.Drawing.Point(142, 244);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(118, 100);
            this.btnFolder.TabIndex = 17;
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // lbViewDatos
            // 
            this.lbViewDatos.AutoSize = true;
            this.lbViewDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbViewDatos.Location = new System.Drawing.Point(275, 219);
            this.lbViewDatos.Name = "lbViewDatos";
            this.lbViewDatos.Size = new System.Drawing.Size(0, 13);
            this.lbViewDatos.TabIndex = 18;
            // 
            // lbViewDir
            // 
            this.lbViewDir.AutoSize = true;
            this.lbViewDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbViewDir.Location = new System.Drawing.Point(275, 256);
            this.lbViewDir.Name = "lbViewDir";
            this.lbViewDir.Size = new System.Drawing.Size(0, 13);
            this.lbViewDir.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(90, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Cliente";
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(142, 214);
            this.txtCedula.Mask = "#.###.###-#";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(118, 23);
            this.txtCedula.TabIndex = 23;
            this.txtCedula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCedula_KeyDown);
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // lbViewTel
            // 
            this.lbViewTel.AutoSize = true;
            this.lbViewTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbViewTel.Location = new System.Drawing.Point(275, 276);
            this.lbViewTel.Name = "lbViewTel";
            this.lbViewTel.Size = new System.Drawing.Size(0, 13);
            this.lbViewTel.TabIndex = 25;
            // 
            // txIdC
            // 
            this.txIdC.Location = new System.Drawing.Point(273, 354);
            this.txIdC.Name = "txIdC";
            this.txIdC.Size = new System.Drawing.Size(37, 20);
            this.txIdC.TabIndex = 26;
            this.txIdC.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(18, 401);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(133, 23);
            this.btnEliminar.TabIndex = 27;
            this.btnEliminar.Text = "Eliminar Documento";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pnGuardar
            // 
            this.pnGuardar.Controls.Add(this.chModificar);
            this.pnGuardar.Controls.Add(this.btnEliminar);
            this.pnGuardar.Controls.Add(this.txIdC);
            this.pnGuardar.Controls.Add(this.lbViewTel);
            this.pnGuardar.Controls.Add(this.txtCedula);
            this.pnGuardar.Controls.Add(this.label8);
            this.pnGuardar.Controls.Add(this.lbViewDir);
            this.pnGuardar.Controls.Add(this.lbViewDatos);
            this.pnGuardar.Controls.Add(this.btnFolder);
            this.pnGuardar.Controls.Add(this.lbDocRuta);
            this.pnGuardar.Controls.Add(this.txPalabras);
            this.pnGuardar.Controls.Add(this.label7);
            this.pnGuardar.Controls.Add(this.label5);
            this.pnGuardar.Controls.Add(this.label4);
            this.pnGuardar.Controls.Add(this.label3);
            this.pnGuardar.Controls.Add(this.cbCliente);
            this.pnGuardar.Controls.Add(this.lbRuta);
            this.pnGuardar.Controls.Add(this.btnpCancelar);
            this.pnGuardar.Controls.Add(this.btnSaveDatos);
            this.pnGuardar.Controls.Add(this.txNombre);
            this.pnGuardar.Controls.Add(this.lbPath);
            this.pnGuardar.Location = new System.Drawing.Point(199, 142);
            this.pnGuardar.Name = "pnGuardar";
            this.pnGuardar.Size = new System.Drawing.Size(682, 436);
            this.pnGuardar.TabIndex = 12;
            this.pnGuardar.Visible = false;
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(15, 11);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(0, 13);
            this.lbPath.TabIndex = 0;
            this.lbPath.Visible = false;
            // 
            // lbNom_Cli
            // 
            this.lbNom_Cli.AutoSize = true;
            this.lbNom_Cli.Location = new System.Drawing.Point(9, 17);
            this.lbNom_Cli.Name = "lbNom_Cli";
            this.lbNom_Cli.Size = new System.Drawing.Size(0, 13);
            this.lbNom_Cli.TabIndex = 0;
            // 
            // lbApellido
            // 
            this.lbApellido.AutoSize = true;
            this.lbApellido.Location = new System.Drawing.Point(274, 17);
            this.lbApellido.Name = "lbApellido";
            this.lbApellido.Size = new System.Drawing.Size(0, 13);
            this.lbApellido.TabIndex = 1;
            // 
            // lbDireccion
            // 
            this.lbDireccion.AutoSize = true;
            this.lbDireccion.Location = new System.Drawing.Point(9, 46);
            this.lbDireccion.Name = "lbDireccion";
            this.lbDireccion.Size = new System.Drawing.Size(0, 13);
            this.lbDireccion.TabIndex = 2;
            // 
            // lbTelefono
            // 
            this.lbTelefono.AutoSize = true;
            this.lbTelefono.Location = new System.Drawing.Point(274, 46);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(0, 13);
            this.lbTelefono.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTelefono);
            this.panel1.Controls.Add(this.lbDireccion);
            this.panel1.Controls.Add(this.lbApellido);
            this.panel1.Controls.Add(this.lbNom_Cli);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(199, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 80);
            this.panel1.TabIndex = 17;
            // 
            // chModificar
            // 
            this.chModificar.AutoSize = true;
            this.chModificar.Location = new System.Drawing.Point(344, 357);
            this.chModificar.Name = "chModificar";
            this.chModificar.Size = new System.Drawing.Size(80, 17);
            this.chModificar.TabIndex = 28;
            this.chModificar.Text = "checkBox1";
            this.chModificar.UseVisualStyleBackColor = true;
            this.chModificar.Visible = false;
            // 
            // frmClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 673);
            this.Controls.Add(this.chBuscar);
            this.Controls.Add(this.pnBusquedaDoc);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnFoo);
            this.Controls.Add(this.pnGuardar);
            this.Controls.Add(this.pnGrillas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visualizar Clientes";
            this.pnFoo.ResumeLayout(false);
            this.pnGrillas.ResumeLayout(false);
            this.pnGrillas.PerformLayout();
            this.pnBusquedaDoc.ResumeLayout(false);
            this.pnBusquedaDoc.PerformLayout();
            this.pnTit.ResumeLayout(false);
            this.pnTit.PerformLayout();
            this.pnPal.ResumeLayout(false);
            this.pnPal.PerformLayout();
            this.pnGuardar.ResumeLayout(false);
            this.pnGuardar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnFoo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog fbDialog;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ImageList imgListDir;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnGrillas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView trwDoc;
        private System.Windows.Forms.TreeView trwCliente;
        private System.Windows.Forms.Panel pnBusquedaDoc;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCanBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnTit;
        private System.Windows.Forms.Label lbT;
        private System.Windows.Forms.TextBox txT;
        private System.Windows.Forms.Panel pnPal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbP;
        private System.Windows.Forms.TextBox txP;
        private System.Windows.Forms.CheckBox chBuscar;
        private System.Windows.Forms.TextBox txNombre;
        private System.Windows.Forms.Button btnSaveDatos;
        private System.Windows.Forms.Button btnpCancelar;
        private System.Windows.Forms.Label lbRuta;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txPalabras;
        private System.Windows.Forms.Label lbDocRuta;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label lbViewDatos;
        private System.Windows.Forms.Label lbViewDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.Label lbViewTel;
        private System.Windows.Forms.TextBox txIdC;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnGuardar;
        private System.Windows.Forms.Label lbNom_Cli;
        private System.Windows.Forms.Label lbApellido;
        private System.Windows.Forms.Label lbDireccion;
        private System.Windows.Forms.Label lbTelefono;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.CheckBox chModificar;
    }
}