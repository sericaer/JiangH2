using System.Collections.Generic;

namespace JiangH
{
    public interface IBranch : IEntity, GMInterface
    {
        IPerson owner { get; }
        IEnumerable<IBusiness> businesses { get; }
    }
}
