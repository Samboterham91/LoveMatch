using LoveMatch.Models;
using System.Collections.ObjectModel;

namespace LoveMatch;

public partial class BioSelectionPage : ContentPage
{
    public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();

    private int likedCount = 0;
    private const int maxLikes = 3;

    public BioSelectionPage()
    {
        InitializeComponent();

        // Voeg demo leden toe met profielfoto
        Members.Add(new Member(1, "Sophie", 25, "Vrouw", "Amsterdam", "Loves traveling and coffee", "Travel, Coffee, Music", "https://randomuser.me/api/portraits/women/1.jpg"));
        Members.Add(new Member(2, "Joris", 28, "Man", "Rotterdam", "Tech geek and gamer", "Gaming, Coding, Sci-Fi", "https://randomuser.me/api/portraits/men/2.jpg"));
        Members.Add(new Member(3, "Alex", 22, "Anders", "Utrecht", "Music lover", "Music, Art, Photography", "https://randomuser.me/api/portraits/lego/3.jpg"));
        Members.Add(new Member(4, "Emma", 30, "Vrouw", "Den Haag", "Foodie en yogi", "Cooking, Yoga, Hiking", "https://randomuser.me/api/portraits/women/4.jpg"));
        Members.Add(new Member(5, "Lars", 27, "Man", "Eindhoven", "Sportfanatic", "Football, Running, Fitness", "https://randomuser.me/api/portraits/men/5.jpg"));
        Members.Add(new Member(6, "Nina", 24, "Vrouw", "Groningen", "Bookworm", "Reading, Writing, Coffee", "https://randomuser.me/api/portraits/women/6.jpg"));
        Members.Add(new Member(7, "Tom", 29, "Man", "Maastricht", "Cycling lover", "Cycling, Hiking, Photography", "https://randomuser.me/api/portraits/men/7.jpg"));
        Members.Add(new Member(8, "Lotte", 26, "Vrouw", "Utrecht", "Animal lover", "Pets, Nature, Travel", "https://randomuser.me/api/portraits/women/8.jpg"));
        Members.Add(new Member(9, "Daan", 23, "Man", "Arnhem", "Gamer", "Gaming, Music, Movies", "https://randomuser.me/api/portraits/men/9.jpg"));

        this.BindingContext = this;
    }

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

            // Button tekst wordt automatisch geupdate via converter
        }
    }

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