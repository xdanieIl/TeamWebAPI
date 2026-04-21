using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TeamMembersController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.TeamMembers.Take(5).ToListAsync();
            }

            var member = await _context.TeamMembers.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember member)
        {
            _context.TeamMembers.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeamMembers), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(int id, TeamMember member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}