using RekrutacjaNetPcCRUD.Model.ViewModel;

namespace RekrutacjaNetPcCRUD.Interfaces
{
    public interface IContactsRepository
    {
        Task<IEnumerable<ContactVm>> GetAllContactsAsync();
        Task<ContactVm> GetContactDetailsAsync();
        Task<ContactVm> AddContactAsync(ContactVm contact);
        Task<bool> UpdateContactAsync();
        Task<bool> DeleteContactAsync();
        Task<IEnumerable<ContactCategoryVm>> GetAllContactCategories();
        Task<ContactSubcategoryVm> Addsubcategory(ContactSubcategoryVm subcategory);
    }
}
