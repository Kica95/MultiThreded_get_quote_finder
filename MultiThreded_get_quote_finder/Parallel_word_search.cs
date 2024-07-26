using _16_QuoteFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MultiThreded_get_quote_finder
{
    public class Parallel_word_search
    {
        List<string> _quotes;
        string _searchTerm;

        public Parallel_word_search(List<string> quotes, string searchTerm)
        {
            _quotes = quotes;
            _searchTerm = searchTerm;
        }

        public async Task PrintFoundIFFound()
        {

          var tasks = _quotes.Select(page => Task.Run(()=>Utilities.QuoteFinder(page,_searchTerm)));
          await Task.WhenAll(tasks.ToArray());
            //Parallel.ForEach(_quotes, page => Utilities.QuoteFinder(page, _searchTerm));
        }
        

        
    }
}

   