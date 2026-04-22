using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakFastFoodsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public BreakFastFoodsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id == 0)
            {
                var firstFive = await _context.BreakFastFoods
                    .Take(5)
                    .ToListAsync();

                return Ok(firstFive);
            }
            var item = await _context.BreakFastFoods.FindAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BreakFastFoods food)
        {
            _context.BreakFastFoods.Add(food);
            await _context.SaveChangesAsync();

            return Ok(food);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BreakFastFoods updatedFood)
            {
            var existing = await _context.BreakFastFoods.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.FoodName = updatedFood.FoodName;
            existing.Category = updatedFood.Category;
            existing.Calories = updatedFood.Calories;
            existing.IsHealthy = updatedFood.IsHealthy;
            existing.PreparationTime = updatedFood.PreparationTime;

            await _context.SaveChangesAsync();

            return Ok(existing);
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.BreakFastFoods.FindAsync(id);

            if (item == null) 
                return NotFound();

            _context.BreakFastFoods.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
