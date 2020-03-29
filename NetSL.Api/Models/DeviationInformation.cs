using System;
using System.Collections.Generic;

namespace NetSL.Api.Models.DeviationInformation {
    public class DeviationInformation {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public long ExecutionTime { get; set; }
        public List<Deviation> ResponseData { get; set; }
    }

    public class Deviation {
        public DateTime Created { get; set; }
        public bool MainNews { get; set; }
        public int SortOrder { get; set; }
        public string Header { get; set; }
        public string Details { get; set; }
        public string Scope { get; set; }
        public int DevCaseGid { get; set; }
        public int DevMessageVersionNumber { get; set; }
        public string ScopeElements { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime UpToDateTime { get; set; }
        public DateTime Updated { get; set; }
    }
}