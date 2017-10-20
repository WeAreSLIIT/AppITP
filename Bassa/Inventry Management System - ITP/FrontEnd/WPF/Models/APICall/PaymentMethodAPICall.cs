using Models.Core;
using Models.Persistence;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Models.APICall
{
    public class PaymentMethodAPICall : BaseHttpAPICall
    {
        public async Task<ICollection<PaymentMethod>> CheckNewPaymentMethods()
        {
            try
            {
                if (InventryMangementSystemDbContext.ConnectionCheckFirstTime)
                {
                    base._response = await this._httpClient.GetAsync($"api/PaymentMethods");

                    if (base._response.IsSuccessStatusCode)
                    {
                        ICollection<PaymentMethod> PaymentMethods = await base._response.Content.ReadAsAsync<ICollection<PaymentMethod>>();

                        if (PaymentMethods == null || PaymentMethods.Count == 0)
                            return null;

                        return PaymentMethods;
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
