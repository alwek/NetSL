using System.Threading.Tasks;
using NetSL.Api.Models;

namespace NetSL.Api.Services{
    public interface ITrafficService{
        public Task<TrafficSituation> GetTrafficSituation();
        public Task<RealtimeInformation> GetRealtimeInformation(int siteId, int timeWindow);
    }
}