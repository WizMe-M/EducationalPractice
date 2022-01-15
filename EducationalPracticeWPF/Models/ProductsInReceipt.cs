using System;
using System.Collections.Generic;

#nullable disable

namespace EducationalPracticeWPF
{
    public partial class ProductsInReceipt
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public int ProductCount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
