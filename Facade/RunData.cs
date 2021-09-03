using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class RunData
    {
        public EntityManager entityMgr;

        public SystemManager systemMgr;

        public RelationManager relationMgr;

        public IEnumerable<IPerson> persons => entityMgr.GetEntitysByInterface<IPerson>();
        public IEnumerable<IBusiness> businesses => entityMgr.GetEntitysByInterface<IBusiness>();
        public IEnumerable<IBranch> branches => entityMgr.GetEntitysByInterface<IBranch>();

        public IDate date;

        public RunData()
        {
            entityMgr = new EntityManager();
            systemMgr = new SystemManager();
            relationMgr = new RelationManager();

            date = new Date();

            entityMgr.AddEntity(Person.Create());
            entityMgr.AddEntity(Business.Create());
            entityMgr.AddEntity(Business.Create());
            entityMgr.AddEntity(Branch.Create());

            systemMgr.Build(entityMgr.com2Entitys, relationMgr);


            Entity.funcGetRelations = relationMgr.GetRelationsByEntity;

            systemMgr.relationPersonBranch.SetRelation(persons.First(), branches.First());
            systemMgr.relationBranchBusiness.SetRelation(branches.First(), businesses.First());
            systemMgr.relationBranchBusiness.SetRelation(branches.First(), businesses.Last());

            date.OnDaysInc = () =>
            {
                systemMgr.OnDaysInc();
            };
        }
    }
}
