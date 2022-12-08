using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RekrutacjaNetPcCRUD.Interfaces;
using RekrutacjaNetPcCRUD.Model.ViewModel;
using RekrutacjaNetPcCRUD.Repositories;

namespace RekrutacjaNetPcCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsRepository _repo;
        private readonly ContactsDbContext _contactsCtx;


        public ContactsController(ILogger<ContactsController> logger, IContactsRepository repo, ContactsDbContext contactsCtx)
        {
            _logger = logger;
            _repo = repo;
            _contactsCtx = contactsCtx;
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public async Task<IEnumerable<ContactVm>> GetAllContacts()
        {
            return await _repo.GetAllContactsAsync();
        }
    }
}
