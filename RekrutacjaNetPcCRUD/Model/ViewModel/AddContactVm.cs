namespace RekrutacjaNetPcCRUD.Model.ViewModel
{
    public class ContactVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public ContactCategoryVm Category { get; set; }
        public string PhoneNo { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
