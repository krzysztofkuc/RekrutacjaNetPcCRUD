namespace RekrutacjaNetPcCRUD.Model.ViewModel
{
    public class AddContactVm : ContactVm
    {
        public IEnumerable<ContactCategoryVm> Categories { get; set; }
    }
}
