using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveMatch.Data;

namespace LoveMatch.Views
{
    public partial class CreateProfilePage : ContentPage
    {
        private readonly Database _db;

        public CreateProfilePage(Database db)
        {
            InitializeComponent();
            _db = db;
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

            // Validatie leeftijd
            if (!int.TryParse(AgeEntry.Text, out int age))
            {
                await DisplayAlert("Fout", "Voer een geldige leeftijd in", "OK");
                return;
            }

            var success = await _db.UpdateCurrentMemberProfile(name, age, bio);

            if (success)
            {
                await DisplayAlert("Succes", "Profiel bijgewerkt!", "OK");
                await Navigation.PushAsync(new BioSelectionPage(_db));
            }
            else
            {
                await DisplayAlert("Fout", "Profiel opslaan mislukt. Log opnieuw in en probeer het nog eens.", "OK");
            }
        }
    }
}

