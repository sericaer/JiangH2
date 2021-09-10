using System.Collections.Generic;

namespace JiangH
{
    public interface IBranch : IEntity, GMInterface
    {
        IPerson owner { get; }
        IEnumerable<IBusiness> businesses { get; }

        IEnumerable<IProduct> products { get; }

        //void OnDaysInc((int y, int m, int d) dateValue);
    }
}
