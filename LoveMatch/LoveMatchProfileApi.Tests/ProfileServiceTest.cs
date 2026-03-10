using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileApi.Controllers;
using ProfileApi.Data;
using ProfileApi.Models;
using ProfileApi.Services;
using Xunit;

namespace ProfileApi.Tests
{
    public class ProfileServiceTests
    {
        private static ProfileDb GetDbContext()
        {
            // Maak een unieke database naam voor elke test
            var options = new DbContextOptionsBuilder<ProfileDb>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ProfileDb(options);
        }

        [Fact]
        public async Task CreateProfile_AddsProfileToDatabase_MatchesEquivalent()
        {
            // Arrange
            using var db = GetDbContext();
            var service = new ProfileService(db);
            var profile = new Profile
            {
                FirstName = "Piet",
                LastName = "Hein",
                Height = 178,
                Gender = Profile.Genders.Male,
                EyeColor = "Blue",
                DateOfBirth = new DateOnly(1956, 8, 29),
                BioText = "Some text here"
            };

            // Act
            await service.CreateProfile(profile);

            var profiles = service.GetProfiles();

            // Assert
            var actualProfile = Assert.Single(await profiles);

            // Assert.Equivalent kijkt naar de waarden van de velden.
            // Tip: Als de Id dwarsligt, kun je de vergelijking forceren:
            Assert.Equivalent(profile, actualProfile);
        }
    }
}







































//[Fact]
//        public void CreateProfile_AddsProfileToList()
//        {
//            // Arrange
//            var service = new ProfileService();

//            var profile = new Profile
//            {
//                FirstName = "Piet",
//                LastName = "Hein",
//                Height = 178,
//                Gender = Profile.Genders.Male,
//                DateOfBirth = new DateOnly(1990, 4, 25),
//                EyeColor = "Blauw"
//            };

//            // Act
//            service.CreateProfile(profile);

//            var profiles = service.GetProfiles();
//            var actualProfile = Assert.Single(profiles);

//            // Assert
//            Assert.Equivalent(profile, actualProfile);

//            //Assert.Contains(profiles, p => p.FirstName == "Piet" && p.LastName == "Hein");
//        }
//    }
//}