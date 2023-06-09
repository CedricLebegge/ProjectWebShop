﻿using Microsoft.AspNetCore.Mvc;
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

        // GETALL: api/Stock
        [HttpGet]
        public IActionResult GetAllStockItems()
        {
            List<StockItem> stockItems = db.Stock.ToList();
            return Ok(stockItems);
        }

        // GET: api/Stock/{serialNumber}
        [HttpGet]
        [Route("{serialNumber}")]
        public IActionResult GetStockItem(int serialNumber)
        {
            var stockItem = db.Stock.FirstOrDefault(s => s.Id == serialNumber);
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

            // Generate a random serial number
            var random = new Random();
            stockItem.Id = random.Next(100000, 999999);

            db.Stock.Add(stockItem);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = stockItem.Id }, stockItem);
        }

        // PUT: api/Stock/{serialNumber}
        [HttpPut]
        [Route("{serialNumber}")]
        public IActionResult PutStockItem(int serialNumber, StockItem stockItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStockItem = db.Stock.FirstOrDefault(s => s.Id == serialNumber);
            if (existingStockItem == null)
            {
                return NotFound();
            }

            existingStockItem.Name = stockItem.Name;
            existingStockItem.Image = stockItem.Image;
            existingStockItem.Price = stockItem.Price;
            existingStockItem.Metal = stockItem.Metal;
            existingStockItem.Purity = stockItem.Purity;
            existingStockItem.Weight = stockItem.Weight;
            existingStockItem.Amount = stockItem.Amount;

            db.Entry(existingStockItem).State = EntityState.Modified;
            db.SaveChanges();

            return NoContent();
        }
    }
}
