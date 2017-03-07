using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReporteAnualEmpleados.Modelos;
using Excel;
using System.Data;

namespace ReporteAnualEmpleados
{
    public partial class btnBuscarRFC : Form
    {
        private List<DatosDim> lstDatosDim;
        private string sFileName;
        private string[] sLineasArchivoDIM;
        private string[] sLineasCatRFC;

        private List<string[]> lstBonos;
        private List<string[]> lstDIM;

        public btnBuscarRFC()
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
            ofdArchivo.FileName = "*2*.txt";
            ofdArchivo.Filter = "Archivos de Texto | *.txt";
            BuscarArchivo(txbFileDIM, ref sLineasArchivoDIM);
            sFileName = ofdArchivo.SafeFileName;
        }

        private void btnBuscarBonos_Click(object sender, EventArgs e)
        {
            AbrirArchivoDeBonos();
        }
        private void AbrirArchivoDeBonos()
        {
            ofdArchivo.FileName = "*.xlsx";
            ofdArchivo.Filter = "Archivo Excel | *.xlsx";
            ofdArchivo.ShowDialog();
            try
            {
                FileStream stream = File.Open(ofdArchivo.FileName, FileMode.Open, FileAccess.Read);
                txbFileBonos.Text = ofdArchivo.FileName;
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                //4. DataSet - Create column names from first row
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();
                var TablaExcel = result.Tables[0];

                excelReader.Close();
                foreach (DataRow fila in TablaExcel.Rows)
                {
                    int numEmpleado = Convert.ToInt32(fila[0]);
                    var datoDim = lstDatosDim.FirstOrDefault(o => o.NumeroEmpleado == numEmpleado);
                    datoDim.Nombre = fila[1].ToString();
                    datoDim.GastoEmpresa = Convert.ToDecimal(fila[3] == DBNull.Value ? "0" : fila[3]);
                    datoDim.BonoDespensa = Convert.ToDecimal(fila[4] == DBNull.Value ? "0" : fila[4]);
                    datoDim.BonoDecembrino = Convert.ToDecimal(fila[5] == DBNull.Value ? "0" : fila[5]);
                    datoDim.Beca = Convert.ToDecimal(fila[6] == DBNull.Value ? "0" : fila[6]);
                }

                ActualizarTxbAcciones(string.Format("El archivo {0} se cargó correctamente...", ofdArchivo.SafeFileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (ValidarArchivos() == true)
            {
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
                LeerArchivoDIM();

                StreamWriter swFile =
                    new StreamWriter(Environment.CurrentDirectory + "\\Archivos\\" + sFileName, false, Encoding.Default);
                swFile.Close();

                StringBuilder sb;

                List<DatosDim> incio = new List<DatosDim>();

                foreach (DatosDim resp in lstDatosDim)
                {
                    incio.Add(new DatosDim
                    {
                        Beca = resp.Beca,
                        BonoDecembrino = resp.BonoDecembrino,
                        BonoDespensa = resp.BonoDespensa,
                        GastoEmpresa = resp.GastoEmpresa,
                        Nombre = resp.Nombre,
                        NumeroEmpleado = resp.NumeroEmpleado,
                        RFC = resp.RFC

                    });
                }



                int i = 1;
                foreach (string[] vectorDIM in lstDIM)
                {
                    string RFC = vectorDIM[2];


                    var datoDim = incio.FirstOrDefault(o => o.RFC == RFC);


                    if (vectorDIM.Count() < 49)
                    {
                        modificarArchivo(vectorDIM);

                        continue;
                        /*
                        MessageBox.Show("No se encontro a la persona con el RFC: " + RFC);
                        return;
                        */
                    }


                    if (datoDim == null)
                    {
                        modificarArchivo(vectorDIM);
                        
                        sb = new StringBuilder();

                        sb.Append("No se encontro a la persona con el RFC: " + RFC);

                        ActualizarTxbAcciones(sb.ToString());

                        continue;
                        /*
                        MessageBox.Show("No se encontro a la persona con el RFC: " + RFC);
                        return;
                        */
                    }

                    //Obtener el dato de fondo de ahorro
                    vectorDIM[49] = datoDim.GastoEmpresa.ToString();

                    //Obtener dato de los bonos de despensa
                    vectorDIM[53] = datoDim.BonoDespensa.ToString();

                    //Obtener Dato para la beca
                    vectorDIM[83] = datoDim.Beca.ToString();

                    //Cambiar campos 96 y 97
                    vectorDIM[96] = (datoDim.BonoDespensa + datoDim.GastoEmpresa + datoDim.BonoDecembrino + datoDim.Beca).ToString();
                    vectorDIM[97] = (datoDim.BonoDespensa + datoDim.GastoEmpresa + datoDim.BonoDecembrino + datoDim.Beca).ToString();

                    sb = new StringBuilder();
                    sb.Append(i++.ToString().PadLeft(3));
                    sb.Append(" Procesado ");
                    sb.Append(RFC.PadLeft(13));
                    sb.Append(string.Format(" GastoEmpresa: {0};", datoDim.GastoEmpresa.ToString("n").PadLeft(9)));
                    sb.Append(string.Format(" BonoDecembrino: {0};", datoDim.BonoDecembrino.ToString("n").PadLeft(9)));
                    sb.Append(string.Format(" Bonos de despensa: {0};", datoDim.BonoDespensa.ToString("n").PadLeft(9)));

                    modificarArchivo(vectorDIM);

                    ActualizarTxbAcciones(sb.ToString());

                    // remueve seleccionado
                    incio.Remove(datoDim);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarArchivos()
        {
            if (txbFileDIM.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Seleccione el archivo de texto DIM...");
                return false;
            }
            if (txbFileBonos.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Seleccione el archivo de bonos...");
                return false;
            }
            if (txbFileCatRFC.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Seleccione el archivo del catalogo de empleados...");
                return false;
            }
                
            return true;   
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

        private void btnBuscarCatRFC_Click(object sender, EventArgs e)
        {
            ofdArchivo.FileName = "*CAT*.txt";
            ofdArchivo.Filter = "Archivos de Texto | *.txt";
            BuscarArchivo(txbFileCatRFC, ref sLineasCatRFC);

            try
            {
                if (sLineasCatRFC.Length != 0)
                {
                    DatosDim datosDim;
                    lstDatosDim = new List<DatosDim>();
                    foreach (string linea in sLineasCatRFC)
                    {
                        var vector = linea.Split('\t');
                        datosDim = new DatosDim();
                        datosDim.NumeroEmpleado = Convert.ToInt32(vector[0]);
                        datosDim.RFC = vector[4].Replace("\"", string.Empty);
                        lstDatosDim.Add(datosDim);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
