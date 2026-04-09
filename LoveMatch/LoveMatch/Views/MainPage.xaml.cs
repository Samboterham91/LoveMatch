using LoveMatch.Models;
using System.Collections.ObjectModel;

namespace LoveMatch;

// Project van Sam
public partial class MainPage : ContentPage
{
    // ObservableCollection voor MAUI binding
    public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();

    private int likedCount = 0;
    private const int maxLikes = 3;

    public MainPage()
    {
        InitializeComponent();

        // Demo Members toevoegen (8 parameters inclusief Id en profielfoto)
        Members.Add(new Member { Id = 1, Name = "Sophie", Age = 25, Gender = "Vrouw", Location = "Amsterdam", Bio = "Loves traveling and coffee", Interests = "Travel, Coffee, Music", ProfilePictureUrl = "https://randomuser.me/api/portraits/women/1.jpg" });
        Members.Add(new Member { Id = 2, Name = "Joris", Age = 28, Gender = "Man", Location = "Rotterdam", Bio = "Tech geek and gamer", Interests = "Gaming, Coding, Sci-Fi", ProfilePictureUrl = "https://randomuser.me/api/portraits/men/2.jpg" });
        Members.Add(new Member { Id = 3, Name = "Alex", Age = 22, Gender = "Anders", Location = "Utrecht", Bio = "Music lover", Interests = "Music, Art, Photography", ProfilePictureUrl = "https://randomuser.me/api/portraits/lego/3.jpg" });
        Members.Add(new Member { Id = 4, Name = "Emma", Age = 30, Gender = "Vrouw", Location = "Den Haag", Bio = "Foodie en yogi", Interests = "Cooking, Yoga, Hiking", ProfilePictureUrl = "https://randomuser.me/api/portraits/women/4.jpg" });
        Members.Add(new Member { Id = 5, Name = "Lars", Age = 27, Gender = "Man", Location = "Eindhoven", Bio = "Sportfanatic", Interests = "Football, Running, Fitness", ProfilePictureUrl = "https://randomuser.me/api/portraits/men/5.jpg" });
        Members.Add(new Member { Id = 6, Name = "Nina", Age = 24, Gender = "Vrouw", Location = "Groningen", Bio = "Bookworm", Interests = "Reading, Writing, Coffee", ProfilePictureUrl = "https://randomuser.me/api/portraits/women/6.jpg" });
        Members.Add(new Member { Id = 7, Name = "Tom", Age = 29, Gender = "Man", Location = "Maastricht", Bio = "Cycling lover", Interests = "Cycling, Hiking, Photography", ProfilePictureUrl = "https://randomuser.me/api/portraits/men/7.jpg" });
        Members.Add(new Member { Id = 8, Name = "Lotte", Age = 26, Gender = "Vrouw", Location = "Utrecht", Bio = "Animal lover", Interests = "Pets, Nature, Travel", ProfilePictureUrl = "https://randomuser.me/api/portraits/women/8.jpg" });
        Members.Add(new Member { Id = 9, Name = "Daan", Age = 23, Gender = "Man", Location = "Arnhem", Bio = "Gamer", Interests = "Gaming, Music, Movies", ProfilePictureUrl = "https://randomuser.me/api/portraits/men/9.jpg" });

        // Bind de lijst aan de UI
        BindingContext = this;
    }

    // Like-knop click handler
    private void OnLikeButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Member member)
        {
            if (!member.IsLiked && likedCount >= maxLikes)
            {
                DisplayAlert("Max bereikt", "Je mag maximaal 3 leden liken.", "Ok");
                return;
            }

            member.IsLiked = !member.IsLiked;
            likedCount += member.IsLiked ? 1 : -1;

            // Button text wordt automatisch geupdate via converter
        }
    }

    // Navigeren naar LikedProfilesPage
    private async void OnViewProfilesClicked(object sender, EventArgs e)
    {
        var likedMembers = Members.Where(m => m.IsLiked).ToList();

        if (likedMembers.Count == 0)
        {
            await DisplayAlert("Geen leden geselecteerd", "Je hebt nog geen leden geliked.", "Ok");
            return;
        }

        await Navigation.PushAsync(new LikedProfilesPage(likedMembers));
    }
}