using _16_QuoteFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace MultiThreded_get_quote_finder
{
    public static class Utilities
    {

        public static List<string> FetchDataAsync(int NumPages, int limit)
        {
            QuotesApiDataReader quotesApiDataReader = new QuotesApiDataReader();
            var data = new List<string>();
            var tasks = new List<Task<string>>();
            for (int i = 0; i < NumPages; i++)
            {
                tasks.Add(quotesApiDataReader.ReadAsync(limit, i + 1));
            }
            Task.WaitAll(tasks.ToArray());
            data = tasks.Select(t => t.Result).ToList();
            return data;
        }
       

        public static bool ContainsWord(Datum quote, string? word_to_search)
        {
             return quote.quoteText.
                Split(new char [] {' ', '.',',','!','?',':',';'},StringSplitOptions.RemoveEmptyEntries).
                Any(potential => potential.Equals(word_to_search,StringComparison.OrdinalIgnoreCase));
            
        }

        public static void QuoteFinder(string singlePage, string word_to_search)
        {
            var quote =
               JsonSerializer.Deserialize<Root>(singlePage).data.
               Where(quote => ContainsWord(quote, word_to_search)).
               OrderBy(quotes => quotes.quoteText.Length).FirstOrDefault();

            if (quote == null)
            {
                Console.WriteLine(word_to_search + " not found");
            }
            else
            {
                Console.WriteLine(quote.quoteText);
            }

        }
    }
}
