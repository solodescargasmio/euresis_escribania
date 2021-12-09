namespace SEPEscribania
{
    partial class frmRegistro_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistro_Usuario));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txCodigo = new System.Windows.Forms.TextBox();
            this.pnMain = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txNomCompleto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txRepitPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.pnHeader.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnHeader.Controls.Add(this.label1);
            this.pnHeader.Controls.Add(this.txCodigo);
            this.pnHeader.Location = new System.Drawing.Point(0, 2);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(612, 100);
            this.pnHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CODIGO";
            // 
            // txCodigo
            // 
            this.txCodigo.Location = new System.Drawing.Point(241, 42);
            this.txCodigo.Name = "txCodigo";
            this.txCodigo.Size = new System.Drawing.Size(181, 20);
            this.txCodigo.TabIndex = 0;
            this.txCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txCodigo_KeyPress);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnMain.Controls.Add(this.btnCancelar);
            this.pnMain.Controls.Add(this.btnGuardar);
            this.pnMain.Controls.Add(this.label5);
            this.pnMain.Controls.Add(this.txNomCompleto);
            this.pnMain.Controls.Add(this.label4);
            this.pnMain.Controls.Add(this.txRepitPass);
            this.pnMain.Controls.Add(this.label3);
            this.pnMain.Controls.Add(this.txPass);
            this.pnMain.Controls.Add(this.label2);
            this.pnMain.Controls.Add(this.txUsuario);
            this.pnMain.Location = new System.Drawing.Point(0, 100);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(612, 476);
            this.pnMain.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(393, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(143, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(149, 406);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(143, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "NOMBRE COMPLETO";
            // 
            // txNomCompleto
            // 
            this.txNomCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txNomCompleto.Location = new System.Drawing.Point(241, 235);
            this.txNomCompleto.Multiline = true;
            this.txNomCompleto.Name = "txNomCompleto";
            this.txNomCompleto.Size = new System.Drawing.Size(295, 77);
            this.txNomCompleto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(97, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "REPITA PASSWORD";
            // 
            // txRepitPass
            // 
            this.txRepitPass.Location = new System.Drawing.Point(241, 173);
            this.txRepitPass.Name = "txRepitPass";
            this.txRepitPass.PasswordChar = '*';
            this.txRepitPass.Size = new System.Drawing.Size(295, 20);
            this.txRepitPass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(146, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "PASSWORD";
            // 
            // txPass
            // 
            this.txPass.Location = new System.Drawing.Point(241, 121);
            this.txPass.Name = "txPass";
            this.txPass.PasswordChar = '*';
            this.txPass.Size = new System.Drawing.Size(295, 20);
            this.txPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "USUARIO";
            // 
            // txUsuario
            // 
            this.txUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txUsuario.Location = new System.Drawing.Point(241, 54);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.Size = new System.Drawing.Size(295, 20);
            this.txUsuario.TabIndex = 0;
            // 
            // frmRegistro_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 577);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistro_Usuario";
            this.Text = "Registro Usuario";
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txCodigo;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txNomCompleto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txRepitPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txUsuario;
        private System.Windows.Forms.Button btnCancelar;
    }
}