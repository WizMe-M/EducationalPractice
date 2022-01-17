namespace EducationalPracticeWPF.Models
{
    public class ProductsInReceipt
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public int ProductCount { get; set; }

        public Product Product { get; set; }
        public Receipt Receipt { get; set; }
    }
}