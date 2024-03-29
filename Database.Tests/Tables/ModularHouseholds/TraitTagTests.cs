﻿using System.Collections.ObjectModel;
using Automation;
using Common;
using Common.Tests;
using Database.Helpers;
using Database.Tables.ModularHouseholds;
using FluentAssertions;
using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;


namespace Database.Tests.Tables.ModularHouseholds {

    public class TraitTagTests : UnitTestBaseClass
    {
        [Fact]
        [Trait(UnitTestCategories.Category,UnitTestCategories.BasicTest)]
        public void TraitTagTest()
        {
            using (var db = new DatabaseSetup(Utili.GetCurrentMethodAndClass()))
            {
                db.ClearTable(TraitTag.TableName);
                var cat = new CategoryDBBase<TraitTag>("Household Trait Tags");
                TraitTag.LoadFromDatabase(cat.It, db.ConnectionString, false);
                (cat.MyItems.Count).Should().Be(0);
                cat.CreateNewItem(db.ConnectionString);
                cat.SaveToDB();
                var tags = new ObservableCollection<TraitTag>();
                TraitTag.LoadFromDatabase(tags, db.ConnectionString, false);
                (tags.Count).Should().Be(1);
                db.Cleanup();
            }
        }

        public TraitTagTests([NotNull] ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}