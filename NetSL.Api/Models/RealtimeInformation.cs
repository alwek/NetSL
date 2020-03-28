using System;
using System.Collections.Generic;

namespace NetSL.Api.Models {
    public class RealtimeInformation {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public long ExecutionTime { get; set; }
        public Departure ResponseData { get; set; }
    }

    public class Departure {
        public DateTime LatestUpdate { get; set; }
        public int DataAge { get; set; }
        public List<Bus> Buses { get; set; }
        public List<Metro> Metros { get; set; }
        public List<Train> Trains { get; set; }
        public List<Tram> Trams { get; set; }
        public List<Ship> Ships { get; set; }
        public List<StopPointDeviations> StopPointDeviations { get; set; }
    }

    public class Transport {
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDestination { get; set; }
        public string GroupOfLine { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
        public List<Deviation> Deviations { get; set; }
        public string SecondaryDestinationName { get; set; }
        public string PredictionState { get; set; }
    }

    public class Deviation {
        public string Consequence { get; set; }
        public int ImportanceLevel { get; set; }
        public string Text { get; set; }
    }

    public class StopPointDeviations {
        public StopInfo StopInfo { get; set; }
        public Deviation Deviation { get; set; }
    }    

    public class StopInfo {
        public string GroupOfLine { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public string TransportMode { get; set; }
    }

    public class Bus : Transport {}

    public class Metro : Transport {}

    public class Train : Transport {}

    public class Tram : Transport {}

    public class Ship : Transport {}
}