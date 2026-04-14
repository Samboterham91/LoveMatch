using LoveMatch.Data;

namespace LoveMatch;

public partial class RegisterPage : ContentPage
{
    private readonly Database _db;
    public RegisterPage(Database db)
    {
        InitializeComponent();
        _db = db;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";

        if (username == "" || password == "")
        {
            await DisplayAlert("Fout", "Vul gebruikersnaam en wachtwoord in.", "Ok");
            return;
        }

        bool ok = await _db.Register(username, password);

        if (!ok)
        {
            await DisplayAlert("Fout", "Gebruikersnaam bestaat al.", "Ok");
            return;
        }

        await DisplayAlert("Gelukt", "Account is aangemaakt.", "Ok");
        await Navigation.PopAsync();
    }

    private async void OnBackToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
