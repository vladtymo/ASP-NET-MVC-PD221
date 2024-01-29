namespace BusinessLogic.Models
{
    public class EditProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}
