using System.ComponentModel.DataAnnotations;

namespace ProjectMunch.DTO.PointOfInterestsApi
{
    public record AddRequestDto(
        [Required] [Range(-90, 90)] short Longitude,
        [Required] [Range(-180, 180)] short Latitude,
        [Required] string Name,
        string? Description
    );

    public record GetByIdResponseDto { }

    public record GetPublicPoiRequestDto(
        [Required] [Range(-90, 90)] short Longitude,
        [Required] [Range(-180, 180)] short Latitude,
        [Required] int Distance
    );
}
