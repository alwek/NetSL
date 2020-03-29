using System.Collections.Generic;

namespace NetSL.Api.Models.Stations {
    public class Stations {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public long ExecutionTime { get; set; }
        public List<Site> ResponseData { get; set; }
    }

    public class Sites {
        public List<Site> SiteList { get; set; }
    }

    public class Site {
        public string Name { get; set; }
        public string SiteId { get; set; }
        public string Type { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }
}