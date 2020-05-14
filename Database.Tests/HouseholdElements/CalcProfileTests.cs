﻿using System;
using Automation;
using CalculationEngine.HouseholdElements;
using Common;
using Common.CalcDto;
using Common.Tests;
using JetBrains.Annotations;
using NUnit.Framework;
using Xunit;
using Xunit.Abstractions;
using Assert = NUnit.Framework.Assert;

namespace Database.Tests.HouseholdElements
{
    [TestFixture]
    public class CalcProfileTests : UnitTestBaseClass
    {
        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void CalcProfileTest1MinPro1MinStep()
        {
            TimeSpan stepsize = new TimeSpan(0, 1, 0);
            CalcProfile cp = new CalcProfile("name", Guid.NewGuid().ToStrGuid(), stepsize, ProfileType.Absolute, "made up");
            cp.AddNewTimepoint(new TimeSpan(0, 0, 0), 100);
            cp.AddNewTimepoint(new TimeSpan(0, 1, 0), 100);
            cp.ConvertToTimesteps();
            Assert.AreEqual(100, cp.StepValues[0]);
            Assert.AreEqual(1, cp.StepValues.Count);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void CalcProfileTest2MinPro1MinStep()
        {
            TimeSpan stepsize = new TimeSpan(0, 1, 0);
            CalcProfile cp = new CalcProfile("name", Guid.NewGuid().ToStrGuid(), stepsize, ProfileType.Absolute, "made up");
            cp.AddNewTimepoint(new TimeSpan(0, 0, 0), 100);
            cp.AddNewTimepoint(new TimeSpan(0, 2, 0), 100);
            cp.ConvertToTimesteps();
            Assert.AreEqual(100, cp.StepValues[0]);
            Assert.AreEqual(100, cp.StepValues[0]);
            Assert.AreEqual(2, cp.StepValues.Count);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void CalcProfileTest30SPro1MinStep()
        {
            Config.IsInUnitTesting = true;
            TimeSpan stepsize = new TimeSpan(0, 1, 0);
            CalcProfile cp = new CalcProfile("name", Guid.NewGuid().ToStrGuid(), stepsize, ProfileType.Absolute, "made up");
            cp.AddNewTimepoint(new TimeSpan(0, 0, 0), 100);
            cp.AddNewTimepoint(new TimeSpan(0, 0, 30), 50);
            cp.AddNewTimepoint(new TimeSpan(0, 1, 30), 0);
            cp.ConvertToTimesteps();
            Assert.AreEqual(2, cp.StepValues.Count);
            Assert.AreEqual(75, cp.StepValues[0]);
            Assert.AreEqual(25, cp.StepValues[1]);
        }

        public CalcProfileTests([NotNull] ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}