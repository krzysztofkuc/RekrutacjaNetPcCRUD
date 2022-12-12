using AutoMapper;
using RekrutacjaNetPcCRUD.Interfaces;
using RekrutacjaNetPcCRUD.Model.Entities;
using RekrutacjaNetPcCRUD.Model.ViewModel;
using System.Data.Entity;

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

        public IEnumerable<ContactVm> GetAllContacts()
        {
            var cots = _contactsCtx.Contacts.Include(x => x.Category).ToList();
            //_contactsCtx.Entry(cots).Reference(x => x.cate).Load();

            var xx = _mapper.Map<IEnumerable<ContactVm>>(cots);
            return xx;
        }

        public async Task<ContactVm> AddContactAsync(AddContactVm addContact)
        {
            var contact = _mapper.Map<Contacts>(addContact);
            contact.Category = null;
            var contactEntity = await _contactsCtx.AddAsync(contact);
            _contactsCtx.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _contactsCtx.SaveChangesAsync();

            return _mapper.Map<ContactVm>(contactEntity.Entity);
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
