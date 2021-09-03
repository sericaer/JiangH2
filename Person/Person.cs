using System;
using System.Linq;

namespace JiangH
{
    public class Person : Entity, IPerson
    {
        public Person()
        {

        }

        public IBranch branch
        {
            get
            {
                var relation = GetRelations<Relation_Person_Branch>().SingleOrDefault();
                return relation != null ? relation.branch : null;
            }
        }

        public static Person Create()
        {
            return new Person();
        }
    }
}