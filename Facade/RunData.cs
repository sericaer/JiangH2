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
        public IEnumerable<ISociety> societies => entityMgr.GetEntitysByInterface<ISociety>();


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

            entityMgr.AddEntity(Branch.Create("987"));
            entityMgr.AddEntity(Branch.Create("123"));

            entityMgr.AddEntity(Society.Create("$$$"));
            entityMgr.AddEntity(Society.Create("@@@"));

            systemMgr.Build(entityMgr.itf2Entitys, relationMgr);

            Entity.funcGetRelations = relationMgr.GetRelationsByEntity;

            systemMgr.relationPersonBranch.AddRelation(persons.First(), branches.First());

            systemMgr.relationBranchBusiness.AddRelation(branches.First(), businesses.First());
            systemMgr.relationBranchBusiness.AddRelation(branches.First(), businesses.Last());

            systemMgr.relationBranchSociety.AddRelation(branches.First(), societies.First());

            date.OnDaysInc = ((int y, int m, int d)dateValue) =>
            {
                systemMgr.branchProductProcess.OnDaysInc(dateValue);
            };
        }
    }
}
