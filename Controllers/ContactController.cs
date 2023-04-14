using CrudEntityFramework.Context;
using CrudEntityFramework.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudEntityFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ContactController : ControllerBase
    {
        private readonly NoteBookContext _context;

        public ContactController(NoteBookContext context)
        {
            _context = context;
        }

        [HttpPost("create-contact")]
        public ActionResult CreateContact(Contact contact) 
        {
            _context.Add(contact);
            _context.SaveChanges();

            var message = new
            {
                Contact = contact,
                Created = DateTime.Now,
            };
            return Ok(message);        
        }

        [HttpGet("GetContact/{id}")]
        public ActionResult GetContact(int id) 
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return NotFound();  
            }

            return Ok(new
            {
                Contact = contact,
            });
        }

        [HttpPost("UpdateContact/{id}")]
        public ActionResult UpdateContact(int id, Contact contact) 
        {
            var contactFind = _context.Contacts.Find(id);

            if(contactFind == null) { 
                return NotFound();
            }

            contactFind.Name = contact.Name;
            contactFind.Number = contact.Number;
            contactFind.Active = contact.Active;

            _context.Contacts.Update(contactFind);
            _context.SaveChanges();

            return Ok(new
            {
                Contact = contact,
            });
        }

        [HttpDelete("DeleteContact/{id}")]
        public ActionResult DeleteContact(int id) 
        {
            var contact = _context.Contacts.Find(id);
            if(contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return Ok(new
            {
                ContactDelete = contact,
            });
        }

        [HttpGet("GetContacts")]
        public ActionResult GetContacts()
        {
            var contacts = _context.Contacts;

            return Ok(contacts);
        }

        [HttpGet("ContactName/{name}")]
        public ActionResult GetContactName(string name)
        {
            var contactName = _context.Contacts.Where(x => x.Name == name);
            if(contactName == null )
            {
                return NotFound();
            }

            return Ok(contactName);
        }

    }
}
