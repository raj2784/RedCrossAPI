using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedCrossAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedCrossAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly AppDbContext db;

        public VolunteerController(AppDbContext context)
        {
            db = context;
        }
        // GET: api/<Volunteer>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetVolunteers()
        {
            return await db.Volunteers.ToListAsync();
        }

        // GET api/<Volunteer>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Volunteer>> GetVolunteer(int Id)
        {
            var volunteer = await db.Volunteers.FindAsync(Id);
            if (volunteer != null)
            {
                return volunteer;
            }
            return NotFound();
        }

        // POST api/<Volunteer>
        [HttpPost]
        public async Task<ActionResult<Volunteer>> PostVolunteer(Volunteer model)
        {
            db.Volunteers.Add(model);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetVolunteer", new { Id = model.Id }, model);
        }

        // PUT api/<Volunteer>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVolunteer(int Id, Volunteer model)
        {
            model.Id = Id;

            db.Entry(model).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return NoContent();
        }

        // DELETE api/<Volunteer>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Volunteer>> DeleteVolunteer(int Id)
        {
            var volunteer = await db.Volunteers.FindAsync(Id);
            if (volunteer == null)
            {
                return NotFound();
            }
            db.Volunteers.Remove(volunteer);
            await db.SaveChangesAsync();

            return volunteer;
        }

        private bool VolunteerExists(int Id)
        {
            return db.Volunteers.Any(v => v.Id == Id);
        }
    }
}
