using System.Collections.Generic;

namespace NetSL.Api.Models {
    public class TrafficSituation {
        public int StatusCode {get;set;}
        public string Message {get;set;}
        public long ExecutionTime {get;set;}
        public TrafficStatus ResponseData {get;set;}
    }

    public class TrafficStatus {
        public List<TrafficType> TrafficTypes {get;set;}
    }

    public class TrafficType {
        public string Name {get;set;}
        public string Type {get;set;}
        public string StatusIcon {get;set;}
        public bool Expanded {get;set;}
        public bool HasPlannedEvent {get;set;}
        public List<TrafficEvent> Events {get;set;}
    }

    public class TrafficEvent {
        public int EventId {get;set;}
        public string Message {get;set;}
        public bool Expanded {get;set;}
        public bool Planned {get;set;}
        public int SortIndex {get;set;}
        public string StatusIcon {get;set;}
        public LineNumbers LineNumbers {get;set;}
        public string TrafficLine {get;set;}
        public string EventInfoUrl {get;set;} 
    }

    public class LineNumbers {
        public bool InputDataIsOptional {get;set;}
        public string Text {get;set;}
    }
}