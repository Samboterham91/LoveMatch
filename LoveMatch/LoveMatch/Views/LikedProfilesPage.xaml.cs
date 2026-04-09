using LoveMatch.Models;
using System.Collections.ObjectModel;

namespace LoveMatch;

public partial class LikedProfilesPage : ContentPage
{
    public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();

    public LikedProfilesPage(List<Member> likedMembers)
    {
        InitializeComponent();

        foreach (var member in likedMembers)
        {
            Members.Add(member);
        }

        BindingContext = this;
    }
}