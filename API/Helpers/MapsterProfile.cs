using API.DTOs;
using API.Entities;
using API.Extensions;
using Mapster;

namespace API.Helpers;

public class MapsterProfile
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<AppUser, MemberDto>.NewConfig()
            .Map(dest => dest.Age, src => src.DateOfBirth.CalculateAge())
            .Map(dest => dest.PhotoUrl, src => src.Photos.FirstOrDefault(x => x.IsMain) != null
                ? src.Photos.FirstOrDefault(x => x.IsMain)!.Url
                : string.Empty)
            .CompileProjection();

        TypeAdapterConfig<Photo, PhotoDto>.NewConfig()
            .CompileProjection();
    }
}
