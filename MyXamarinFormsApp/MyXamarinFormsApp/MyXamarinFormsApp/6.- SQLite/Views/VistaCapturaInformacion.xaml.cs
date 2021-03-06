﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
namespace MyXamarinFormsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaCapturaInformacion : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public VistaCapturaInformacion()
        {
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
            InitializeComponent();
            PickerGenero.Items.Add("Masculino");
            PickerGenero.Items.Add("Femenino");
        }
        private void btn_guardar(object sender, EventArgs e)
        {
            string GeneroValue = PickerGenero.Items[PickerGenero.SelectedIndex];
            var datos = new Tabla_Informacion { Nombre = NombreEntry.Text , Genero = GeneroValue };
            try
            {
                _conn.InsertAsync(datos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btn_CambiarPagina(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaConsultaInformacion());
        }
    }
}