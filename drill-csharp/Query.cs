using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace drill_csharp
{
    public class QueryResponse
    {
        public string[] Columns { get; set; }

        public dynamic[] Rows { get; set; }

        public dynamic[] Metadata { get; set; }

        public string QueryId { get; set; }
    }
    public class Query
    {
        private DrillBit _drillbit;

        public Query(DrillBit drillbit)
        {
            _drillbit = drillbit;
        }

        public async Task<QueryResponse> Execute(string sql)
        {
            var url = "query.json";
            var query = new Dictionary<string, string>();
            query.Add("queryType", "SQL");
            query.Add("query", sql);

            var result = await _drillbit.PostRequest(url, query);
            var response = JsonConvert.DeserializeObject<QueryResponse>(result);
            return response;
        }
    }
}