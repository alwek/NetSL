using System.Threading.Tasks;

namespace NetSL.Api.Services{
    public interface ITrafficService{
        public Task<string> GetTrafficSituation();
    }
}