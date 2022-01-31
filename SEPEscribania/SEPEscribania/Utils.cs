using System;
using System.IO;
using System.Windows.Forms;

namespace SEPEscribania
{
    class Utils
    {
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

        //Esta funcion llena el treeview carpeta
        public void LlenarNodos(TreeNode nodo, string[] sDir)
        {

            foreach (string Path in sDir)
            {
                TreeNode nodoHijo = new TreeNode();
                FileInfo fileInfo = new FileInfo(Path);
                nodoHijo.Text = fileInfo.Name;
                nodoHijo.Tag = fileInfo.FullName;
                if ((fileInfo.Extension == ".docx") || (fileInfo.Extension == ".doc") || (fileInfo.Extension == ".DOCX") || (fileInfo.Extension == ".DOC"))
                {
                    nodoHijo.SelectedImageKey = "icono_word32.png";
                    nodoHijo.ImageKey = "icono_word32.png";
                }
                else if ((fileInfo.Extension == ".xls") || (fileInfo.Extension == ".xlsx"))
                {
                    nodoHijo.SelectedImageKey = "icono_excel.png";
                    nodoHijo.ImageKey = "icono_excel.png";
                }
                else if ((fileInfo.Extension == ".rar") || (fileInfo.Extension == ".zip"))
                {
                    nodoHijo.SelectedImageKey = "iconorar.png";
                    nodoHijo.ImageKey = "iconorar.png";
                }
                else
                {
                    nodoHijo.SelectedImageKey = "ifile.png";
                    nodoHijo.ImageKey = "ifile.png";
                }
                nodo.Nodes.Add(nodoHijo);

            }

        }

        public static bool Validar(TextBox txParam, String sRes)
        {/*
            Esta funcion valida que los TextBox no esten vacios
             */
            bool lOk = true;
            if ((txParam.Text == "") || (txParam.Text == "\r\n" ))
            {
                MessageBox.Show("INGRESE VALOR " + sRes, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txParam.Focus();
                lOk = false;
            }
            return lOk;
        }

        public static bool Validar(MaskedTextBox txParam, String sRes)
        {/*
            Esta funcion valida que el campo cedula, no esté vacio
             */
            bool lOk = true;
            if ((txParam.Text == "") || (txParam.Text == "\r\n"))
            {
                MessageBox.Show("INGRESE VALOR " + sRes, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txParam.Focus();
                lOk = false;
            }
            return lOk;
        }
        public static bool Validar(TextBox txPara, TextBox txPara2)
        {/*
            Esta funcion valida que el campo cedula, no esté vacio
             */
            bool lOk = true;
            if (txPara.Text != txPara2.Text)
            {
                MessageBox.Show("LAS CONTRASEÑAS NO SON IGUALES", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txPara2.Clear();
                txPara2.Focus();
                lOk = false;
            }
            return lOk;
        }
        public static string EncriptarPass(TextBox tx)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(tx.Text);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
