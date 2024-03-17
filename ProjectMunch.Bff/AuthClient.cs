using ProjectMunch.DTO.Authentication;

namespace ProjectMunch.Bff
{
    public class AuthClient(HttpClient client)
    {
        private readonly HttpClient _client = client;

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
    }
}
