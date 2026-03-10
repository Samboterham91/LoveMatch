using Microsoft.EntityFrameworkCore;
using ProfileApi.Data;
using ProfileApi.Models;

namespace ProfileApi.Services
{
    public class ProfileService(ProfileDb db)
    {
        private readonly ProfileDb _db = db;

        // CREATE
        public async Task CreateProfile(Profile profile)
        {
            _db.Profiles.Add(profile);
            await _db.SaveChangesAsync();
        }

        // READ (All)
        public async Task<List<Profile>> GetProfiles() => await _db.Profiles.ToListAsync();

        // READ (Single)
        public async Task<Profile?> GetProfileById(int id) => await _db.Profiles.FindAsync(id);

        // UPDATE
        public async Task UpdateProfile(Profile updatedProfile)
        {
            _db.Profiles.Update(updatedProfile);
            await _db.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteProfile(int id)
        {
            var profile = await _db.Profiles.FindAsync(id);
            if (profile != null)
            {
                _db.Profiles.Remove(profile);
                await _db.SaveChangesAsync();
            }
        }
    }
}
















//using ProfileApi.Models;
//using Microsoft.EntityFrameworkCore;
//using ProfileApi.Data;



//namespace ProfileApi.Services
//{
//    public class ProfileService(ProfileDb db)
//    {
//        private readonly ProfileDb _db = db;

//        public async Task CreateProfile(Profile profile)
//        {
//            _db.Profiles.Add(profile);
//            await _db.SaveChangesAsync();
//        }

//        public List<Profile> GetProfiles() => _db.Profiles.ToList();
//    }
//}









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