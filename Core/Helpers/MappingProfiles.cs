using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;


namespace Core.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, Student>()
                .ForMember(dst => dst.SchoolNumber, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, StudentAffairs>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));
           
            CreateMap<User, Teacher>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
