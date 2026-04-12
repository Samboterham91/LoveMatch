using LoveMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LoveMatch.Data;
using LoveMatch.Services;
using LoveMatch.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace LoveMatch.Controllers
{

    [ApiController]
    [Route("api/profiles")]
    public class ProfileLocationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly LocationService _locationService;

        public ProfileLocationController(AppDbContext context, LocationService locationService)
        {
            _context = context;
            _locationService = locationService;
        }
        
        

        [HttpPost("{id}/location")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] ProfileLocationDto dto)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null) return NotFound();

            var city = await _locationService.GetCityAsync(dto.Latitude, dto.Longitude);

            profile.Latitude = Math.Round(dto.Latitude, 2);
            profile.Longitude = Math.Round(dto.Longitude, 2);
            profile.City = city;

            await _context.SaveChangesAsync();

            return Ok(profile);
        }
        
        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearbyUsers(double lat, double lon, double radiusKm = 25)
        {
            var profile = await _context.Profiles.ToListAsync();

            var nearbyProfiles = profile
                .Select(u => new
                {
                    User = u,
                    Distance = DistanceHelper.CalculateDistance(lat, lon, u.Latitude, u.Longitude)
                })
                .Where(x => x.Distance <= radiusKm)
                .Select(x => new
                {
                    x.User.Id,
                    x.User.Name,
                    x.User.City,
                    Distance = Math.Round(x.Distance, 1)
                });

            return Ok(nearbyProfiles);
        }
    }
}
