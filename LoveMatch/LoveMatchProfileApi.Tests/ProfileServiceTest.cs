using Microsoft.AspNetCore.Mvc;
using ProfileApi.Controllers;
using ProfileApi.Models;
using ProfileApi.Services;
using Xunit;

namespace ProfileApi.Tests
{
    public class ProfileServiceTests
    {
        [Fact]
        public void CreateProfile_AddsProfileToList()
        {
            // Arrange
            var service = new ProfileService();

            var profile = new Profile
            {
                FirstName = "John",
                LastName = "Doe",
                Height = 180
            };

            // Act
            service.CreateProfile(profile);

            var profiles = service.GetProfiles();

            // Assert
            Assert.Contains(profiles, p => p.FirstName == "John");
        }
    }
}