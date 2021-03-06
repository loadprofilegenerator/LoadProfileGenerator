﻿using System;
using Automation;
using Automation.ResultFiles;
using Common.CalcDto;

namespace CalculationEngine.OnlineDeviceLogging {
    using System.Diagnostics.CodeAnalysis;
    using Common.JSON;
    using JetBrains.Annotations;

    public readonly struct OefcKey : IEquatable<OefcKey> {
        public override int GetHashCode()
        {
            unchecked {
                var hashCode = _hashCode;
                hashCode = (hashCode * 397) ^ FullKey.GetHashCode();
                hashCode = (hashCode * 397) ^ (LoadtypeGuid != null ? LoadtypeGuid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DeviceCategory.GetHashCode();
                hashCode = (hashCode * 397) ^ LocationGuid.GetHashCode();
                hashCode = (hashCode * 397) ^ DeviceGuid.GetHashCode();
                hashCode = (hashCode * 397) ^ HouseholdKey.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)ThisDeviceType;
                return hashCode;
            }
        }
        private readonly int _hashCode;

        [NotNull]
        public string FullKey { get; }
        public OefcKey([NotNull] CalcDeviceDto dto, StrGuid loadtypeGuid)
        {
            HouseholdKey = dto.HouseholdKey;
            ThisDeviceType =dto.DeviceType;
            DeviceGuid = dto.Guid;
            LocationGuid = dto.LocationGuid;
            LoadtypeGuid = loadtypeGuid;
            DeviceCategory = dto.DeviceCategoryName;
            unchecked
            {
                _hashCode = LocationGuid.GetHashCode();
                if (loadtypeGuid != null)
                {
                    _hashCode = (_hashCode * 397) ^ loadtypeGuid.GetHashCode();
                }

                _hashCode = (_hashCode * 397) ^ DeviceGuid.GetHashCode();
                _hashCode = (_hashCode * 397) ^ HouseholdKey.Key.GetHashCode();
                _hashCode = (_hashCode * 397) ^ (int)ThisDeviceType;
            }
            //needed for the makekey due to compiler error
            FullKey = "";
            FullKey = MakeKey();
        }
        /*
        public OefcKey([NotNull] HouseholdKey householdKey,
                       OefcDeviceType deviceType,
                       [NotNull] string deviceGuid,
                       [NotNull] string locationGuid,
                       [CanBeNull] string loadtypeGuid,
                       [NotNull] string deviceCategory)
        {
            HouseholdKey = householdKey;
            ThisDeviceType = deviceType;
            DeviceGuid = deviceGuid;
            LocationGuid = locationGuid;
            LoadtypeGuid = loadtypeGuid;
            DeviceCategory = deviceCategory;
            unchecked
            {
                _hashCode = LocationGuid.GetHashCode();
                if(loadtypeGuid!= null) {
                    _hashCode = (_hashCode * 397) ^ loadtypeGuid.GetHashCode();
                }

                _hashCode = (_hashCode * 397) ^ DeviceGuid.GetHashCode();
                _hashCode = (_hashCode * 397) ^ HouseholdKey.Key.GetHashCode();
                _hashCode= (_hashCode * 397) ^ (int)ThisDeviceType;
            }
            //needed for the makekey due to compiler error
            FullKey = "";
            FullKey= MakeKey();
        }
        */
        public override bool Equals(object obj) {
            return obj is OefcKey other && Equals(other);
        }
        [NotNull]
        public  string MakeKey()
        {
            return HouseholdKey + "#" +
                   ThisDeviceType + "#" +
                   DeviceGuid + "#" +
                   LocationGuid + "#" +
                   LoadtypeGuid;
        }
        [NotNull]
        public override string ToString()
        {
            return   FullKey;
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public bool Equals(OefcKey other)
        {
            return _hashCode == other._hashCode && FullKey == other.FullKey && Equals(LoadtypeGuid, other.LoadtypeGuid) && DeviceCategory == other.DeviceCategory && LocationGuid.Equals(other.LocationGuid) && DeviceGuid.Equals(other.DeviceGuid) && HouseholdKey.Equals(other.HouseholdKey) && ThisDeviceType == other.ThisDeviceType;
        }

        public static bool operator ==(in OefcKey point1, OefcKey point2) => point1.Equals(point2);

        public static bool operator !=(in OefcKey point1, OefcKey point2) => !point1.Equals(point2);

        public StrGuid LoadtypeGuid { get; }

        [NotNull]
        public string DeviceCategory { get; }

        public StrGuid LocationGuid { get; }

        public StrGuid DeviceGuid { get; }
        [NotNull]
        public HouseholdKey HouseholdKey { get; }
        public OefcDeviceType ThisDeviceType { get; }
    }
}