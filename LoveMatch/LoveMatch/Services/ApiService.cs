using System.Net.Http.Json;
using LoveMatch.Models;

namespace LoveMatch.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(GetBaseUrl())
            };
        }

        private string GetBaseUrl()
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                return DeviceInfo.DeviceType == DeviceType.Virtual
                    ? "http://10.0.2.2:5000"
                    : "http://10.99.148.205:5000";
            }

            return "http://localhost:5000";
        }

        public async Task<bool> CreateProfile(ProfileCreateDto profile)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/profiles", profile);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CreateProfile error: {response.StatusCode} - {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateProfile exception: {ex.Message}");
                return false;
            }
        }

        public async Task<List<ProfileReadDto>> GetProfiles()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProfileReadDto>>("api/profiles")
                       ?? new List<ProfileReadDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetProfiles exception: {ex.Message}");
                return new List<ProfileReadDto>();
            }
        }
    }
}