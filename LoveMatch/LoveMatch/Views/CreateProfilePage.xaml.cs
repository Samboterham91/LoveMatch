using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveMatch.Models;
using LoveMatch.Services;
using LoveMatch.Views;

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
            var profile = new ProfileCreateDto
            {
                Name = NameEntry.Text,
                Age = int.Parse(AgeEntry.Text),
                Bio = BioEditor.Text
            };

            var success = await _apiService.CreateProfile(profile);

            if (success)
            {
                await DisplayAlert("Succes", "Profiel aangemaakt!", "OK");
            }
            else
            {
                await DisplayAlert("Fout", "Er ging iets mis", "OK");
            }
        }
    }
}

