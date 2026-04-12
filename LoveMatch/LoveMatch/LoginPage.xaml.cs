using LoveMatch.Data;
using LoveMatch.Views;

namespace LoveMatch;

public partial class LoginPage : ContentPage
{
    private readonly Database _db;
    private readonly IServiceProvider? _services;

    public LoginPage(Database db, IServiceProvider? services = null)
    {
        InitializeComponent();
        _db = db;
        _services = services;
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

        var services = _services ?? Application.Current?.Handler?.MauiContext?.Services;
        if (services is null)
        {
            await DisplayAlert("Fout", "Services zijn niet beschikbaar. Start de app opnieuw.", "OK");
            return;
        }

        var createProfilePage = services.GetRequiredService<CreateProfilePage>();
        Application.Current!.MainPage = new NavigationPage(createProfilePage);
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_db));
    }
}
