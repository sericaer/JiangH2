using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class Business : Entity, IBusiness
    {
        public static Business Create()
        {
            return new Business();
        }

        public Business()
        {
            AddComponent(new ComponentProducter());
        }

        public IBranch branch
        {
            get
            {
                var relation = GetRelations<Relation_Branch_Business>().SingleOrDefault();
                return relation != null ? relation.branch : null;
            }
        }

        public IEnumerable<(string desc, double value)> efficientDetail
        {
            get
            {
                return GetComponents<ComponentEfficentProduct>().Select(x=>(x.desc, x.value));
            }
        }

        public IEnumerable<IProduct> products
        {
            get
            {
                return GetComponents<ComponentProducter>().Select(x => x.pdt);
            }
        }

        public IEnumerable<IProductInfo> MakeProduct()
        {
            foreach(var pdt in products)
            {
                pdt
            }
        }
    }
}