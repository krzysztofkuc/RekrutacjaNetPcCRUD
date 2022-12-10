using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RekrutacjaNetPcCRUD.Interfaces;
using RekrutacjaNetPcCRUD.Model.ViewModel;
using RekrutacjaNetPcCRUD.Repositories;
using RekrutacjaNetPcCRUD.Repositories.ContactsDbContext;

namespace RekrutacjaNetPcCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsRepository _repo;


        public ContactsController(ILogger<ContactsController> logger, IContactsRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public async Task<IEnumerable<ContactVm>> GetAllContacts()
        {
            return await _repo.GetAllContactsAsync();
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<AddContactVm> AddContact()
        {
            var addVm = new AddContactVm()
            {
                Categories = await _repo.GetAllContactCategories()
            };

            return addVm;
        }

        [HttpGet]
        [Route("GetAllContactCategories")]
        public async Task<IEnumerable<ContactCategoryVm>> GetAllContactCategories()
        {
            return await _repo.GetAllContactCategories();
        }
    }
}
