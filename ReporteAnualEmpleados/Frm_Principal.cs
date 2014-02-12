using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReporteAnualEmpleados
{
    public partial class Frm_Principal : Form
    {
        private string sFileName;
        private string[] sLineasArchivoDIM;
        private string[] sLineasArchivoBonos;

        private List<string[]> lstBonos;
        private List<string[]> lstDIM;

        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void ActualizarTxbAcciones(string s)
        {
            txbAcciones.Paste(s + Environment.NewLine);
        }

        private void BuscarArchivo(TextBox txb, ref string[] sLineasArchivo)
        {
            try
            {
                sLineasArchivo = null;

                DialogResult dr = ofdArchivo.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    txb.Text = ofdArchivo.FileName;
                }

                sLineasArchivo = File.ReadAllLines(ofdArchivo.FileName, Encoding.Default);

                ActualizarTxbAcciones(string.Format("El archivo {0} se cargó correctamente...", ofdArchivo.SafeFileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscarDIM_Click(object sender, EventArgs e)
        {
            BuscarArchivo(txbFileDIM, ref sLineasArchivoDIM);
            sFileName = ofdArchivo.SafeFileName;
        }

        private void btnBuscarBonos_Click(object sender, EventArgs e)
        {
            BuscarArchivo(txbFileBonos, ref sLineasArchivoBonos);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (ValidarArchivos() == true)
            {
                LeerArchivoDIM();
                LeerArchivoBonos();

                ActualizarTxbAcciones(string.Empty);
                ActualizarTxbAcciones("Iniciando proceso...");
                Procesar();
                ActualizarTxbAcciones("Proceso Terminado...");
            }
        }

        private void Procesar()
        {
            try
            {
                StreamWriter swFile =
                    new StreamWriter(Environment.CurrentDirectory + "\\Archivos\\" + sFileName, false, Encoding.Default);
                swFile.Close();

                StringBuilder sb;

                string RFC = string.Empty;
                string[] vectorBonos = null;

                string sAhorro = string.Empty;
                decimal dAhorro = 0;

                string sbono = string.Empty;
                decimal dBono = 0;

                int i = 1;
                foreach (string[] vectorDIM in lstDIM)
                {
                    //Obtener RFC
                    RFC = vectorDIM[2];

                    //Cambiar a Area B
                    vectorDIM[7] = "02";

                    //Obtenr el dato de fondo de ahorro
                    sAhorro = vectorDIM[49];
                    if (sAhorro != string.Empty)
                    {
                        dAhorro = Convert.ToDecimal(sAhorro);
                        dAhorro = (int)dAhorro / 2;

                        vectorDIM[49] = dAhorro.ToString();
                    }
                    else
                        dAhorro = 0;

                    //Obtener Vector del archivo de los bonos de despensa
                    vectorBonos = lstBonos.Find(o => o.Contains(RFC));

                    if (vectorBonos != null)
                    {
                        //Obtener el dato de bonos
                        sbono = vectorBonos[2];
                        if (sbono != string.Empty)
                        {
                            dBono = Convert.ToDecimal(sbono);
                            dBono = Convert.ToInt32(dBono);
                            vectorDIM[53] = dBono.ToString();
                        }
                        else
                            dBono = 0;
                    }
                    else
                    {
                        dBono = 0;
                    }

                    //Cambiar campos 96 y 97
                    vectorDIM[96] = (dAhorro + dBono).ToString();
                    vectorDIM[97] = (dAhorro + dBono).ToString();

                    sb = new StringBuilder();
                    sb.Append(i++.ToString().PadLeft(3));
                    sb.Append(" Procesado ");
                    sb.Append(RFC.PadLeft(13));
                    sb.Append(string.Format(" Ahorro Anterior: {0};",sAhorro));
                    sb.Append(string.Format(" Ahorro Final: {0};", dAhorro));
                    sb.Append(string.Format(" Bonos de despensa: {0};", dBono));

                    modificarArchivo(vectorDIM);

                    ActualizarTxbAcciones(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarArchivos()
        {
            bool exitoDIM = true;
            bool exitoBonos = true;

            if (sLineasArchivoDIM == null)
            {
                MessageBox.Show("Seleccione el archivo de texto DIM");
                return false;
            }
            else
            {
                exitoDIM = ValidarArchivoDIM();
            }

            if (sLineasArchivoBonos == null)
            {
                MessageBox.Show("Seleccione el archivo con la informacion de los bonos de despensa");
                return false;
            }
            else
            {
                exitoBonos= ValidarArchivoBonos();
            }

            if (exitoDIM && exitoBonos)
                return true;
            else
                return false;
        }

        private void LeerArchivoDIM()
        {
            string[] vector;

            lstDIM = new List<string[]>();

            foreach (string sLinea in sLineasArchivoDIM)
            {
                vector = new string[1];
                vector = sLinea.Split('|');
                lstDIM.Add(vector);
            }

            ActualizarTxbAcciones(string.Format("El archivo DIM se ha leido con exito!!!"));
        }

        private void LeerArchivoBonos()
        {
            string[] vector = null;

            lstBonos = new List<string[]>();

            foreach (string sLinea in sLineasArchivoBonos)
            {
                vector = new string[1];
                vector = sLinea.Split('\t');
                lstBonos.Add(vector);
            }

            ActualizarTxbAcciones(string.Format("El archivo de Bonos de despensa se ha leido con exito!!!"));
        }

        private bool ValidarArchivoBonos()
        {
            string[] vector = sLineasArchivoBonos[0].Split('\t');
            
            if (vector.Length != 5)
            {
                MessageBox.Show("El archivo de bonos no tiene el formato correcto", "Error", 
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarArchivoDIM()
        {
            string[] vector = sLineasArchivoDIM[0].Split('|');
            if (vector.Length < 110)
            {
                MessageBox.Show("El archivo DIM no tiene el formato correcto", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void modificarArchivo(string[] vector)
        {
            StringBuilder sLinea = new StringBuilder();
            foreach (string dato in vector)
            {
                sLinea.Append(dato);
                sLinea.Append("|");
            }

            sLinea.Remove(sLinea.Length - 1, 1);

            StreamWriter swFile = new StreamWriter(Environment.CurrentDirectory + "\\Archivos\\" + sFileName, true, Encoding.Default);
            swFile.WriteLine(sLinea.ToString());
            swFile.Close();
        }
    }
}
