using AutoMapper;
using RekrutacjaNetPcCRUD.Interfaces;
using RekrutacjaNetPcCRUD.Model.Entities;
using RekrutacjaNetPcCRUD.Model.ViewModel;

namespace RekrutacjaNetPcCRUD.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext.RekrutacjaNetPcCrudContext _contactsCtx;
        IMapper _mapper;

        public ContactsRepository(ContactsDbContext.RekrutacjaNetPcCrudContext contactsCtx, IMapper automapper)
        {
            _contactsCtx = contactsCtx;
            _mapper = automapper;
        }

        public async Task<IEnumerable<ContactVm>> GetAllContactsAsync()
        {
            return Task.FromResult(_mapper.Map<ICollection<ContactVm>>(_contactsCtx.Contacts)).Result;
        }

        public async Task<ContactVm> AddContactAsync(ContactVm contactForm)
        {
            var contact = _mapper.Map<Contacts>(contactForm);
            var contactEntity = await _contactsCtx.AddAsync(contact);
            await _contactsCtx.SaveChangesAsync();

            return _mapper.Map<ContactVm>(contactEntity);
        }

        public async Task<bool> DeleteContactAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ContactVm> GetContactDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateContactAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactCategoryVm>> GetAllContactCategories()
        {
            IEnumerable<ContactCategoryVm>  allCategoriesVm = _mapper.Map<IEnumerable<ContactCategoryVm>>(_contactsCtx.ContactCategory);

            return Task.FromResult(allCategoriesVm).Result;
        }

        public async Task<ContactSubcategoryVm> Addsubcategory(ContactSubcategoryVm subcategoryVm)
        {
            var subcategory = _mapper.Map<ContactSubcategory>(subcategoryVm);
            subcategory.Category = null;
            var subcategoryCtx = await _contactsCtx.ContactSubcategory.AddAsync(subcategory);
            await _contactsCtx.SaveChangesAsync();

            return _mapper.Map<ContactSubcategoryVm>(subcategoryCtx.Entity);
        }
    }
}
