namespace atelier2.Models.Help
{
    public class Item
    {
        public int quantite { get; set; }
        private int _ProduitId;
        public Product _product = null;

        public Product Prod
        {
            get { return _product; }
            set { _product = value; }
        }

        public string Description
        {
            get { return _product.Name; }
        }

        public decimal UnitPrice  
        {
            get { return (decimal)_product.Price; }
        }

        public int categoryId
        {
            get { return _product.CategoryId; }
        }

        public Category category
        {
            get { return _product.Category; }
        }

        public decimal TotalPrice  
        {
            get { return (decimal)(_product.Price * quantite); }
        }

        public Item(Product p)
        {
            this.Prod = p;
        }

        public bool Equals(Item item)
        {
            return item.Prod.ProductId == this.Prod.ProductId;
        }
    }
}