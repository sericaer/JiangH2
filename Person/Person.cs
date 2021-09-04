using System;
using System.Linq;

namespace JiangH
{
    public class Person : Entity, IPerson
    {
        public Person()
        {
            fullName = "AAA";
        }

        public IBranch branch
        {
            get
            {
                var relation = GetRelations<Relation_Person_Branch>().SingleOrDefault();
                return relation != null ? relation.branch : null;
            }
        }

        public string fullName { get; set; }

        public static Person Create()
        {
            return new Person();
        }
    }
}