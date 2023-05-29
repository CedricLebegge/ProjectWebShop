using System.ComponentModel.DataAnnotations;

namespace WebAPIProject.Models
{
    public class StockItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public Metal Metal { get; set; }

        public decimal Purity { get; set; }

        public decimal Weight { get; set; }

        public int Amount { get; set; }
    }
}
