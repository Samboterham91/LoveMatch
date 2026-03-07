using Microsoft.AspNetCore.Mvc;
using ProfileApi.Models;
using ProfileApi.Services;

namespace ProfileApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController(ProfileService profileService) : ControllerBase
    {
        private readonly ProfileService _profileService = profileService;

        [HttpGet]
        public ActionResult<List<Profile>> GetProfiles()
        {
            return _profileService.GetProfiles();
        }

        [HttpPost]
        public ActionResult<Profile> CreateProfile(Profile profile)
        {
            return Ok(_profileService.CreateProfile(profile));
        }
    }
}