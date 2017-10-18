using Models.Core;
using Models.Persistence;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Models.APICall
{
    public abstract class BaseHttpAPICall
    {
        private string _baseAddress;
        protected HttpClient _httpClient;
        protected string _appID;
        protected HttpResponseMessage _response;

        protected Counter _counter;

        public BaseHttpAPICall()
        {
            this._counter = InventryMangementSystemDbContext.CounterWorking;

            this._appID = "csbwpfapp";

            this._httpClient = new HttpClient();
            this._baseAddress = InventryMangementSystemDbContext.BaseAddressToServer;
            this._httpClient.BaseAddress = new Uri(this._baseAddress);
            this._httpClient.DefaultRequestHeaders.Accept.Clear();
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            this._httpClient.Dispose();
        }
    }
}
