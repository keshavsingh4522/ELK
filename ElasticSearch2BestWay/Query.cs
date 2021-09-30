using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch2BestWay
{
    public static class Query
    {
        public const string fetchAllRecords = @"{""exists"":{""field"": ""name""}}";
    }
}
