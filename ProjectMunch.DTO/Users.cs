namespace ProjectMunch.DTO.UsersApi
{
    public record GetPrincipalUserResponseDto(string UserName, IEnumerable<string> Roles);

    public record GetUserResponseDto(string UserName);
}
