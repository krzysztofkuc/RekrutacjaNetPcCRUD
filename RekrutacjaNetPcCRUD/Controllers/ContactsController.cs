using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RekrutacjaNetPcCRUD.Interfaces;
using RekrutacjaNetPcCRUD.Model.ViewModel;

namespace RekrutacjaNetPcCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsRepository _repo;


        public ContactsController(ILogger<ContactsController> logger, IContactsRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllContacts")]
        public IEnumerable<ContactVm> GetAllContacts()
        {
            return _repo.GetAllContacts();
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<ContactVm> AddContactAsync(AddContactVm contactAdd)
        {

            return await _repo.AddContactAsync(contactAdd);
        }

        [HttpGet]
        [Route("GetAllContactCategories")]
        public async Task<IEnumerable<ContactCategoryVm>> GetAllContactCategories()
        {
            return await _repo.GetAllContactCategories();
        }

        [HttpPost]
        [Route("AddSubcategory")]
        public async Task<ContactSubcategoryVm> AddSubcategory([FromBody] ContactSubcategoryVm subcategory)
        {
            return await _repo.Addsubcategory(subcategory);
        }
    }
}
