using System.Collections.Generic;

namespace JiangH
{
    public interface IBusiness : IEntity, GMInterface
    {
        IBranch branch { get; }

        //IEnumerable<IProduct> MakeProduct();

        IEnumerable<IProduct> products { get; }

        IEnumerable<(string desc, double value)> efficientDetail { get; }
    }
}
