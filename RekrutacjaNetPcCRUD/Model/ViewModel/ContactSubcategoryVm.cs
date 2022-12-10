using RekrutacjaNetPcCRUD.Model.Entities;

namespace RekrutacjaNetPcCRUD.Model.ViewModel
{
    public class ContactSubcategoryVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public ContactCategoryVm Category { get; set; }
    }
}
