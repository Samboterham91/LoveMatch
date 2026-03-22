namespace LoveMatch.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";
        public string Location { get; set; } = "";
        public string Bio { get; set; } = "";
        public string Interests { get; set; } = "";
        public string ProfilePictureUrl { get; set; } = "";

        // Voor bio selectie
        public bool IsLiked { get; set; } = false;

        // Default constructor
        public Member() { }

        // Optionele constructor voor demo
        public Member(int id, string name, int age, string gender, string location, string bio, string interests, string profilePictureUrl)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Location = location;
            Bio = bio;
            Interests = interests;
            ProfilePictureUrl = profilePictureUrl;
        }
    }
}