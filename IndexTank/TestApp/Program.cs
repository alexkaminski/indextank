using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IndexTank.Indexing indexer = new IndexTank.Indexing();
            indexer.PutDocument(new IndexTank.PostValues()
            {
                fields = new Dictionary<string, string> { { "value", "test" } },
                docid = "test2",
                variables = new Dictionary<string, double> { }
            }, "Trips"
            );
        }
    }
}
