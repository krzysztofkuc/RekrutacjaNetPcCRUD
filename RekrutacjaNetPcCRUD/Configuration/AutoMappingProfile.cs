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

            CreateMap<ContactVm, Contacts>();
            CreateMap<Contacts, ContactVm >();

            CreateMap<ContactCategoryVm, ContactCategory>();
            CreateMap<ContactCategory, ContactCategoryVm>();

            CreateMap<ContactVm, AddContactVm>();
            CreateMap<AddContactVm, ContactVm>();

            CreateMap<ContactSubcategoryVm, ContactSubcategory>();
            CreateMap<ContactSubcategory, ContactSubcategoryVm>();
        }
    }
}
