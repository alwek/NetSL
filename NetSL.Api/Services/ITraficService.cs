using System.Threading.Tasks;

namespace NetSL.Api.Services{
    public interface ITraficService{
        public Task<string> GetTrafiklage();
    }
}