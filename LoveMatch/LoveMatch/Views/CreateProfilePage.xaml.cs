using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveMatch.Models;
using LoveMatch.Services;

namespace LoveMatch.Views
{
    public partial class CreateProfilePage : ContentPage
    {
        private ApiService _apiService = new ApiService();

        public CreateProfilePage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Validatie leeftijd
            if (!int.TryParse(AgeEntry.Text, out int age))
            {
                await DisplayAlert("Fout", "Voer een geldige leeftijd in", "OK");
                return;
            }

            var profile = new ProfileCreateDto
            {
                Name = NameEntry.Text,
                Age = age,
                Bio = BioEditor.Text
            };

            var success = await _apiService.CreateProfile(profile);

            if (success)
            {
                await DisplayAlert("Succes", "Profiel aangemaakt!", "OK");

                // Navigeren naar lijstpagina
                await Navigation.PushAsync(new ProfileListPage());
            }
            else
            {
                await DisplayAlert("Fout", "Er ging iets mis", "OK");
            }
        }
    }
}

