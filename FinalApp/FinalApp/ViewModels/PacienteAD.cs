using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using FinalApp.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalApp.ViewModels
{
    public class PacienteAD 
    {
        public Command LoadPacientesAD { get; set; }

        public PacienteAD()
        {
            LoadPacientesAD = new Command(async () => await SelectPacienteAsync());
        }

        public async Task<List<Paciente>> SelectPacienteAsync()
        {
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                HttpClient client = new HttpClient();

                var uri = new Uri("https://webapinutricion.azurewebsites.net/api/Pacientes?type=json");
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    pacientes = JsonConvert.DeserializeObject<List<Paciente>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
            }
            
            return pacientes;
        }
    }
}
