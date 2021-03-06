//-----------------------------------------------------------------------

// <copyright>
//
// Copyright (c) TU Chemnitz, Prof. Technische Thermodynamik
// Written by Noah Pflugradt.
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//  Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the distribution.
// All advertising materials mentioning features or use of this software must display the following acknowledgement:
// “This product includes software developed by the TU Chemnitz, Prof. Technische Thermodynamik and its contributors.”
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
using Automation;
using Automation.ResultFiles;
using CalculationEngine.OnlineDeviceLogging;
using CalculationEngine.OnlineLogging;
using Common;
using Common.JSON;
using Common.SQLResultLogging;
using JetBrains.Annotations;

namespace CalculationEngine.HouseholdElements {
    /*public class HumanHeatGainSpecification
    {
        public CalcLoadType PowerLoadtype { get; set; }
        public CalcLoadType CountLoadtype { get; set; }

    }*/

    public class CalcRepo: IDisposable {
        //public HumanHeatGainSpecification HumanHeatGainSpecification { get; }

        [NotNull]
        public DateStampCreator DateStampCreator => _dateStampCreator ?? throw new LPGException("no dsc");

        [NotNull]
        public static CalcRepo Make([NotNull] CalcParameters calcParameters, [NotNull] IInputDataLogger idl,
                                    [NotNull] string resultPath, [NotNull] string calcObjectName,
                                    CalculationProfiler calculationProfiler)
        {

            DateStampCreator dsc = new DateStampCreator(calcParameters);
            OnlineLoggingData old = new OnlineLoggingData(dsc,idl,calcParameters);
            FileFactoryAndTracker fft = new FileFactoryAndTracker(resultPath, calcObjectName, idl);
            LogFile lf = new LogFile(calcParameters, fft);
            OnlineDeviceActivationProcessor odap = new OnlineDeviceActivationProcessor(old,calcParameters,fft);
                Random rnd = new Random(calcParameters.ActualRandomSeed);
                NormalRandom nr = new NormalRandom(0,0.1,rnd);
                SqlResultLoggingService srls = new SqlResultLoggingService(resultPath);
            CalcRepo cr = new CalcRepo(odap,rnd,calcParameters,old,nr,lf,srls,
                idl,calculationProfiler,fft,dsc);
            return cr;
        }
        [CanBeNull] private readonly FileFactoryAndTracker _fft;

        public CalcRepo(
                        [CanBeNull] IOnlineDeviceActivationProcessor odap = null,
                        [CanBeNull] Random rnd = null,
                        [CanBeNull]CalcParameters calcParameters= null,
                        [CanBeNull] IOnlineLoggingData onlineLoggingData= null,
                        [CanBeNull] NormalRandom normalRandom= null,
                        [CanBeNull] ILogFile lf = null,
                        [CanBeNull] SqlResultLoggingService srls= null,
                        [CanBeNull] IInputDataLogger inputDataLogger=null,
                        [CanBeNull] CalculationProfiler calculationProfiler=null,
            [CanBeNull] FileFactoryAndTracker fft =null,
                        [CanBeNull] DateStampCreator dsc = null)
        {
            _dateStampCreator = dsc;
            _fft = fft;
            _odap = odap;
            _rnd = rnd;
            _calcParameters = calcParameters;
            _onlineLoggingData = onlineLoggingData;
            _normalRandom = normalRandom;
            _lf = lf;
            _srls = srls;
            _inputDataLogger = inputDataLogger;
            _calculationProfiler = calculationProfiler;
        }
        [CanBeNull]
        private readonly ILogFile _lf;

        [NotNull] private readonly IOnlineDeviceActivationProcessor _odap;
        [NotNull] private readonly Random _rnd;
        private readonly CalcParameters _calcParameters;
        [CanBeNull] private readonly IOnlineLoggingData _onlineLoggingData;
        private readonly NormalRandom _normalRandom;
        [NotNull] private readonly SqlResultLoggingService _srls;
        private readonly IInputDataLogger _inputDataLogger;
        [NotNull] private readonly CalculationProfiler _calculationProfiler;
        private readonly DateStampCreator _dateStampCreator;

        [NotNull]
        public IOnlineDeviceActivationProcessor Odap => _odap ?? throw new LPGException("no odap");

        [NotNull]
        public Random Rnd => _rnd ?? throw new LPGException("no rnd");

        [NotNull]
        public CalcParameters CalcParameters => _calcParameters ?? throw new LPGException("no calcparameters");

        [NotNull]
        public IOnlineLoggingData OnlineLoggingData => _onlineLoggingData ?? throw new LPGException("no old");

        [NotNull]
        public NormalRandom NormalRandom => _normalRandom ?? throw new LPGException("no nr");

        [NotNull]
        public ILogFile Logfile => _lf ?? throw new LPGException("no lf");

        [NotNull]
        public SqlResultLoggingService Srls => _srls ?? throw new LPGException("no srls");

        [NotNull]
        public IInputDataLogger InputDataLogger => _inputDataLogger ?? throw new LPGException("no inputdatalogger");

        [NotNull]
        public CalculationProfiler CalculationProfiler => _calculationProfiler ?? throw new LPGException("no calc profiler");

        [NotNull]
        public FileFactoryAndTracker FileFactoryAndTracker => _fft ?? throw new LPGException("no fft");


        public void Dispose()
        {
            _fft?.Dispose();
            _lf?.Dispose();
            _onlineLoggingData?.Dispose();
        }
    }
    public abstract class CalcBase {
        [NotNull]
        private readonly string _name;

        public StrGuid Guid { get; }
        protected CalcBase([NotNull] string pName,  StrGuid guid)
        {
            _name = pName;
            Guid = guid;
        }

        [NotNull]
        public string Name => _name;

        [NotNull]
        public override string ToString() => GetType() + " " + _name + " (" + Guid +")";
    }
}