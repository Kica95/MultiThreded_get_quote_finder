using _16_QuoteFinder.DataAccess.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreded_get_quote_finder;

    public class QuotesApiDataReader : IQuotesApiDataReader
    {
       private HttpClient httpClient = new HttpClient();

        public async Task<string> ReadAsync(int limit, int page)
        {
            var endpoint = $"https://quote-garden.onrender.com/api/v3/quotes?limit={limit}&page={page}";

            HttpResponseMessage response = await httpClient.GetAsync(endpoint);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message + "Turning to mock data API!");
                MockQuotesApiDataReader mockQuotesApiDataReader = new MockQuotesApiDataReader();
                return await mockQuotesApiDataReader.ReadAsync(limit, page);
            }

            return await response.Content.ReadAsStringAsync();
        }


        public void Dispose()
        {
            httpClient.Dispose();
        }

    }
  
    

