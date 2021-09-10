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
                var rslt = GetComponents<ComponentEfficentProduct>().Select(x => (x.desc, x.value));
                return branch == null ? rslt : rslt.Concat(branch.GetComponents<ComponentBusinessEfficentProduct>().Select(x => (x.desc, x.value)));
            }
        }

        public IEnumerable<IProduct> products
        {
            get
            {
                return GetComponents<ComponentProducter>().Select(x => x.pdt);
            }
        }

        //public IEnumerable<IProduct> MakeProduct()
        //{
        //    return products.Select(x => new Product(x.type, x.value * (1.0 + efficientDetail.Sum(e => e.value) / 100)));
        //}
    }
}