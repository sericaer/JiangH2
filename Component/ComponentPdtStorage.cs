using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH
{
    public class ComponentPdtStorage : IComponent
    {
        public readonly ProductType type;
        public double value;

        public ComponentPdtStorage(ProductType type)
        {
            this.type = type;
        }
    }
}
