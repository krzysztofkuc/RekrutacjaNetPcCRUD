using RekrutacjaNetPcCRUD.Model.Entities;

namespace RekrutacjaNetPcCRUD.Model.ViewModel
{
    public class ContactCategoryVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Contacts> Contacts { get; set; }
    }
}
