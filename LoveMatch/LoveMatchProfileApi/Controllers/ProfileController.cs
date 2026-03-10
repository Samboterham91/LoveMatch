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
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            var profiles = await _profileService.GetProfiles();
            return Ok(profiles);
        }

        [HttpPost]
        public ActionResult<Profile> CreateProfile(Profile profile)
        {
            return Ok(_profileService.CreateProfile(profile));
        }

        // UPDATE: api/profiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest("ID in URL does not match with ID in the body.");
            }

            var existingProfile = await _profileService.GetProfileById(id);
            if (existingProfile == null)
            {
                return NotFound($"Profile with ID {id} was not found.");
            }

            await _profileService.UpdateProfile(profile);
            return NoContent(); // HTTP 204: Succes, but returns no content
        }

        // DELETE: api/profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _profileService.GetProfileById(id);
            if (profile == null)
            {
                return NotFound($"Profiel met ID {id} bestaat niet.");
            }

            await _profileService.DeleteProfile(id);
            return NoContent(); // HTTP 204
        }
    }
}