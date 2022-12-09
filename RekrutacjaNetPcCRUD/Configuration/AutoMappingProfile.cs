using AutoMapper;
using RekrutacjaNetPcCRUD.Model.Entities;
using RekrutacjaNetPcCRUD.Model.ViewModel;

namespace RekrutacjaNetPcCRUD.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Users, UserVm>();
            CreateMap<UserVm, Users>();
        }
    }
}
