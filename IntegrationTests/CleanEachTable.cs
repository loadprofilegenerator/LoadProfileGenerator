﻿using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Automation;
using Common;
using Common.Tests;
using Database;
using Database.Database;
using Database.Tables;
using Database.Tests;
using NUnit.Framework;
using Xunit;
using Logger = Common.Logger;

namespace IntegrationTests
{
    [TestFixture]
    public class CleanEachTable
    {
        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.CleanEachTable)]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void TryCleaningEachTable()
        {
            CleanTestBase.RunAutomatically(false);
            using (var db1 = new DatabaseSetup("TryCleaningEach"))
            {
                var alltables = LongtermTests.GetTableList(db1);
                db1.Cleanup();
                for (var index = 0; index < alltables.Count; index++)
                {
                    Logger.Info("processing table " + index + " out of " + alltables.Count);
                    var table = alltables[index];
                    if (table == "tblLPGVersion")
                    {
                        continue;
                    }
                    using (var db = new DatabaseSetup(Utili.GetCurrentMethodAndClass()))
                    {
                        DBBase.HideDeleteMessages();
                        Command.HideDeleteMessages();

                        db.ClearTable(table);
                        var oldSim = new Simulator(db.ConnectionString); // need to load it for testing
                        Logger.Info(oldSim.ModularHouseholds.It.Count.ToString(CultureInfo.InvariantCulture));
                        db.Cleanup();
                    }
                }
            }
            CleanTestBase.RunAutomatically(true);
        }
    }
}
