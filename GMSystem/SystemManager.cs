using System;
using System.Collections.Generic;

namespace JiangH
{
    public class SystemManager
    {
        public SystemProductProcess productProcess;

        public SystemRelationPersonBranch relationPersonBranch;

        public SystemRelationBranchBusiness relationBranchBusiness;

        public SystemManager()
        {

        }

        public void OnDaysInc((int y, int m, int d) dateValue)
        {
            productProcess.OnDaysInc(dateValue);
        }

        public void Build(IDictionary<Type, List<IEntity>> com2Entitys, RelationManager relationManager)
        {
            productProcess = new SystemProductProcess(com2Entitys[typeof(ComponentProducter)]);

            relationPersonBranch = new SystemRelationPersonBranch(relationManager);
            relationBranchBusiness = new SystemRelationBranchBusiness(relationManager);
        }
    }
}