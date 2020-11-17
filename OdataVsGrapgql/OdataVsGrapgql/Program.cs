using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OdataVsGrapgql
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            //https://localhost:44373/odata/Students?$select=firstname&$filter=id%20eq%20%272%27
            var resp = client.GetAsync("https://localhost:44373/odata/Students?$select=firstname&$filter=id%20eq%20%272%27").Result;

            Console.WriteLine(resp.Content.ReadAsStringAsync().Result);
            Console.Read();
        }
    }
}
