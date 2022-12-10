﻿namespace RekrutacjaNetPcCRUD.Model.ViewModel
{
    public class AddContactVm
    {
        public string Name { get; set; }
        public string Surnane { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<ContactCategoryVm> Categories { get; set; }
        public string PhoneNo { get; set; }
        public string DateOfBirth { get; set; }
    }
}
