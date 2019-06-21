using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        private async void BtnConsulta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PacienteConsulta());
        }

        private async void BtnSeleccionar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PacienteSelect());
        }

        private async void BtnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PacienteInsert());
        }
    }
}