﻿using Common;

namespace ChartCreator2.PDF {
    internal class SumProfilePagesExternal : ChartPageBase {
        public SumProfilePagesExternal() :base("This shows the energy use during the simulation in the external time resolution.",
            "SumProfiles_",
            "SumProfiles_*.png",
            "Sum Profiles External Time Resolution"
            )
        {
            MyTargetDirectory = TargetDirectory.Charts;
        }

        protected override string GetGraphTitle(string filename) {
            var arr = filename.Split('.');
            var arr2 = arr[0].Split('_');
            return "Summed up curve in the external time resolution of " + arr2[1] + " for " + arr[1] + " from " +
                   filename;
        }
    }
}