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
                if (DeviceInfo.DeviceType == DeviceType.Virtual)
                {
                    // Android emulator
                    baseUrl = "http://10.0.2.2:5000";
                }
                else
                {
                    // Echte telefoon (via WiFi zelfde netwerk zoals Hotspot) --> IPv4-adres wlan adapter van de laptop gebruiken
                    baseUrl = "http://10.99.148.205:5000";
                }
            }
            else
            {
                // Windows / andere platforms
                baseUrl = "http://localhost:5000";
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }
        
        public async Task<bool> CreateProfile(ProfileCreateDto profile) // Hier wordt CreateProfilePage geinjecteerd en de methode doet een POST request naar de API om een nieuw profiel aan te maken.
        {
            var response = await _httpClient.PostAsJsonAsync("/api/profiles", profile);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error creëren profiel: {response.StatusCode} - {errorContent}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ProfileReadDto>> GetProfiles() // Een GET request naar de API om alle profielen op te halen en retourneert een lijst van ProfileReadDto's.
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProfileReadDto>>("/api/profiles");
            return result ?? new List<ProfileReadDto>();
        }
    }
}
