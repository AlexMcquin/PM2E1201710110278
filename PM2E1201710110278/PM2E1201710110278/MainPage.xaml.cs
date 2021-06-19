using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PM2E1201710110278.Models;

namespace PM2E1201710110278
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {

            Int32 resultado = 0;
            var data = new Data()
            {
                longitud = Convert.ToDouble(this.txtLongitud.Text),                
                descripcionCorta = this.txtShortDescripcion.Text,
                latitud = Convert.ToDouble(this.txtLatitud.Text),
                descripcion = this.txtDescripcion.Text

            };


            if (String.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                DisplayAlert("¡Enhorabuena!", "Los campos deben estar llenos", "Entendido");

            }
            else if (String.IsNullOrWhiteSpace(txtShortDescripcion.Text))
            {
                DisplayAlert("¡Enhorabuena!", "Los campos deben estar llenos", "Entendido");

            }
            else if (String.IsNullOrWhiteSpace(txtLatitud.Text))
            {
                DisplayAlert("¡Enhorabuena!", "Los campos deben estar llenos", "Entendido");

            }
            else if (String.IsNullOrWhiteSpace(txtLongitud.Text))
            {
                DisplayAlert("¡Enhorabuena!", "Los campos deben estar llenos", "Entendido");

            }


            else
            {

                using (SQLiteConnection conexion = new SQLiteConnection(App.ubicacionDB))
                {
                    conexion.CreateTable<Data>();

                    resultado = conexion.Insert(data);

                    if (resultado > 0)
                        DisplayAlert("¡Éxito!", "Datos cargados satisfactoriamente", "¡Lo Tengo!");
                    else
                        DisplayAlert("¡UPS!", "Error ar cargar la información", "Ok");
                }

            }
        }

        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Locaciones());
        }
    }
}
