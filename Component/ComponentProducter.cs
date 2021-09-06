using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class ComponentProducter : IComponent
    {
        public IProduct pdt;

        public double efficent => 100 + efficentDetail.Values.Sum(x => x.value);

        public Dictionary<string, (string desc, double value)> efficentDetail;

        public ComponentProducter()
        {
            pdt = new Product(ProductType.Money, 100);
            efficentDetail = new Dictionary<string, (string desc, double value)>();
        }
    }

    public class Product : IProduct
    {
        public ProductType type { get; private set; }

        public double value { get; set; }

        public Product(ProductType type, double value)
        {
            this.type = type;
            this.value = value;
        }
    }
}