using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetSL.Api.Models;
using NetSL.Api.Settings;
using NetSL.Api.Utils;

namespace NetSL.Api.Services {
    public class TrafficService : ITrafficService
    {
        private readonly HttpClient httpClient;
        private readonly string trafiklageKey;
        private readonly string reseplanerareKey;
        private readonly string realtidsinformationKey;
        private readonly string storningsinformationKey;

        public TrafficService(HttpClient client, IKeySettings settings){
            httpClient = client;
            trafiklageKey = settings.TrafiklageKey;
            reseplanerareKey = settings.ReseplanerareKey;
            realtidsinformationKey = settings.RealtidsinformationKey;
            storningsinformationKey = settings.StorningsinformationKey;
        }

        public async Task<TrafficSituation> GetTrafficSituation()
        {
            try{
                string query = string.Empty;
                string content = null;
                Uri uri = HttpClientUtil.CreateUri(httpClient.BaseAddress, trafiklageKey, "json", "trafficsituation", null);
                HttpRequestMessage request = HttpClientUtil.CreateHttpRequestMessage(HttpMethod.Get, uri, content);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                object result = await HttpClientUtil.ReadHttpResponseMessage<TrafficSituation>(response);

                if(result is TrafficSituation)
                    return result as TrafficSituation;
                else if(result is null)
                    return CreateTrafficSituationError("Got null from response.");
                else
                    return null;
            } catch(Exception ex){
                return CreateTrafficSituationError(ex.Message);
            }
        }

        private TrafficSituation CreateTrafficSituationError(string message){
            return new TrafficSituation {
                StatusCode = -1,
                Message = message
            };
        }

        public async Task<RealtimeInformation> GetRealtimeInformation(int siteId, int timeWindow){
            try{
                string query = $"&siteid={siteId}&timewindow={timeWindow}";
                string content = null;
                Uri uri = HttpClientUtil.CreateUri(httpClient.BaseAddress, realtidsinformationKey, "json", "realtimedeparturesV4", query: query);
                HttpRequestMessage request = HttpClientUtil.CreateHttpRequestMessage(HttpMethod.Get, uri, content);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                object result = await HttpClientUtil.ReadHttpResponseMessage<RealtimeInformation>(response);

                if(result is RealtimeInformation)
                    return result as RealtimeInformation;
                else if(result is null)
                    return CreateRealtimeInformationError("Got null from response.");
                else 
                    return null;
            } catch(Exception ex){
                return CreateRealtimeInformationError(ex.Message);
            }
        }

        private RealtimeInformation CreateRealtimeInformationError(string message){
            return new RealtimeInformation {
                StatusCode = -1,
                Message = message
            };
        }
    }
}