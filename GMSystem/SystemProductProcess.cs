using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class SystemProductProcess
    {
        private IEnumerable<IEntity> entitys;

        public SystemProductProcess(IEnumerable<IEntity> entitys)
        {
            this.entitys = entitys;
        }

        internal void OnDaysInc((int y, int m, int d) dateValue)
        {
            foreach(var entity in entitys)
            {
                var comRecv = entity.GetComponents<ComponentPdtRecv>().SingleOrDefault();
                if(comRecv == null)
                {
                    continue;
                }

                foreach (var producter in entity.GetComponents<ComponentProducter>())
                {
                    var comStorage = comRecv.recv.GetComponents<ComponentPdtStorage>().SingleOrDefault(x=>x.product.type == producter.pdt.type);
                    if(comStorage == null)
                    {
                        comStorage = new ComponentPdtStorage(producter.pdt.type);
                        comRecv.recv.AddComponent(comStorage);
                    }

                    comStorage.product.value += producter.pdt.value * producter.efficent / 100;
                }
            }
        }
    }
}