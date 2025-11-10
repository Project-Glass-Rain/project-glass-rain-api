using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GlassRain.Domain.Catalog;
using GlassRain.Data;

namespace GlassRain.Api.Controllers
{
    [ApiController]
    [Route("catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;
        public CatalogController(StoreContext db)
        {
            _db = db;
        }


        // GET /catalog
        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt",  "Ohio State shirt.",  "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };

            return Ok(_db.Items);
        }

        // GET /catalog/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_db.Items.Find(id));
        }

        // POST /catalog
        [HttpPost]
        public IActionResult Post(Item item)
        {
            // Simulate creation; database wiring comes later.
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        // POST /catalog/{id}/ratings
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);
            return Ok(_db.Items);
        }

        // PUT /catalog/{id}
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Item item)
        {
            // Simulate update; normally you'd persist changes.
            item.Id = id;
            return Ok(_db.Items);
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