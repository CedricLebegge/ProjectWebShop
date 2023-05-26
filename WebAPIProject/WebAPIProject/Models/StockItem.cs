using System.ComponentModel.DataAnnotations;

namespace WebAPIProject.Models
{
    public class StockItem
    {
        [Key]
        public int SerialNumber { get; set; }
        public int Amount { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
