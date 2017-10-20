using Models.APICall.Resources;
using Models.Core;
using Models.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Models.APICall
{
    public class ProductAPICall : BaseHttpAPICall
    {
        public async Task<ICollection<Product>> CheckNewProducts()
        {
            try
            {
                if (InventryMangementSystemDbContext.ConnectionCheckFirstTime)
                {
                    base._response = await this._httpClient.GetAsync($"api/invoices/products?App={base._appID}");

                    if (base._response.IsSuccessStatusCode)
                    {
                        ICollection<ProductResource> ProductResources = await base._response.Content.ReadAsAsync<ICollection<ProductResource>>();

                        if (ProductResources == null || ProductResources.Count == 0)
                            return null;

                        ICollection<Product> Products = new List<Product>();
                        foreach (ProductResource ProductResource in ProductResources)
                        {
                            Products.Add(new Product()
                            {
                                ID = ProductResource.ID,
                                Name = ProductResource.Name,
                                Bracode = ProductResource.Bracode,
                                Price = ProductResource.Price,
                                //need to change
                                Type = ProductResource.Type == 2 ? ProductType.Unit : ProductType.Measurable
                            });
                        }

                        Debug.WriteLine("CheckNewProducts() -> ProductData Received");
                        return Products;
                    }
                    else
                    {
                        Debug.WriteLine($"CheckNewProducts() -> ProductData Not Received {base._response.StatusCode}");
                        return null;
                    }
                }

                Debug.WriteLine($"CheckNewProducts() -> ProductData Not Received, No first time connections.");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CheckNewProducts() -> {ex.ToString()}");
                return null;
            }
        }
    }
}
