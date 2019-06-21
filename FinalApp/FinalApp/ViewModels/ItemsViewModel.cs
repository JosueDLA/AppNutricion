using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;

using FinalApp.Models;
using FinalApp.Views;
using System.Collections.Generic;

namespace FinalApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<PacienteInsert, Paciente>(this, "AddItem", async (obj, paciente) =>
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
                    Debug.WriteLine(@"Ingresado.");
                }
                //Items.Add(newItem);
                //await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            List<Paciente> pacientes;

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
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}