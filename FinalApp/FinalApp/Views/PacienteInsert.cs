using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalApp.Models;
using Xamarin.Forms;
using FinalApp.Services;
using FinalApp.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FinalApp.Views
{
	public class PacienteInsert : ContentPage
	{
        private Entry txtNombre;
        private Entry txtApellido;
        private Entry txtDpi;
        private Entry txtTelefono;
        private Button btnInsert;

        private DatePicker txtFechaN;

        Paciente paciente = new Paciente();

        public PacienteInsert()
        {
            StackLayout layout = new StackLayout();
            Title = "Insertar Paciente";
            

            txtNombre = new Entry();
            txtNombre.Keyboard = Keyboard.Text;
            txtNombre.Placeholder = "Nombre";

            txtApellido = new Entry();
            txtApellido.Keyboard = Keyboard.Text;
            txtApellido.Placeholder = "Apellido";

            txtFechaN = new DatePicker();
            txtFechaN.MinimumDate = new DateTime(1900, 1, 1);
            txtFechaN.MaximumDate = new DateTime(2019, 1, 1);

            txtDpi = new Entry();
            txtDpi.Keyboard = Keyboard.Text;
            txtDpi.Placeholder = "DPI";

            txtTelefono = new Entry();
            txtTelefono.Keyboard = Keyboard.Text;
            txtTelefono.Placeholder = "Telefono";

            btnInsert = new Button();
            btnInsert.Text = "Insertar";
            btnInsert.Clicked += BtnInsert_Clicked;

            layout.Children.Add(txtNombre);
            layout.Children.Add(txtApellido);
            layout.Children.Add(txtFechaN);
            layout.Children.Add(txtDpi);
            layout.Children.Add(txtTelefono);
            layout.Children.Add(btnInsert);

            Content = layout;

        }

        private void BtnInsert_Clicked(object sender, EventArgs e)
        {
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            paciente.FechaNacimiento = txtFechaN.Date;
            paciente.DPI = txtDpi.Text;
            paciente.Telefono = txtTelefono.Text;

            InsertarPaciente();
        }

        public async void InsertarPaciente()
        {
            HttpClient cliente = new HttpClient();
            var newItem = paciente as Paciente;
            var uri = new Uri("https://webapinutricion.azurewebsites.net/api/Pacientes");

            var json = JsonConvert.SerializeObject(paciente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await cliente.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Paciente", "Paciente Ingresado Con Exito", "Aceptar");
                Debug.WriteLine(@"Ingresado.");
            }
            await Navigation.PushModalAsync(new NavigationPage(new Menu()));
        }
    }
}