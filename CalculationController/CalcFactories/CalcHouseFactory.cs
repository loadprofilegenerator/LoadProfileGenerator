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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Automation.ResultFiles;
using CalculationController.DtoFactories;
using CalculationEngine;
using CalculationEngine.HouseElements;
using CalculationEngine.HouseholdElements;
using Common;
using Common.CalcDto;
using Common.JSON;
using JetBrains.Annotations;
using CalcDegreeHour = CalculationEngine.HouseElements.CalcDegreeHour;

namespace CalculationController.CalcFactories {
    public class CalcHouseFactory {
        [NotNull] private readonly AvailabilityDtoRepository _availabilityDtoRepository;

        [NotNull] private readonly CalcDeviceTaggingSets _calcDeviceTaggingSets;
        private readonly CalcRepo _calcRepo;


        [NotNull] private readonly CalcModularHouseholdFactory _cmhf;


        [NotNull] private readonly CalcLoadTypeDictionary _ltDict;


        [NotNull] private readonly CalcVariableRepository _variableRepository;

        public CalcHouseFactory([NotNull] CalcLoadTypeDictionary ltDict,
                                [NotNull] CalcModularHouseholdFactory cmhf,
                                [NotNull] AvailabilityDtoRepository availabilityDtoRepository,
                                [NotNull] CalcVariableRepository variableRepository,
                                [NotNull] CalcDeviceTaggingSets calcDeviceTaggingSets,
                                CalcRepo calcRepo)
        {
            _ltDict = ltDict;
            _cmhf = cmhf;
            _availabilityDtoRepository = availabilityDtoRepository;
            _variableRepository = variableRepository;
            _calcDeviceTaggingSets = calcDeviceTaggingSets;
            _calcRepo = calcRepo;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Objekte verwerfen, bevor Bereich verloren geht")]
        [SuppressMessage("ReSharper", "SwitchStatementMissingSomeCases")]
        [NotNull]
        public CalcHouse MakeCalcHouse([NotNull] CalcHouseDto calcHouseDto, CalcRepo calcRepo)
        {
            HouseholdKey houseKey = Constants.HouseKey;
            var calchouse = new CalcHouse(calcHouseDto.HouseName, calcHouseDto.HouseKey, calcRepo);
            List<CalcLocation> houseLocations = new List<CalcLocation>();
            foreach (var houseLoc in calcHouseDto.HouseLocations) {
                CalcLocation cl = new CalcLocation(houseLoc.Name, houseLoc.Guid);
                houseLocations.Add(cl);
            }

            var calcAbleObjects = new List<ICalcAbleObject>();
            //var globalLocationDict = new Dictionary<CalcLocationDto, CalcLocation>();
            foreach (var householddto in calcHouseDto.Households) {
                var hh = _cmhf.MakeCalcModularHousehold(householddto, out var _,
                    calcHouseDto.HouseName, calcHouseDto.Description,_calcRepo);
                calcAbleObjects.Add(hh);

                //    foreach (var pair in dtoCalcLocationDict.LocationDtoDict) {
                //      if (!globalLocationDict.ContainsKey(pair.Key)) {
                //        globalLocationDict.Add(pair.Key,  pair.Value);
                //  }
                //}
            }

            calchouse.SetHouseholds(calcAbleObjects);
            MakeHeating(calcHouseDto, calchouse, houseKey, houseLocations); //, taggingSets);

            SetAirConditioningOnHouse(calcHouseDto, calchouse, houseLocations);
            var autodevs2 = MakeCalcAutoDevsFromHouse(calcHouseDto, houseLocations);
            calchouse.SetAutoDevs(autodevs2);
            // energy Storage
            SetEnergyStoragesOnHouse(calcHouseDto.EnergyStorages, houseKey, calchouse,
                _variableRepository); //, taggingSets);
            // transformation devices
            MakeAllTransformationDevices(calcHouseDto,  calchouse, houseKey); //taggingSets,

            // generators
            calchouse.SetGenerators(MakeGenerators(calcHouseDto.Generators, houseKey)); //taggingSets,

            return calchouse;
        }

        private void MakeAllTransformationDevices([NotNull] CalcHouseDto house,
                                                  [NotNull] CalcHouse calchouse,
                                                  [NotNull] HouseholdKey householdKey) //List<CalcDeviceTaggingSet> taggingSets,
        {
            var ctds = new List<CalcTransformationDevice>();
            var devcategoryGuid = Guid.NewGuid().ToStrGuid();
            var trafolocGuid = Guid.NewGuid().ToStrGuid();
            foreach (var trafo in house.TransformationDevices) {
                foreach (var set in _calcDeviceTaggingSets.AllCalcDeviceTaggingSets) {
                    set.AddTag(trafo.Name, "House Device");
                }
                CalcDeviceDto cdd = new CalcDeviceDto(trafo.Name,devcategoryGuid,householdKey,
                    OefcDeviceType.Transformation,"Transformation Devices","",trafo.Guid,trafolocGuid,"Transformation Devices");
                var ctd = new CalcTransformationDevice(_calcRepo.Odap,
                    trafo.MinValue,
                    trafo.MaxValue,
                    trafo.MinPower,
                    trafo.MaxPower,
                    cdd, _ltDict.GetLoadtypeByGuid(trafo.InputLoadType.Guid));
                foreach (var outlt in trafo.OutputLoadTypes) {
                    ctd.AddOutputLoadType(_ltDict.GetLoadtypeByGuid(outlt.LoadType.Guid), outlt.ValueScalingFactor, outlt.FactorType);
                }

                if (ctd.OutputLoadTypes.Count > 0) {
                    if (trafo.Datapoints != null) {
                        foreach (var datapoint in trafo.Datapoints) {
                            ctd.AddDatapoint(datapoint.Ref, datapoint.Val);
                        }
                    }

                    foreach (var condition in trafo.Conditions) {
                        var variable = _variableRepository.GetVariableByGuid(condition.CalcVariableDto.Guid);
                        ctd.AddCondition(condition.Name, variable, condition.MinValue, condition.MaxValue, condition.Guid);
                    }

                    ctds.Add(ctd);
                }
            }

            calchouse.SetTransformationDevices(ctds);
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        [NotNull]
        [ItemNotNull]
        private List<CalcAutoDev> MakeCalcAutoDevsFromHouse([NotNull] CalcHouseDto house,
                                                            [NotNull] [ItemNotNull] List<CalcLocation> houseLocations)
        {
            var autodevs = new List<CalcAutoDev>(house.AutoDevs.Count);
            // zur kategorien zuordnung
            foreach (var hhautodev in house.AutoDevs) {
                CalcProfile calcProfile = CalcDeviceFactory.MakeCalcProfile(hhautodev.CalcProfile,_calcRepo.CalcParameters);
                CalcLoadType clt = _ltDict.GetLoadtypeByGuid(hhautodev.LoadtypeGuid);
                List<CalcDeviceLoad> loads = new List<CalcDeviceLoad>();
                foreach (CalcDeviceLoadDto loadDto in hhautodev.Loads) {
                    CalcDeviceLoad load = new CalcDeviceLoad(loadDto.Name,
                        loadDto.MaxPower,
                        _ltDict.GetLoadtypeByGuid(loadDto.LoadTypeGuid),
                        loadDto.AverageYearlyConsumption,
                        loadDto.PowerStandardDeviation);
                    loads.Add(load);
                }

                List<VariableRequirement> requirements = new List<VariableRequirement>();
                foreach (var reqDto in hhautodev.Requirements) {
                    VariableRequirement rq = new VariableRequirement(reqDto.Name,
                        reqDto.Value,
                        reqDto.CalcLocationName,
                        reqDto.LocationGuid,
                        reqDto.VariableCondition,
                        _variableRepository,
                        reqDto.VariableGuid);
                    requirements.Add(rq);
                }

                CalcLocation houseLocation = houseLocations.Single(x => x.Guid == hhautodev.CalcLocationGuid);
                var cautodev = new CalcAutoDev(
                    calcProfile,
                    clt,
                    loads,
                    hhautodev.TimeStandardDeviation,
                    hhautodev.Multiplier,
                    houseLocation,
                    requirements, hhautodev,_calcRepo);
                var busyarr = _availabilityDtoRepository.GetByGuid(hhautodev.BusyArr.Guid);
                cautodev.ApplyBitArry(busyarr, _ltDict.GetLoadtypeByGuid(hhautodev.LoadtypeGuid));
                autodevs.Add(cautodev);
            }

            return autodevs;
        }

        [NotNull]
        [ItemNotNull]
        private List<CalcGenerator> MakeGenerators([NotNull] [ItemNotNull] List<CalcGeneratorDto> generators, [NotNull] HouseholdKey householdKey)
            //,
        {
            var cgens = new List<CalcGenerator>();
            var gendevcategoryGuid = Guid.NewGuid().ToStrGuid();
            var genlocGuid = Guid.NewGuid().ToStrGuid();
            foreach (var gen in generators) {
                //CalcLoadType lt = _ltDict.GetLoadtypeByGuid(gen.LoadType.Guid);
                CalcDeviceDto deviceDto = new CalcDeviceDto(gen.Name,
                    gendevcategoryGuid,householdKey,OefcDeviceType.Generator,"Generators",
                    "",gen.Guid,genlocGuid,"Generators");
                var cgen = new CalcGenerator(
                    _calcRepo.Odap,
                    _ltDict.GetCalcLoadTypeByLoadtype(gen.LoadType),
                    gen.Values,
                    _calcRepo.CalcParameters,
                    deviceDto);
                cgens.Add(cgen);
                foreach (var set in _calcDeviceTaggingSets.AllCalcDeviceTaggingSets) {
                    set.AddTag(gen.Name, "House Devices");
                }
            }

            return cgens;
        }

        private void MakeHeating([NotNull] CalcHouseDto house,
                                 [NotNull] CalcHouse calchouse,
                                 [NotNull] HouseholdKey householdKey,
                                 [NotNull] [ItemNotNull] List<CalcLocation> locations) //, List<CalcDeviceTaggingSet> deviceTaggingSets)
        {
            if (house.SpaceHeating == null) {
                return;
            }

            var heating = house.SpaceHeating;
            //var isNan = false;
            foreach (var degreeHour in heating.CalcDegreeDays) {
                if (double.IsNaN(degreeHour.HeatingAmount)) {
                    throw new LPGException(
                        "Heating degree days contain not-a-number. Check the temperature profile and your space heating settings.");
                }
            }

            var degreeDayDict = new Dictionary<Tuple<int, int, int>, CalcDegreeDay>();
            foreach (var degreeDay in heating.CalcDegreeDays) {
                var cdd = new CalcDegreeDay {
                    HeatingAmount = degreeDay.HeatingAmount,
                    Year = degreeDay.Year,
                    Month = degreeDay.Month,
                    Day = degreeDay.Day
                };
                degreeDayDict.Add(new Tuple<int, int, int>(cdd.Year, cdd.Month, cdd.Day), cdd);
            }

            var load = heating.PowerUsage[0];
            var lt = _ltDict.GetLoadtypeByGuid(load.LoadTypeGuid);
            var cdl = new CalcDeviceLoad(lt.Name, load.MaxPower, lt, load.AverageYearlyConsumption, load.PowerStandardDeviation);
            var cdls = new List<CalcDeviceLoad> {
                cdl
            };
            var heatloc = locations.Single(x => heating.CalcLocationGuid == x.Guid);
            CalcDeviceDto calcDeviceDto = new CalcDeviceDto("Space Heating",
                Guid.NewGuid().ToStrGuid(),
                householdKey,OefcDeviceType.SpaceHeating,"Space Heating",
                string.Empty,Guid.NewGuid().ToStrGuid(),
                heatloc.Guid,heatloc.Name);
            var csh = new CalcSpaceHeating(cdls,
                degreeDayDict,
                heatloc,
                calcDeviceDto, _calcRepo);
            //foreach (var calcDeviceTaggingSet in taggingSets) {
            //calcDeviceTaggingSet.AddTag("Space Heating","House Device");
            //}

            calchouse.SetSpaceHeating(csh); //,deviceTaggingSets
        }

        private void SetAirConditioningOnHouse([NotNull] CalcHouseDto house,
                                               [NotNull] CalcHouse calcHouse,
                                               [NotNull] [ItemNotNull] List<CalcLocation> calcLocations)
        {
            if (house.AirConditioning == null) {
                return;
            }

            var acdto = house.AirConditioning;
            var degreeHourDict = new Dictionary<Tuple<int, int, int, int>, CalcDegreeHour>();
            foreach (CalcDegreeHourDto dto in acdto.CalcDegreeHours) {
                degreeHourDict.Add(new Tuple<int, int, int, int>(dto.Year, dto.Month, dto.Day, dto.Hour),
                    new CalcDegreeHour(dto.Year, dto.Month, dto.Day, dto.Hour, dto.CoolingAmount));
            }

            //var isNan = false;
            foreach (var degreeHour in degreeHourDict.Values) {
                if (double.IsNaN(degreeHour.CoolingAmount)) {
                    throw new LPGException("Cooling degree hour was not-a-number. Check the air conditioning and temperature profile.");
                }
            }

            var deviceLoad = acdto.DeviceLoads[0];
            var loadtype = _ltDict.GetLoadtypeByGuid(deviceLoad.LoadTypeGuid);
            var cdl = new CalcDeviceLoad(deviceLoad.Name,
                deviceLoad.MaxPower,
                loadtype,
                deviceLoad.AverageYearlyConsumption,
                deviceLoad.PowerStandardDeviation);
            var cdls = new List<CalcDeviceLoad> {
                cdl
            };

            var acloc = calcLocations.Single(x => x.Guid == acdto.CalcLocationGuid);
            CalcDeviceDto acDevdto = new CalcDeviceDto("Air Conditioning",
                Guid.NewGuid().ToStrGuid(),
                house.HouseKey,OefcDeviceType.AirConditioning,
                "Air Conditioning",
                string.Empty,Guid.NewGuid().ToStrGuid(),
                acloc.Guid,acloc.Name);
            var csh = new CalcAirConditioning(
                cdls,
                degreeHourDict,
                acloc,
                acDevdto, _calcRepo);
            calcHouse.SetAirConditioning(csh);
        }

        private void SetEnergyStoragesOnHouse([NotNull] [ItemNotNull] List<CalcEnergyStorageDto> energyStorages,
                                                                 [NotNull] HouseholdKey householdKey,
                                                                 [NotNull] CalcHouse calchouse, CalcVariableRepository calcVariableRepository
                                              ) //, List<CalcDeviceTaggingSet> deviceTaggingSets)
        {
            var cess = new List<CalcEnergyStorage>();
            var esCategoryGuid = Guid.NewGuid().ToStrGuid();
            var esLocGuid = Guid.NewGuid().ToStrGuid();
            foreach (var es in energyStorages) {
                //foreach (DeviceTaggingSet set in deviceTaggingSets) {
                //set.AddTag(es.Name,"House Device");
                //}
                var lti = _ltDict.GetCalcLoadTypeByLoadtype(es.InputLoadType).ConvertToDto();
                CalcDeviceDto deviceDto = new CalcDeviceDto(es.Name,esCategoryGuid,householdKey,OefcDeviceType.Storage,
                    "Energy Storage","",es.Guid,esLocGuid,"Energy Storages");
                var ces = new CalcEnergyStorage(_calcRepo.Odap,
                    lti,
                    es.MaximumStorageRate,
                    es.MaximumWithdrawRate,
                    es.MinimumStorageRate,
                    es.MinimumWithdrawRate,
                    es.InitialFill,
                    es.StorageCapacity,
                    _calcRepo.Logfile.EnergyStorageLogfile,
                    deviceDto
                    );
                foreach (var signal in es.Signals) {
                    CalcVariable cv = calcVariableRepository.GetVariableByGuid(signal.CalcVariableDto.Guid);
                    var cessig = new CalcEnergyStorageSignal(signal.Name,
                        signal.TriggerOffPercent,
                        signal.TriggerOnPercent,
                        signal.Value,
                        cv,
                        signal.Guid);
                    ces.AddSignal(cessig);
                }

                cess.Add(ces);
                if (ces.Signals.Count != es.Signals.Count) {
                    throw  new LPGException("Signal not initialized correctly");
                }
            }

            var calcEnergyStorages = cess; //,deviceTaggingSets);
            calchouse.SetStorages(calcEnergyStorages);
            //return calcEnergyStorages;
        }
    }
}