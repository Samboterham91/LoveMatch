using ProfileApi.Models;

namespace ProfileApi.Services
{
    public class ProfileService
    {
        private static readonly List<Profile> profiles = [];

        public List<Profile> GetProfiles()
        {
            return profiles;
        }

        public Profile CreateProfile(Profile profile)
        {
            profiles.Add(profile);
            return profile;
        }
    }
}