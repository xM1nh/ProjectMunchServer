using ProjectMunch.Bff.Dto;
using ProjectMunch.DTO.AuthenticationApi;

namespace ProjectMunch.Bff
{
    public class ApiClient(HttpClient client, IConfiguration configuration)
    {
        private readonly HttpClient _client = client;
        private readonly IConfiguration _configuration = configuration;

        #region Auth
        public async Task<bool> RegisterAsync(RegisterRequestDto request)
        {
            var response = await _client.PostAsJsonAsync("authentication/register", request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var response = await _client.PostAsJsonAsync("authentication/login", request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var tokens = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

            return tokens;
        }

        public async Task<RefreshResponseDto?> RefreshAsync(string userName, string refreshToken)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {refreshToken}");

            var response = await _client.PostAsJsonAsync("authentication/refresh", userName);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var tokens = await response.Content.ReadFromJsonAsync<RefreshResponseDto>();

            return tokens;
        }

        public async Task<bool> LogoutAsync(string userName, string accessToken)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var response = await _client.PostAsJsonAsync("authentication/logout", userName);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Third Party API
        public async Task<MapBoxGeocodingResponseDto?> GetReverseGeocoding(
            float longitude,
            float latitude
        )
        {
            var accessToken = _configuration["ApiKey:MapBox"];
            ArgumentException.ThrowIfNullOrEmpty(accessToken);

            var response = await _client.GetAsync(
                $"https://api.mapbox.com/geocoding/v5/mapbox.places/{longitude},{latitude}.json?access_token={accessToken}"
            );

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<MapBoxGeocodingResponseDto>();
        }
        #endregion
    }
}
