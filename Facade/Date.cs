using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH
{
    class Date : IDate
    {
        public Action OnDaysInc { get; set; }

        public void Run()
        {
            OnDaysInc?.Invoke();
        }
    }
}
