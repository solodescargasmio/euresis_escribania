namespace SEPEscribania
{
    partial class frmTipDoc
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
            this.pnMain = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.txDescripcion = new System.Windows.Forms.TextBox();
            this.txTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.txCodigo = new System.Windows.Forms.TextBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.pnMain.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.btCancelar);
            this.pnMain.Controls.Add(this.btGuardar);
            this.pnMain.Controls.Add(this.txDescripcion);
            this.pnMain.Controls.Add(this.txTipo);
            this.pnMain.Controls.Add(this.label2);
            this.pnMain.Controls.Add(this.label1);
            this.pnMain.Location = new System.Drawing.Point(3, 109);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(480, 318);
            this.pnMain.TabIndex = 3;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(354, 270);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click_1);
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(143, 270);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(75, 23);
            this.btGuardar.TabIndex = 5;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click_1);
            // 
            // txDescripcion
            // 
            this.txDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txDescripcion.Location = new System.Drawing.Point(146, 142);
            this.txDescripcion.MaxLength = 100;
            this.txDescripcion.Multiline = true;
            this.txDescripcion.Name = "txDescripcion";
            this.txDescripcion.Size = new System.Drawing.Size(283, 69);
            this.txDescripcion.TabIndex = 4;
            // 
            // txTipo
            // 
            this.txTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txTipo.Location = new System.Drawing.Point(143, 76);
            this.txTipo.Multiline = true;
            this.txTipo.Name = "txTipo";
            this.txTipo.Size = new System.Drawing.Size(286, 47);
            this.txTipo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DESCRIPCION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TIPO";
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.txCodigo);
            this.pnHeader.Controls.Add(this.lbCodigo);
            this.pnHeader.Location = new System.Drawing.Point(3, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(532, 95);
            this.pnHeader.TabIndex = 2;
            // 
            // txCodigo
            // 
            this.txCodigo.Location = new System.Drawing.Point(133, 25);
            this.txCodigo.Name = "txCodigo";
            this.txCodigo.Size = new System.Drawing.Size(104, 20);
            this.txCodigo.TabIndex = 1;
            this.txCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txCodigo_KeyPress_1);
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.Location = new System.Drawing.Point(39, 28);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(88, 13);
            this.lbCodigo.TabIndex = 0;
            this.lbCodigo.Text = "CODIGO TIPO";
            // 
            // frmTipDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 429);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnHeader);
            this.Name = "frmTipDoc";
            this.Text = "frmTipDoc";
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.TextBox txDescripcion;
        private System.Windows.Forms.TextBox txTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.TextBox txCodigo;
        private System.Windows.Forms.Label lbCodigo;
    }
}