using System.Collections.Generic;

namespace JiangH
{
    public interface IBranch : IEntity, GMInterface
    {
        string name { get; }
        IPerson owner { get; }

        IEnumerable<IBusiness> businesses { get; }

        IEnumerable<IProduct> products { get; }

        //void OnDaysInc((int y, int m, int d) dateValue);
    }
}
