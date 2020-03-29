using System.Threading.Tasks;
using NetSL.Api.Models.TrafficSituation;
using NetSL.Api.Models.RealtimeInformation;
using NetSL.Api.Models.DeviationInformation;
using NetSL.Api.Models.Stations;

namespace NetSL.Api.Services{
    public interface ITrafficService{
        public Task<TrafficSituation> GetTrafficSituation();
        public Task<RealtimeInformation> GetRealtimeInformation(int siteId, int timeWindow);
        public Task<DeviationInformation> GetDeviationInformation(string transportMode, string lineNumber, int siteId, string fromDate, string toDate);
        public Task<Stations> GetStations(string searchString);
    }
}