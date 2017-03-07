using System;

namespace ReporteAnualEmpleados.Modelos
{
    public class DatosDim
    {
        private decimal gastoEmpresa, bonoDespensa, bonoDecembrino, beca;

        public int NumeroEmpleado { set; get; }
        public string Nombre { set; get; }
        public string RFC { set; get; }
        public decimal GastoEmpresa {
            set { gastoEmpresa = value; }
            get { return Math.Round(gastoEmpresa, 0); }
        }
        public decimal BonoDespensa {
            set { bonoDespensa = value; }
            get { return Math.Round(bonoDespensa, 0); }
        }
        public decimal BonoDecembrino {
            set { bonoDecembrino = value; }
            get { return Math.Round(bonoDecembrino, 0); }
        }
        public decimal Beca
        {
            set { beca = value; }
            get { return Math.Round(beca, 0);}
        }
    }
}
