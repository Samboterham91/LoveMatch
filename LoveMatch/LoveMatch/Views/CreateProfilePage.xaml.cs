using Microsoft.Maui.Controls;
using System;
using LoveMatch.Models;
using LoveMatch.Services;

namespace LoveMatch.Views
{
    public partial class CreateProfilePage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public CreateProfilePage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text?.Trim() ?? string.Empty;
            string bio = BioEditor.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(bio))
            {
                await DisplayAlert("Fout", "Naam en bio zijn verplicht.", "OK");
                return;
            }

            if (!int.TryParse(AgeEntry.Text, out int age))
            {
                await DisplayAlert("Fout", "Voer een geldige leeftijd in", "OK");
                return;
            }

            var profile = new ProfileCreateDto
            {
                Name = name,
                Age = age,
                Bio = bio
            };

            try
            {
                var success = await _apiService.CreateProfile(profile);

                if (success)
                {
                    await DisplayAlert("Succes", "Profiel aangemaakt!", "OK");

                    // FIX: ApiService doorgeven
                    await Navigation.PushAsync(new ProfileListPage(_apiService));
                }
                else
                {
                    await DisplayAlert("Fout", "Er ging iets mis bij het aanmaken van het profiel.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fout", $"Server niet bereikbaar: {ex.Message}", "OK");
            }
        }
    }
}