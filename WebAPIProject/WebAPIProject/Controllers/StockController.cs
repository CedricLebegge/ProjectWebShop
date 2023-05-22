using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
using WebAPIProject.Data;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    public class StockController : ApiController
    {
        private StockDbContext db = new StockDbContext();

        // GET: api/Stock/{serialNumber}
        [HttpGet]
        [Route("{serialNumber}")]
        public IHttpActionResult GetStockItem(string serialNumber)
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
        public IHttpActionResult PostStockItem(StockItem stockItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Stock.Add(stockItem);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = stockItem.Id }, stockItem);
        }

        // PUT: api/Stock/{id}
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult PutStockItem(int id, StockItem stockItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != stockItem.Id)
            {
                return BadRequest();
            }
            db.Entry(stockItem).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
