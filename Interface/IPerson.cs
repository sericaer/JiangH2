using System;
using System.Collections.Generic;

namespace JiangH
{
    public interface IPerson : IEntity, GMInterface
    {
        PersonDef def { get; }

        string fullName { get; }

        int maxBusinessCount { get; }

        //int maxGuidanceCount { get; }

        //int maxLearningCount { get; }

        //int maxSubsidiaryCount { get; }

        //IBranch branch { get; }

        ISociety society { get; }

        IEnumerable<IBusiness> businesses { get; }

        double CalcBusinessEfficent();


    }

    public class PersonDef
    {
        public IEnumerable<IPersonInteractive> interactives { get; set; }
    }

    public interface IPersonInteractive
    {
        IPerson initiator { get; }
        IPerson recipient { get; }

        string name { get; }
        
        InteractiveUI ui { get; }

        Func<object, bool> isTrigger { get; }

        Action<object> Do { get; }

        void Init(IPerson initiator, IPerson recipient);

    }

    public interface InteractiveUI
    {
        string title { get; }
        string desc { get; }

        object dataSource { get; set; }

        Action<object> Do { get; }
    }
}
