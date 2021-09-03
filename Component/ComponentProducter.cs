using System;

namespace JiangH
{
    public class ComponentProducter : IComponent
    {
        public IProduct pdt;

        public ComponentProducter()
        {
            pdt = new Product(ProductType.Money, 100);
        }
    }

    internal class Product : IProduct
    {
        public ProductType type { get; private set; }

        public double value { get; private set; }

        public Product(ProductType type, double value)
        {
            this.type = type;
            this.value = value;
        }

    }
}