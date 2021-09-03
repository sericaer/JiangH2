using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace JiangH
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            RunData runData = new RunData();
            runData.date.Run();

            runData.persons.First().AddComponent(new ComponentProducter());

            runData.date.Run();
        }
    }
}
