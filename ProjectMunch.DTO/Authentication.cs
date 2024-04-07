namespace ProjectMunch.DTO.AuthenticationApi
{
    public record LoginRequestDto(string UserName, string Password);

    public record LoginResponseDto(string AccessToken, string RefreshToken);

    public record RefreshResponseDto(string AccessToken, string RefreshToken);

    public record RegisterRequestDto(string UserName, string Email, string Password);
}
