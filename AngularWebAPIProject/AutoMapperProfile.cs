using AngularWebAPIProject.DAL;
using AngularWebAPIProject.Model;
using AutoMapper;

namespace AngularWebAPIProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, ApplicationUser>().ReverseMap();
            CreateMap<RecordOpeningModel, RecordOpening>().ReverseMap();
            CreateMap<BuyersModel, Buyers>().ReverseMap();
            CreateMap<RoleModel, RoleMaster>().ReverseMap();
        }
    }
}
