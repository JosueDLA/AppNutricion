using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalApp.ViewModels;
using FinalApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace FinalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaDetallec : ContentPage
	{
		public ConsultaDetallec (Consulta consulta, Paciente paciente)
		{
            InitializeComponent();

            lblNombre.Text = paciente.Nombre;
            lblApellido.Text = paciente.Apellido;

            lblAltura.Text = consulta.Altura;
            lblPeso.Text = consulta.Peso;
            lblEdad.Text = consulta.Edad;
            lblFecha.Text = consulta.Fecha.ToString();
            lblUsuario.Text = consulta.UsuarioNombre;

            foreach (ConsultaDetalle con in consulta.Detalle)
            {
                Debug.Print(con.Diagnostico);
                Debug.Print(con.Tratamiento);
                Debug.Print(con.Estado);
            }

            lstDetalle.ItemsSource = consulta.Detalle;
        }
	}
}