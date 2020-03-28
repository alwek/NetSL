using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetSL.Api.Settings;
using NetSL.Api.Utils;

namespace NetSL.Api.Services {
    public class TraficService : ITraficService
    {
        private readonly HttpClient httpClient;
        private readonly string trafiklageKey;
        private readonly string reseplanerareKey;
        private readonly string realtidsinformationKey;
        private readonly string storningsinformationKey;

        public TraficService(HttpClient client, IKeySettings settings){
            httpClient = client;
            trafiklageKey = settings.TrafiklageKey;
            reseplanerareKey = settings.ReseplanerareKey;
            realtidsinformationKey = settings.RealtidsinformationKey;
            storningsinformationKey = settings.StorningsinformationKey;
        }

        public async Task<string> GetTrafficSituation()
        {
            try{
                Uri uri = HttpClientUtil.CreateUri(httpClient.BaseAddress, trafiklageKey, "json", "trafficsituation", null);
                string content = null;
                HttpRequestMessage request = HttpClientUtil.CreateHttpRequestMessage(HttpMethod.Get, uri, content);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                object result = await HttpClientUtil.ReadHttpResponseMessage<string>(response);

                return result as string;
            } catch(Exception ex){
                //log info
                throw ex;
            }
        }
    }
}