using Microsoft.AspNetCore.Mvc;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {
        private readonly AppDBContext _context;

        public VideoGameController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int? id)
        {
            if (id == null || id == 0)
            {
                return Ok(_context.VideoGames.Take(5).ToList());
            }

            var game = _context.VideoGames.Find(id);
            if (game == null) return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public IActionResult Post(VideoGame game)
        {
            _context.VideoGames.Add(game);
            _context.SaveChanges();
            return Ok(game);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, VideoGame updatedGame)
        {
            var game = _context.VideoGames.Find(id);
            if (game == null) return NotFound();

            game.Title = updatedGame.Title;
            game.Genre = updatedGame.Genre;
            game.Platform = updatedGame.Platform;
            game.ReleaseYear = updatedGame.ReleaseYear;
            game.Rating = updatedGame.Rating;

            _context.SaveChanges();
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _context.VideoGames.Find(id);
            if (game == null) return NotFound();

            _context.VideoGames.Remove(game);
            _context.SaveChanges();

            return Ok();
        }
    }
}
