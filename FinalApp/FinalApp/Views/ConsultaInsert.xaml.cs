using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalApp.ViewModels;
using FinalApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FinalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaInsert : ContentPage
	{
        ConsultaDetalle consultaDetalle = new ConsultaDetalle();
        ConsultaPost consultaPost = new ConsultaPost();
        List<ConsultaDetalle> lista = new List<ConsultaDetalle>();

        public ConsultaInsert (Paciente paciente)
		{
			InitializeComponent ();

            lblNombre.Text = paciente.Nombre;
            lblApellido.Text = paciente.Apellido;
            lblId.Text = paciente.idPaciente.ToString();
            lblEdad.Text = CalcularEdad(paciente.FechaNacimiento);
        }

        static string CalcularEdad(DateTime Dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("Edad: {0} Año(s) {1} Mes(es)",Years, Months);
        }

        private void BtnInsert_Clicked(object sender, EventArgs e)
        {
            consultaDetalle.Diagnostico = txtDiagnostico.Text;
            consultaDetalle.Estado = txtEstado.Text;
            consultaDetalle.Tratamiento = txtTratamiento.Text;

            lista.Add(consultaDetalle);

            consultaPost.idPaciente = Convert.ToInt32(lblId.Text);
            consultaPost.Altura = txtAltura.Text;
            consultaPost.Peso = txtPeso.Text;
            consultaPost.Detalle = lista;
            consultaPost.idUsuario = 1;
            consultaPost.idPuesto = 1;
            consultaPost.Edad = lblEdad.Text;

            InsertarConsulta();
        }

        public async void InsertarConsulta()
        {
            HttpClient cliente = new HttpClient();
            var uri = new Uri("https://webapinutricion.azurewebsites.net/api/Consultas");

            var json = JsonConvert.SerializeObject(consultaPost);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await cliente.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Paciente", "Consulta Ingresada Con Exito", "Aceptar");
                Debug.WriteLine(@"Ingresado.");
            }
            await Navigation.PushModalAsync(new NavigationPage(new Menu()));
        }
    }
}