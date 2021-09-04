using System;
using System.Linq;

namespace JiangH
{
    public class Person : Entity, IPerson
    {
        public IBranch branch
        {
            get
            {
                var relation = GetRelations<Relation_Person_Branch>().SingleOrDefault();
                return relation != null ? relation.branch : null;
            }
        }

        public string fullName { get; set; }
        public int maxBusinessCount { get; private set; }

        //public int maxGuidanceCount { get; private set; }

        //public int maxLearningCount { get; private set; }

        //public int maxSubsidiaryCount { get; private set; }

        public Person()
        {
            fullName = "AAA";

            maxBusinessCount = 3;
            //maxGuidanceCount = 5;
            //maxLearningCount = 1;
            //maxSubsidiaryCount = 5;
        }

        public static Person Create()
        {
            return new Person();
        }
    }
}