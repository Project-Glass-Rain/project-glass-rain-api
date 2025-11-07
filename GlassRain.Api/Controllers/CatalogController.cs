using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GlassRain.Domain.Catalog;

namespace GlassRain.Api.Controllers
{
    [ApiController]
    [Route("catalog")]
    public class CatalogController : ControllerBase
    {
        // GET /catalog
        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt",  "Ohio State shirt.",  "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };

            return Ok(items);
        }

        // GET /catalog/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            return Ok(item);
        }

        // POST /catalog
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            // Simulate creation; database wiring comes later.
            return Created("/catalog/42", item);
        }

        // POST /catalog/{id}/ratings
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);
            return Ok(item);
        }

        // PUT /catalog/{id}
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Item item)
        {
            // Simulate update; normally you'd persist changes.
            item.Id = id;
            return Ok(item);
        }

        // DELETE /catalog/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // Simulate deletion; return 204 No Content.
            return NoContent();
        }
    }
}