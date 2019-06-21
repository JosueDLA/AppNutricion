using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.Models
{
    public class Consulta
    {
        public int idConsulta { get; set; }
        public DateTime Fecha { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public string UsuarioNombre { get; set; }
        public string Edad { get; set; }
        public List<ConsultaDetalle> Detalle { get; set; }
    }
}
