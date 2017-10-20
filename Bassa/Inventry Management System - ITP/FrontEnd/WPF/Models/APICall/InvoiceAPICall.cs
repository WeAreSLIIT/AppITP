using Models.APICall.Resources;
using Models.Core;
using Models.Persistence;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Models.APICall
{
    public class InvoiceAPICall : BaseHttpAPICall
    {
        public async Task<bool> SendInvoice(Invoice Invoice)
        {
            try
            {
                if (InventryMangementSystemDbContext.ConnectionCheckFirstTime)
                {
                    base._response = await this._httpClient.PostAsJsonAsync($"api/invoices?App={base._appID}", Invoice);

                    if (base._response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("WPF -> InvoiceData Sent");
                        return true;
                    }
                    else
                        return false;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
