using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveMatch.Models;
using LoveMatch.Services;

namespace LoveMatch.Views
{
    public partial class ProfileListPage : ContentPage
    {
        private readonly ApiService _apiService;
        private int selectedCount = 0;

        public ProfileListPage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadProfiles();
        }

        private async Task LoadProfiles()
        {
            var profiles = await _apiService.GetProfiles();
            ProfilesCollection.ItemsSource = profiles;

            if (profiles.Count == 0)
            {
                await DisplayAlert("Info", "Geen profielen gevonden of API is niet bereikbaar.", "OK");
            }
        }

        private async void OnSelectClicked(object sender, EventArgs e)
        {
            if (selectedCount >= 3)
            {
                await DisplayAlert("Limiet", "Je mag max 3 profielen kiezen", "OK");
                return;
            }

            selectedCount++;

            await DisplayAlert("Geselecteerd", $"Je hebt nu {selectedCount} gekozen", "OK");
        }
    }
}
