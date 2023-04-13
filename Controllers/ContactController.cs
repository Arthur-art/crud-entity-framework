using CrudEntityFramework.Context;
using CrudEntityFramework.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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


    }
}
