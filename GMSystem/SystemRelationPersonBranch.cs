using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class SystemRelationPersonBranch
    {
        private RelationManager relationManager;

        public SystemRelationPersonBranch(RelationManager relationManager)
        {
            this.relationManager = relationManager;
        }

        public void SetRelation(IPerson person, IBranch branch)
        {
            if(person == null)
            {
                throw new Exception();
            }

            if (person.branch != null && person.branch.owner != person)
            {
                throw new Exception();
            }

            if (branch.owner != null && branch.owner.branch != branch)
            {
                throw new Exception();
            }

            if (person.branch == branch)
            {
                return;
            }

            var oldRelation = person.GetRelations<Relation_Person_Branch>().SingleOrDefault();
            if(oldRelation != null)
            {
                relationManager.RemoveRelation(oldRelation);

                person.RemoveComponents<ComponentPdtRecv>();
            }
            
            if (branch != null)
            {
                var newRelation = new Relation_Person_Branch(person, branch);
                relationManager.AddRelation(newRelation);

                person.AddComponent(new ComponentPdtRecv(branch));
            }

        }
    }
}
