using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statkraft.Time;
using Statkraft.XTimeSeries;
using SmgRepo = Statkraft.XTimeSeries.Infrastructure.TSS.Repository;
using BradyReop = Statkraft.XTimeSeries.Infrastructure.Brady.Repository;

namespace TimeSeriesWebDemo
{
    public class TimeSeriesService
    {
        private readonly SmgRepo _smRepository = new SmgRepo("", "", "", "");
        private readonly BradyReop _bradyRepository = new BradyReop("", "", "");

        public IList<ITimeSeries> GetTimeSeries(IList<TimeSeriesInfo> infos, Period period)
        {
            var timeSeries = new List<ITimeSeries>();
            var smgIds = MapInfosToIdentities(infos, SourceSystem.SmG);

            timeSeries.AddRange(_smRepository.ReadRawPoints(smgIds, period));

            var bradyIds = MapInfosToIdentities(infos, SourceSystem.Brady);

            timeSeries.AddRange(_bradyRepository.ReadRawPoints(bradyIds, period));

            return timeSeries;
        }

         private IList<TsIdentity> MapInfosToIdentities(IEnumerable<TimeSeriesInfo> timeSeriesInfos, SourceSystem sourceSystem)
        {
            switch (sourceSystem)
            {
                case SourceSystem.SmG:
                {
                    //Remarks - when reading series from smg, we are using the name param in this case
                    return timeSeriesInfos.Where(info => info.SourceSystem == SourceSystem.SmG).Select(info => new TsIdentity(0, info.Id)).ToList();
                }
                case SourceSystem.Brady:
                {
                    //Remarks - when reading series from brady, we are using the id param in this case
                    return timeSeriesInfos.Where(info => info.SourceSystem == SourceSystem.Brady).Select(info => new TsIdentity(int.Parse(info.Id), null)).ToList();
                }
                default :
                    throw new NotImplementedException("Source System not implemented");
            }
        }
    }
    
}