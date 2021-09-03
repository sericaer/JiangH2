using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH
{
    public interface IProduct
    {
        ProductType type { get; }
        double value { get; }
    }

    public enum ProductType
    {
        Money
    }
}
