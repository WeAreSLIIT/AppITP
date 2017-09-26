using System.Net.Http;
using System.Threading.Tasks;

namespace Models.APICall
{
    public class ServerConnectionAPICall : BaseHttpAPICall
    {
        public async Task<bool> CheckServerStatus()
        {
            //HttpResponseMessage Respose = await base._httpClient.PutAsync("api/counters/");

            return false;
        }
    }
}
