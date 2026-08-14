using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AdvancedAddressBook.Models;
using AdvancedAddressBook.Services;

namespace AdvancedAddressBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly AddressBookService _service;

        public ContactsController(AddressBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            return Ok(_service.GetAllContacts());
        }

        [HttpGet("{firstName}")]
        public ActionResult<Contact> GetContact(string firstName)
        {
            var contact = _service.SearchContact(firstName);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            try
            {
                _service.AddContact(contact);
                return CreatedAtAction(nameof(GetContact), new { firstName = contact.FirstName }, contact);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{firstName}")]
        public ActionResult DeleteContact(string firstName)
        {
            var contact = _service.SearchContact(firstName);
            if (contact == null)
            {
                return NotFound();
            }

            _service.DeleteContact(firstName);
            return NoContent();
        }
    }
}
