using System;

namespace JiangH
{
    public interface IDate
    {
        Action<(int y, int m, int d)> OnDaysInc { get; set; }

        void Inc();
    }
}
