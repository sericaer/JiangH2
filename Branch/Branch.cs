using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class Branch : Entity, IBranch
    {
        public IPerson owner
        {
            get
            {
                var relation = GetRelations<Relation_Person_Branch>().SingleOrDefault();
                return relation != null ? relation.person : null;
            }
        }

        public IEnumerable<IBusiness> businesses
        {
            get
            {
                return GetRelations<Relation_Branch_Business>().Select(x => x.business); 
            }
        }

        
        public IEnumerable<IProduct> products
        {
            get
            {
                return GetComponents<ComponentPdtStorage>().Select(x => x.product);
            }
        }

        public IProduct money
        {
            get
            {
                return products.SingleOrDefault(x => x.type == ProductType.Money);
            }
        }

        public static Branch Create()
        {
            return new Branch();
        }
    }
}
