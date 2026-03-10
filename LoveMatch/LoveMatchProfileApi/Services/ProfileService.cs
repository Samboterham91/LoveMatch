using ProfileApi.Models;
using Microsoft.EntityFrameworkCore;
using ProfileApi.Data;



namespace ProfileApi.Services
{
    public class ProfileService(ProfileDb db)
    {
        private readonly ProfileDb _db = db;

        public async Task CreateProfile(Profile profile)
        {
            _db.Profiles.Add(profile);
            await _db.SaveChangesAsync();
        }

        public List<Profile> GetProfiles() => _db.Profiles.ToList();
    }
}









//        private static readonly List<Profile> profiles = [];

//        public List<Profile> GetProfiles()
//        {
//            return profiles;
//        }

//        public Profile CreateProfile(Profile profile)
//        {
//            profiles.Add(profile);
//            return profile;
//        }
//    }
//}