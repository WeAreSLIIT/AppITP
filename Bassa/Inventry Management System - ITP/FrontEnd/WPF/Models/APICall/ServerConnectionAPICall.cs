using Models.Core;
using Models.Persistence;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Models.APICall
{
    public class ServerConnectionAPICall : BaseHttpAPICall
    {
        public async Task<bool> CheckServerStatus()
        {
            try
            {
                if (!InventryMangementSystemDbContext.ConnectionCheckFirstTime)
                {
                    base._response = await this._httpClient.GetAsync($"api/counters/{InventryMangementSystemDbContext.CounterWorking.CouterNo}/branch/{InventryMangementSystemDbContext.CounterWorking.BranchID}?App={base._appID}");

                    if (base._response.IsSuccessStatusCode)
                    {
                        InventryMangementSystemDbContext.ConnectionCheckFirstTime = true;
                    }

                    Debug.WriteLine(base._response.StatusCode);
                }

                if (InventryMangementSystemDbContext.ConnectionCheckFirstTime)
                {
                    base._response = await this._httpClient.PutAsJsonAsync($"api/counters?App={base._appID}", InventryMangementSystemDbContext.CounterWorking);

                    if (base._response.IsSuccessStatusCode)
                    {
                        ServerData ServerData = await base._response.Content.ReadAsAsync<ServerData>();

                        if (!InventryMangementSystemDbContext.ConnectionToServer)
                        {
                            InventryMangementSystemDbContext.ServerDateTime.ServerUp = ServerData.ServerUp;
                            InventryMangementSystemDbContext.ServerDateTime.Time = ServerData.Time;
                        }
                        else
                        {
                            long TempGap = InventryMangementSystemDbContext.ServerDateTime.Time - ServerData.Time;

                            if (TempGap > 3 || TempGap < -3)
                                InventryMangementSystemDbContext.ServerDateTime.Time = ServerData.Time;
                        }

                        InventryMangementSystemDbContext.ConnectionToServer = true;
                        BackgroundTasks.StartBackGroundTasks();
                        return true;
                    }
                    else
                        InventryMangementSystemDbContext.ConnectionToServer = false;
                } 

                return false;
            }
            catch
            {
                InventryMangementSystemDbContext.ConnectionToServer = false;
                Debug.WriteLine("Redda");
                return false;
            }
        }
    }
}
