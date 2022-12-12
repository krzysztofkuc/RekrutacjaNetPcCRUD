using RekrutacjaNetPcCRUD.Model.ViewModel;

namespace RekrutacjaNetPcCRUD.Interfaces
{
    public interface IContactsRepository
    {
        IEnumerable<ContactVm> GetAllContacts();
        Task<ContactVm> GetContactDetailsAsync();
        Task<ContactVm> AddContactAsync(AddContactVm addContact);
        Task<bool> UpdateContactAsync();
        Task<bool> DeleteContactAsync();
        Task<IEnumerable<ContactCategoryVm>> GetAllContactCategories();
        Task<ContactSubcategoryVm> Addsubcategory(ContactSubcategoryVm subcategory);
    }
}
