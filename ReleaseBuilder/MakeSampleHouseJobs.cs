﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Automation;
using Automation.ResultFiles;
using Common;
using Database;
using Database.Helpers;
using Database.Tests;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NUnit.Framework;
using Logger = Common.Logger;

namespace ReleaseBuilder
{
    [TestFixture]
    public class MakeSampleHouseJobs
    {
        private static void CopyAll([NotNull] DirectoryInfo source, [NotNull] DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (var fi in source.GetFiles())
            {
                Logger.Info(string.Format(CultureInfo.CurrentCulture, @"Copying {0}\{1}", target.FullName, fi.Name));
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        [Test]
        public void RunDirectHouseholds()
        {
            DatabaseSetup db = new DatabaseSetup(Utili.GetCurrentMethodAndClass());
            WorkingDir wd = new WorkingDir(Utili.GetCurrentMethodAndClass());
            Simulator sim = new Simulator(db.ConnectionString);
            string dir = wd.Combine("DirectHouseJobs");
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            foreach (var mhh in sim.ModularHouseholds.It) {
                HouseCreationAndCalculationJob hj = new HouseCreationAndCalculationJob("Households","2019","TK");
                hj.House = new HouseData(Guid.NewGuid().ToString(),"HT01",10000,10000,"House for " + mhh.Name);
                hj.House.Households.Add( new HouseholdData(Guid.NewGuid().ToString(),
                    false,mhh.Name ,null,null,null,null,HouseholdDataSpecifictionType.ByHouseholdName));
                hj.House.Households[0].HouseholdNameSpecification = new HouseholdNameSpecification(mhh.Name);
                SetCalcSpec(hj, sim);
                string fn =Path.Combine(dir, AutomationUtili.CleanFileName(mhh.Name)  + ".json");
                File.WriteAllText(fn,JsonConvert.SerializeObject(hj,Formatting.Indented));
            }
            CopyAll(new DirectoryInfo(dir),new DirectoryInfo(@"X:\HouseJobs\Blockstrom\DirectHouseholds") );
        }

        [Test]
        public void RunHouseholdTemplate()
        {
            DatabaseSetup db = new DatabaseSetup(Utili.GetCurrentMethodAndClass());
            WorkingDir wd = new WorkingDir(Utili.GetCurrentMethodAndClass());
            Simulator sim = new Simulator(db.ConnectionString);
            string dir = wd.Combine("DirectHouseJobs");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            Random rnd = new Random();

            List<string> houseTypes = sim.HouseTypes.It.Select(x => x.Name.Substring(0, x.Name.IndexOf(" ", StringComparison.Ordinal))).ToList();
            foreach (var mhh in sim.HouseholdTemplates.It)
            {
                for (int i = 0; i < 100; i++) {
                    HouseCreationAndCalculationJob hj = new HouseCreationAndCalculationJob("TemplatedRandomHouseType", "2019", "TK");
                    string ht = houseTypes[rnd.Next(houseTypes.Count)];
                    Console.WriteLine(ht);
                    hj.House = new HouseData(Guid.NewGuid().ToString(), ht, 10000, 10000, "House for " + mhh.Name + " " + i);
                    hj.House.Households.Add(new HouseholdData(Guid.NewGuid().ToString(), false,
                        mhh.Name, null, null, null,
                        null, HouseholdDataSpecifictionType.ByTemplateName));
                    hj.House.Households[0].HouseholdTemplateSpecification = new HouseholdTemplateSpecification(mhh.Name);
                    SetCalcSpec(hj, sim);
                    if(hj.CalcSpec.CalcOptions == null)
                    {
                        throw new LPGException("calcoption not set");
                    }
                    hj.CalcSpec.CalcOptions.Add(CalcOption.EnergyCarpetPlot);
                    hj.CalcSpec.CalcOptions.Add(CalcOption.IndividualSumProfiles);
                    string fn = Path.Combine(dir, AutomationUtili.CleanFileName(mhh.Name) + "." +i+ ".json");
                    File.WriteAllText(fn, JsonConvert.SerializeObject(hj, Formatting.Indented));
                }
            }
            CopyAll(new DirectoryInfo(dir), new DirectoryInfo(@"X:\HouseJobs\Blockstrom\TemplatedHouses"));
        }

        private static void SetCalcSpec([NotNull] HouseCreationAndCalculationJob hj, [NotNull] Simulator sim)
        {
            hj.CalcSpec = JsonCalcSpecification.MakeDefaultsForProduction();
            hj.CalcSpec.OutputDirectory = "Results";
            hj.CalcSpec.CalcOptions = new List<CalcOption>();
            hj.CalcSpec.CalcOptions.Add(CalcOption.SumProfileExternalIndividualHouseholdsAsJson);
            hj.CalcSpec.DefaultForOutputFiles = OutputFileDefault.None;
            hj.CalcSpec.ExternalTimeResolution = "00:15:00";
            hj.CalcSpec.StartDate = new DateTime(2019, 1, 1);
            hj.CalcSpec.EndDate = new DateTime(2019, 12, 31);
            hj.CalcSpec.TemperatureProfile = sim.TemperatureProfiles[0].GetJsonReference();
            var geoloc = sim.GeographicLocations.FindFirstByName("Chemnitz", FindMode.Partial)??throw new LPGException("Chemnitz not found");
            hj.CalcSpec.GeographicLocation =geoloc .GetJsonReference();
        }
    }
}