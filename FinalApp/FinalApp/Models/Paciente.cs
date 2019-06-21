using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.Models
{
    public class Paciente
    {
        public int idPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DPI { get; set; }
        public string Telefono { get; set; }
        public List<Consulta> Consulta { get; set; }
    }
}
