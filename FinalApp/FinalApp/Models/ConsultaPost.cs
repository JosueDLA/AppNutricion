using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.Models
{
    class ConsultaPost
    {
        public int idPaciente { get; set; }

        public int idUsuario { get; set; }

        public int idPuesto { get; set; }

        public string Altura { get; set; }

        public string Peso { get; set; }

        public string Edad { get; set; }

        public List<ConsultaDetalle> Detalle { get; set; }
    }
}
