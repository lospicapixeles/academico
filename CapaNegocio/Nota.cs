using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Nota
    {
        public string CodAlumno { get; set; }
        public string CodAsignatura { get; set; }
        public string Semestre { get; set; }
        public float Parcial1 { get; set; }
        public float Parcial2 { get; set; }
        public float NotaFinal { get; set; }
    }
}
