using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreded_get_quote_finder
{
    internal interface IQuotesApiDataReader
    {
        Task<string> ReadAsync(int page, int limit);
    }
}
