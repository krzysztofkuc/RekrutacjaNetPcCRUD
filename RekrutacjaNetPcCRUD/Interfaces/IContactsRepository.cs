using RekrutacjaNetPcCRUD.Model.ViewModel;

namespace RekrutacjaNetPcCRUD.Interfaces
{
    public interface IContactsRepository
    {
        Task<IEnumerable<ContactVm>> GetAllContactsAsync();
        Task<ContactVm> GetContactDetailsAsync();
        Task<bool> AddContactAsync();
        Task<bool> UpdateContactAsync();
        Task<bool> DeleteContactAsync();
    }
}
