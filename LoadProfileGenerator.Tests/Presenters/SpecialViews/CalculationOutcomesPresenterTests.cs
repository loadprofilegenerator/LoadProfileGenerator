﻿using System.Threading;
using Automation;
using Common;
using Common.Tests;
using Database;
using Database.Tables.ModularHouseholds;
using Database.Tests;
using JetBrains.Annotations;
using LoadProfileGenerator.Presenters.SpecialViews;
using NUnit.Framework;
using Xunit;
using Xunit.Abstractions;

namespace LoadProfileGenerator.Tests.Presenters.SpecialViews
{
    [TestFixture]
    public class CalculationOutcomesPresenterTests : UnitTestBaseClass
    {
        [Fact]
        [Apartment(ApartmentState.STA)]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]

        public void StartCalcOutcomesChart()
        {
            using (DatabaseSetup db = new DatabaseSetup(Utili.GetCurrentMethodAndClass()))
            {
                Simulator sim = new Simulator(db.ConnectionString);
                CalculationOutcomesPresenter.MakeVersionComparisonChart(sim);
                db.Cleanup();
            }
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.LongTest3)]
        public void StartOneCalculationTest()
        {
            using (DatabaseSetup db = new DatabaseSetup(Utili.GetCurrentMethodAndClass()))
            {
                using (WorkingDir wd = new WorkingDir(Utili.GetCurrentMethodAndClass()))
                {
                    Simulator sim = new Simulator(db.ConnectionString);
                    ModularHousehold hh = sim.ModularHouseholds.It[0];
                    // Guid g = Guid.NewGuid();
                    CalculationOutcomesPresenter.StartOneCalculation(hh, sim.GeographicLocations[0], sim.TemperatureProfiles[0],
                        EnergyIntensityType.EnergySaving, wd.WorkingDirectory, sim,
                        false, null, null, null);
                    db.Cleanup();
                    wd.CleanUp();
                }
            }
        }

        public CalculationOutcomesPresenterTests([NotNull] ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}