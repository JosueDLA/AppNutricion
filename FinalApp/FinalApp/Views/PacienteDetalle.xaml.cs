using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PacienteDetalle : ContentPage
	{
        public PacienteDetalle(Paciente paciente)
        {
            InitializeComponent();

            lblNombre.Text = paciente.Nombre;
            lblApellido.Text = paciente.Apellido;
            lblDpi.Text = paciente.DPI;
            lblFecha.Text = (paciente.FechaNacimiento).ToString();
            lblTelefono.Text = paciente.Telefono;

            List<Consulta> consultas = paciente.Consulta;
            lstConsultas.ItemsSource = consultas;

        }

        public async void OnConsultaSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var paciente = new Paciente();
            paciente.Nombre = lblNombre.Text;
            paciente.Apellido = lblApellido.Text;
            var consulta = args.SelectedItem as Consulta;
            //await DisplayAlert("Alert", consulta.Peso, "OK");
           await Navigation.PushAsync(new ConsultaDetallec(consulta, paciente));
        }
    }
}