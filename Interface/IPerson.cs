﻿namespace JiangH
{
    public interface IPerson : IEntity, GMInterface
    {
        string fullName { get; }

        int maxBusinessCount { get; }

        //int maxGuidanceCount { get; }

        //int maxLearningCount { get; }

        //int maxSubsidiaryCount { get; }

        IBranch branch { get; }

        ISociety society { get; }

        double CalcBusinessEfficent();
    }
}
