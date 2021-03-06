﻿using Common;

namespace ChartCreator2.PDF {
    internal class ActivityPercentagePages : ChartPageBase {
        public ActivityPercentagePages():base("This shows the distribution of the activities, grouped by the " +
                                              "affordance AffordanceToCategories.", "ActivityPercentage", "ActivityPercentage.*.png",
            "Activity Distribution per Person"
            ) {
            MyTargetDirectory = TargetDirectory.Charts;
        }

        protected override string GetGraphTitle(string filename) {
            var str = filename.Split('.');
            var hh = str[1];
            var person = str[2];
            return hh + " -  " + person;
        }
    }
}