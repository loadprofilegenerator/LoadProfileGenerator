﻿using Automation;
using Automation.ResultFiles;
using Common.SQLResultLogging.Loggers;
using JetBrains.Annotations;

namespace Common.CalcDto {
    public class CalcVariableDto: IHouseholdKey
    {
        public CalcVariableDto([NotNull]string name, StrGuid guid, double value,
                               [NotNull]string locationName, StrGuid locationGuid, [NotNull]HouseholdKey householdKey)
        {
            Name = name;
            Guid = guid;
            Value = value;
            LocationName = locationName;
            LocationGuid = locationGuid;
            HouseholdKey = householdKey;
        }
        [NotNull]
        public string Name { get; }
        public StrGuid Guid { get; }
        public double Value { get;  }
        [NotNull]
        public string LocationName { get; }
        public StrGuid LocationGuid { get; }
        public HouseholdKey HouseholdKey { get; }
    }
}