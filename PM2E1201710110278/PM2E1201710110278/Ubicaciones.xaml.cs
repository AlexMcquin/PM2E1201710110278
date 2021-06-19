using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using PM2E1201710110278.Models;

namespace PM2E1201710110278
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Locaciones : ContentPage
    {
        public Locaciones()
        {
            InitializeComponent();
        }


        Data itemLocacion = new Data();

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conexion = new SQLiteConnection(App.ubicacionDB);
            conexion.CreateTable<Data>();
            var ubicacion = conexion.Table<Data>().ToList();
            ListaUbicaciones.ItemsSource = ubicacion;
            conexion.Close();
        }

        private void listviewSelect(object sender, ItemTappedEventArgs e)
        {
            itemLocacion = (Data)e.Item;


        }
        private async void botonBorrar(object sender, EventArgs e)
        {
            SQLiteConnection conexion = new SQLiteConnection(App.ubicacionDB);
            conexion.Table<Data>().Delete(x => x.id == itemLocacion.id);


            conexion.CreateTable<Data>();
            var ubicacion = conexion.Table<Data>().ToList();
            ListaUbicaciones.ItemsSource = ubicacion;
            conexion.Close();
        }


        private async void btnMapsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
}