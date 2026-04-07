using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveMatch.Models;
using System.Net.Http.Json;

namespace LoveMatch.Services
{
       public class ApiService
    {
        private HttpClient _httpClient;

        public ApiService()
        {
            string baseUrl;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                // Android-emulator kan de host bereiken via 10.0.2.2
                baseUrl = "http://10.0.2.2:5000";
            }
            else
            {
                // Windows of andere platforms
                baseUrl = "http://localhost:5000";
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<bool> CreateProfile(ProfileCreateDto profile)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Profiles", profile);
            return response.IsSuccessStatusCode;
        }
    }
}
