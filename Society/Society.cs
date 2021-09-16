using System;
using System.Linq;
using System.Collections.Generic;

namespace JiangH
{
    public class Society : Entity, ISociety
    {
        public string name { get; private set; }

        public IEnumerable<IBranch> branches
        {
            get
            {
                return GetRelations<Relation_Branch_Society>().Select(x => x.branch);
            }
        }

        public IEnumerable<IPerson> persons
        {
            get
            {
                return branches.SelectMany(x => x.persons);
            }
        }

        public IEnumerable<IBusiness> businesses
        {
            get
            {
                return branches.SelectMany(x => x.businesses);
            }
        }

        public static Society Create(string name)
        {
            return new Society(name);
        }

        public Society(string name)
        {
            this.name = name;
        }
    }
}
