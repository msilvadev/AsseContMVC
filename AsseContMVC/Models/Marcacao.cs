using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsseContMVC.Models
{
    public class Marcacao
    {
        public int Nsr { get; set; }
        public string TipoRegistro { get; set; }
        public string DataMarcacao { get; set; }
        public string HoraMarcacao { get; set; }
        public long Pis { get; set; }
    }
}