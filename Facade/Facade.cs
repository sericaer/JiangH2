﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH
{
    public class Facade
    {
        public static RunData runData { get; private set; }

        public static IPerson player { get; private set; }

        public static IEnumerable<IBranch> branchs { get; private set; }

        public static IEnumerable<IPerson> persons { get; private set; }

        public static IDate date { get; private set; }

        public static SystemManager system { get; private set; }

        public static void BuildRunData()
        {
            runData = new RunData();

            persons = runData.persons;

            date = runData.date;

            system = runData.systemMgr;

            branchs = runData.branches;

            player = persons.First();
        }
    }
}
