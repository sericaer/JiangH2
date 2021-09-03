using System;

namespace JiangH
{
    public interface IDate
    {
        Action OnDaysInc { get; set; }

        void Run();
    }
}
