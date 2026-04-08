using LoveMatch.Data;

namespace LoveMatch;

public partial class LoginPage : ContentPage
{
    private readonly Database _db;
    public LoginPage(Database db)
    {
        InitializeComponent();
        _db = db;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";

        if (username == "" || password == "")
        {
            await DisplayAlert("Fout", "vul naam en wachtwoord in.", "Ok");
            return;
        }

        bool ok = await _db.Login(username, password);

        if (!ok)
        {
            await DisplayAlert("Fout", "inlgogen mislukt.", "Ok");
            return;
        }

        Application.Current!.MainPage = new NavigationPage(new BioSelectionPage(_db));
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_db));
    }
}
