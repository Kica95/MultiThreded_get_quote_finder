// See https://aka.ms/new-console-template for more information

using _16_QuoteFinder.DataAccess.Mock;
using _16_QuoteFinder.Models;
using MultiThreded_get_quote_finder;
using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;

try
{
    Console.WriteLine("Please input number of pages to search for");

    string NumPages_string = Console.ReadLine();

    if (!int.TryParse(NumPages_string, out int NumPages))
    {
        Console.WriteLine("Invalid input, input must be an integer !!!");
    }

    Console.WriteLine("Please input the limit of quotes to search per page.");

    string limit_string = Console.ReadLine();

    if (!int.TryParse(limit_string, out int limit))
    {
        Console.WriteLine("Invalid input, input must be an integer !!!");
    }

    Console.WriteLine("Please input the the word to search for in the quotes.");
    string word_to_search = Console.ReadLine();

    List<string> data = Utilities.FetchDataAsync(NumPages, limit);

    Parallel_word_search search = new Parallel_word_search(data, word_to_search);

    await search.PrintFoundIFFound();

}
catch (Exception ex) 
{
    Console.WriteLine(ex.Message);  
}



Console.WriteLine("Program has finished");
