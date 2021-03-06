﻿//-----------------------------------------------------------------------

// <copyright>
//
// Copyright (c) TU Chemnitz, Prof. Technische Thermodynamik
// Written by Noah Pflugradt.
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//  Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the distribution.
//  All advertising materials mentioning features or use of this software must display the following acknowledgement:
//  “This product includes software developed by the TU Chemnitz, Prof. Technische Thermodynamik and its contributors.”
//  Neither the name of the University nor the names of its contributors may be used to endorse or promote products
//  derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE UNIVERSITY 'AS IS' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,
// BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE UNIVERSITY OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, S
// PECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; L
// OSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// </copyright>

//-----------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Automation;
using Common;
using Common.Tests;
using Database.Tables.BasicElements;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;


namespace Database.Tests.Tables {

    [SuppressMessage("ReSharper", "RedundantNameQualifier")]
    public class TemperatureProfileTests : UnitTestBaseClass
    {
        private static void CompareArray([JetBrains.Annotations.NotNull] double[] temparr,[JetBrains.Annotations.NotNull]double[] dstarr) {
            (dstarr.Length).Should().Be(temparr.Length);
            for (var i = 0; i < temparr.Length; i++) {
                Logger.Info(temparr[i] + " -> " + dstarr[i]);
            }

            for (var i = 0; i < temparr.Length; i++) {
                (dstarr[i]).Should().Be(temparr[i]);
            }
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void GetTemperatureArrayTest() {
            // test converting
            var startdate = new DateTime(2014, 1, 1);
            var endDate = new DateTime(2014, 1, 4);
            var stepsize = new TimeSpan(12, 0, 0);
            var temperatureValue = new TemperatureValue(new DateTime(2014, 1, 2), 5, -1, -1, string.Empty, Guid.NewGuid().ToStrGuid());
            var temperatureValue2 = new TemperatureValue(new DateTime(2014, 1, 2, 12, 0, 0), 10, -1, -1,
                string.Empty, Guid.NewGuid().ToStrGuid());
            var tempvalues = new ObservableCollection<TemperatureValue>
            {
                temperatureValue,
                temperatureValue2
            };
            var temparr = TemperatureProfile.GetTemperatureArray(startdate, endDate, stepsize, tempvalues);
            double[] dstarr = {5.0, 5, 5, 10, 10, 10};
            CompareArray(temparr, dstarr);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void GetTemperatureArrayTest2() {
            // test mapping to a different year
            var startdate = new DateTime(2014, 1, 1);
            var endDate = new DateTime(2014, 1, 4);
            var stepsize = new TimeSpan(12, 0, 0);
            var temperatureValue = new TemperatureValue(new DateTime(2012, 1, 2), 5, -1, -1, string.Empty, Guid.NewGuid().ToStrGuid());
            var temperatureValue2 = new TemperatureValue(new DateTime(2012, 1, 2, 12, 0, 0), 10, -1, -1,
                string.Empty, Guid.NewGuid().ToStrGuid());
            var tempvalues = new ObservableCollection<TemperatureValue>
            {
                temperatureValue,
                temperatureValue2
            };
            var temparr = TemperatureProfile.GetTemperatureArray(startdate, endDate, stepsize, tempvalues);
            double[] dstarr = {5.0, 5, 5, 10, 10, 10};
            CompareArray(temparr, dstarr);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void GetTemperatureArrayTest3() {
            // test schaltjahr
            var startdate = new DateTime(2014, 2, 27);
            var endDate = new DateTime(2014, 3, 2);
            var stepsize = new TimeSpan(12, 0, 0);
            var temperatureValue = new TemperatureValue(new DateTime(2012, 2, 2), 5, -1, -1, string.Empty, Guid.NewGuid().ToStrGuid());
            var temperatureValue2 = new TemperatureValue(new DateTime(2012, 2, 29), 10, -1, -1,
                string.Empty, Guid.NewGuid().ToStrGuid());
            var temperatureValue3 = new TemperatureValue(new DateTime(2012, 3, 1), 15, -1, -1, string.Empty, Guid.NewGuid().ToStrGuid());
            var tempvalues = new ObservableCollection<TemperatureValue>
            {
                temperatureValue,
                temperatureValue2,
                temperatureValue3
            };
            var temparr = TemperatureProfile.GetTemperatureArray(startdate, endDate, stepsize, tempvalues);
            double[] dstarr = {5.0, 5, 5, 5, 15, 15};
            CompareArray(temparr, dstarr);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void GetTemperatureArrayTest4() {
            // test Jahres�bergang
            var startdate = new DateTime(2013, 12, 27);
            var endDate = new DateTime(2014, 1, 3);
            var stepsize = new TimeSpan(12, 0, 0);
            var temperatureValue = new TemperatureValue(new DateTime(2012, 1, 1), 5, -1, -1, string.Empty, Guid.NewGuid().ToStrGuid());
            var temperatureValue2 = new TemperatureValue(new DateTime(2012, 1, 2), 10, -1, -1, string.Empty, Guid.NewGuid().ToStrGuid());
            var temperatureValue3 = new TemperatureValue(new DateTime(2012, 12, 28), 15, -1, -1,string.Empty, Guid.NewGuid().ToStrGuid());
            var tempvalues = new ObservableCollection<TemperatureValue>
            {
                temperatureValue,
                temperatureValue2,
                temperatureValue3
            };
            var temparr = TemperatureProfile.GetTemperatureArray(startdate, endDate, stepsize, tempvalues);
            // 27.1.: 10, 28.1.-1.1.:5, 2.1:10
            double[] dstarr = {10, 10, 15, 15, 15, 15, 15, 15, 15, 15, 5.0, 5, 10, 10};
            CompareArray(temparr, dstarr);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void LoadFromDatabaseTest()
        {
            using (var db = new DatabaseSetup(Utili.GetCurrentMethodAndClass()))
            {
                db.ClearTable(TemperatureProfile.TableName);
                db.ClearTable(TemperatureValue.TableName);
                var profiles = new ObservableCollection<TemperatureProfile>();
                TemperatureProfile.LoadFromDatabase(profiles, db.ConnectionString, false);
                foreach (var temperaturProfile in profiles)
                {
                    temperaturProfile.DeleteFromDB();
                }
                var tp = new TemperatureProfile("tempprofil1", null, "desc1", db.ConnectionString, Guid.NewGuid().ToStrGuid());
                tp.SaveToDB();
                tp.AddTemperature(new DateTime(2011, 1, 1), 20);
                tp.AddTemperature(new DateTime(2011, 2, 1), 15);
                tp.SaveToDB();
                TemperatureProfile.LoadFromDatabase(profiles, db.ConnectionString, false);

                (profiles.Count).Should().Be(1);
                (profiles[0].TemperatureValues.Count).Should().Be(2);
                profiles[0].DeleteOneTemperatur(profiles[0].TemperatureValues[0]);
                (profiles[0].TemperatureValues.Count).Should().Be(1);
                db.Cleanup();
            }
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void RealDeviceOneValueTest() {
            var startdt = new DateTime(2010, 1, 1);
            var endDt = new DateTime(2010, 1, 11);
            var stepsize = new TimeSpan(1, 0, 0);
            var temperatureValues = new ObservableCollection<TemperatureValue>
            {
                new TemperatureValue(new DateTime(2010, 1, 2), 10, -1, null, string.Empty, Guid.NewGuid().ToStrGuid())
            };
            var values = TemperatureProfile.GetTemperatureArray(startdt, endDt, stepsize, temperatureValues);
            (values.Length).Should().Be(240);
            (values[0]).Should().Be(10);
            (values[239]).Should().Be(10);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void RealDeviceTempArrayTestTest() {
            var startdt = new DateTime(2010, 1, 1);
            var endDt = new DateTime(2010, 1, 11);
            var stepsize = new TimeSpan(1, 0, 0);
            var temperatureValues = new ObservableCollection<TemperatureValue>
            {
                new TemperatureValue(new DateTime(2010, 1, 1), 10, -1, null, string.Empty,Guid.NewGuid().ToStrGuid()),
                new TemperatureValue(new DateTime(2010, 1, 2), 5, -1, null, string.Empty,Guid.NewGuid().ToStrGuid()),
                new TemperatureValue(new DateTime(2010, 1, 3), 6, -1, null, string.Empty,Guid.NewGuid().ToStrGuid()),
                new TemperatureValue(new DateTime(2010, 1, 4), 7, -1, null, string.Empty,Guid.NewGuid().ToStrGuid())
            };
            var values = TemperatureProfile.GetTemperatureArray(startdt, endDt, stepsize, temperatureValues);
            (values.Length).Should().Be(240);
            (values[0]).Should().Be(10);
            (values[23]).Should().Be(10);
            (values[24]).Should().Be(5);
            (values[47]).Should().Be(5);
            (values[48]).Should().Be(6);
            (values[71]).Should().Be(6);
            (values[72]).Should().Be(7);
            (values[239]).Should().Be(7);
        }

        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void RealDeviceTwoValuesTest() {
            var startdt = new DateTime(2010, 1, 1);
            var endDt = new DateTime(2010, 1, 11);
            var stepsize = new TimeSpan(1, 0, 0);
            var temperatureValues = new ObservableCollection<TemperatureValue>
            {
                new TemperatureValue(new DateTime(2010, 1, 1), 10, -1, null, string.Empty, Guid.NewGuid().ToStrGuid()),
                new TemperatureValue(new DateTime(2010, 1, 1, 1, 0, 0), 5, -1, null, string.Empty, Guid.NewGuid().ToStrGuid()),
                new TemperatureValue(new DateTime(2010, 1, 1, 2, 0, 0), 6, -1, null, string.Empty, Guid.NewGuid().ToStrGuid()),
                new TemperatureValue(new DateTime(2010, 1, 1, 3, 0, 0), 7, -1, null, string.Empty, Guid.NewGuid().ToStrGuid())
            };
            var values = TemperatureProfile.GetTemperatureArray(startdt, endDt, stepsize, temperatureValues);
            (values.Length).Should().Be(240);
            (values[0]).Should().Be(10);
            (values[1]).Should().Be(5);
            (values[2]).Should().Be(6);
            (values[3]).Should().Be(7);
            (values[239]).Should().Be(7);
        }

        public TemperatureProfileTests([JetBrains.Annotations.NotNull] ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}