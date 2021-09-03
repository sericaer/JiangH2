using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class SystemRelationBranchBusiness
    {
        private RelationManager relationManager;

        public SystemRelationBranchBusiness(RelationManager relationManager)
        {
            this.relationManager = relationManager;
        }

        public void SetRelation(IBranch branch, IBusiness business)
        {
            if (business == null)
            {
                throw new Exception();
            }

            if (business.branch != null && !business.branch.businesses.Any(x=>x==business))
            {
                throw new Exception();
            }

            if (branch != null)
            {
                foreach(var subbusiness in branch.businesses)
                {
                    if(subbusiness.branch != branch)
                    {
                        throw new Exception();
                    }
                }
            }

            if (business.branch == branch)
            {
                return;
            }

            var relation = business.GetRelations<Relation_Branch_Business>().SingleOrDefault();
            if (relation != null)
            {
                relationManager.RemoveRelation(relation);

                business.RemoveComponents<ComponentPdtRecv>();
            }

            if(branch != null)
            {
                var newRelation = new Relation_Branch_Business(branch, business);
                relationManager.AddRelation(newRelation);

                business.AddComponent(new ComponentPdtRecv(branch));
            }

        }
    }
}
