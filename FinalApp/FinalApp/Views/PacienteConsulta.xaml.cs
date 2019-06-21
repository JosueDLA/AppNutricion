using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalApp.ViewModels;
using FinalApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PacienteConsulta : ContentPage
	{
		public PacienteConsulta ()
		{
			InitializeComponent ();
            LoadPaciente();
		}

        public async void LoadPaciente()
        {
            PacienteAD test = new PacienteAD();
            Task<List<Paciente>> lista = test.SelectPacienteAsync();
            List<Paciente> pacientes = await lista;
            lstPacientes.ItemsSource = pacientes;
        }

        public async void OnPacienteSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var paciente = args.SelectedItem as Paciente;
            await Navigation.PushAsync(new ConsultaInsert(paciente));
        }
    }
}