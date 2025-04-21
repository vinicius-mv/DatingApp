using API.DTOs;
using API.Entities;
using Mapster;

namespace API.Helpers;

public class MapsterProfile
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<AppUser, MemberDto>.NewConfig()
            .Map(dest => dest.Age, src => src.GetAge())
            .Map(dest => dest.PhotoUrl, src => src.Photos.FirstOrDefault(x => x.IsMain) != null
                ? src.Photos.FirstOrDefault(x => x.IsMain)!.Url
                : string.Empty);

        TypeAdapterConfig<Photo, PhotoDto>.NewConfig();
    }
}
