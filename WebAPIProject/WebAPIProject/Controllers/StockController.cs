using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebAPIProject.Data;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private StockDbContext db = new StockDbContext();

        // GET: api/Stock/{serialNumber}
        [HttpGet]
        [Route("{serialNumber}")]
        public IActionResult GetStockItem(int serialNumber)
        {
            var stockItem = db.Stock.FirstOrDefault(s => s.SerialNumber == serialNumber);
            if (stockItem == null)
            {
                return NotFound();
            }
            return Ok(stockItem);
        }

        // POST: api/Stock
        [HttpPost]
        [Route("")]
        public IActionResult PostStockItem(StockItem stockItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Stock.Add(stockItem);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = stockItem.SerialNumber }, stockItem);
        }

        // PUT: api/Stock/{id}
        [HttpPut]
        [Route("{id}")]
        public IActionResult PutStockItem(int id, StockItem stockItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != stockItem.SerialNumber)
            {
                return BadRequest();
            }
            db.Entry(stockItem).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
