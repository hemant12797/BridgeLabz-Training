using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactsApiEF.DataLayer;
using ContactsApiEF.Models;

namespace ContactsApiEF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContactsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
    {
        return await _context.Contacts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetById(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        return contact;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById),
            new { id = contact.Id },
            contact);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Contact contact)
    {
        if (id != contact.Id)
            return BadRequest();

        _context.Entry(contact).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        _context.Contacts.Remove(contact);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}