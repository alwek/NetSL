using System;
using System.Collections.Generic;

namespace NetSL.Api.Models.Departure {
    public class DepartureBoard {
        public List<Departure> Departures { get; set; }
    }

    public class Departure {
        public string RtTime { get; set; }
        public string RtTrack { get; set; }
        public string RtDepTrack { get; set; }
        public DateTime RtDate { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string Stop { get; set; }
        public string StopId { get; set; }
        public string StopExtId { get; set; }
        public string Type { get; set; }
        public string TransportNumber { get; set; }
        public string TransportCategory { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public Product Product { get; set; }
        public Stops Stops { get; set; }
    }

    public class Product {
        public string Name { get; set; }
        public string Operator { get; set; }
        public int Num { get; set; }
        public string CatOutS { get; set; }
        public string CatOutL { get; set; }
        public int CatOutCode { get; set; }
    }

    public class Stops {
        public List<Stop> StopList { get; set; }
    }

    public class Stop{
        public string Name { get; set; }
        public string ArrTime { get; set; }
        public string ArrDate { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Id { get; set; }
        public string ExtId { get; set; }
        public int RouteIdx { get; set; }
    }
}