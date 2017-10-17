using Models.APICall.Resources;
using Models.Core;
using Models.Persistence;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Models.APICall
{
    public class TableVersionAPICall : BaseHttpAPICall
    {
        public async Task<ICollection<TableVersion>> GetTableVersionData()
        {
            try
            {
                if (InventryMangementSystemDbContext.ConnectionCheckFirstTime)
                {
                    base._response = await this._httpClient.GetAsync($"api/invoices/tableversions?App={base._appID}");

                    if (base._response.IsSuccessStatusCode)
                    {
                        ICollection<TableVersionResource> TableVersionResources = await base._response.Content.ReadAsAsync<ICollection<TableVersionResource>>();

                        if (TableVersionResources == null || TableVersionResources.Count == 0)
                            return null;

                        ICollection<TableVersion> TableVersions = new List<TableVersion>();
                        foreach (TableVersionResource TableVersionResource in TableVersionResources)
                        {
                            TableVersions.Add(new TableVersion()
                            {
                                Table = (DatabaseTable)TableVersionResource.ID,
                                Time = TableVersionResource.Version
                            });
                        }

                        Debug.WriteLine("WPF -> VersionTable Received");
                        return TableVersions;
                    }
                    else
                        return null;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
