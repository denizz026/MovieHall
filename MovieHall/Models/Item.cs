namespace MovieHall.Models
{
    public class Item
    {
        public int Id { get; set; } // Ürün ID'si
        public string Name { get; set; } // Ürün adı
        public decimal Price { get; set; } // Ürün fiyatı
        public int Quantity { get; set; } // Ürün miktarı
        public string Image { get; set; } // Ürün resim URL'si

        // Toplam tutarı hesaplayan bir özellik
        public decimal Total => Price * Quantity;


    }

    public class CartViewModel
    {
        public List<Item> Items { get; set; } // Sepetteki ürünler

        // Toplam fiyatı hesaplayan bir özellik
        public decimal TotalAmount => Items != null ? Items.Sum(item => item.Total) : 0;
    }
}

