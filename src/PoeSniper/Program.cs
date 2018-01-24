using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System.Threading;
using System.IO;

namespace PoESniper
{
    class Program
    {
        public static string next_change_id;
        public static int count = 1;

        public static void Main()
        {

            next_change_id = "76110135-79997801-74953372-87003285-80920382"; //SEED SEARCH TO RECENT

            Console.WriteLine("Import Current next_change_id: ");
            next_change_id = Console.ReadLine();

            Console.WriteLine("Performing Search #:" + count++ + " Id: " + next_change_id);
            //Timer Timer = new Timer(QueryStashTabs, next_change_id, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(30));

            
            while (true)
            {
                Thread.Sleep(1000);
                QueryStashTabs(next_change_id);
            }
        }



        private static void QueryStashTabs(object state)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            try
            {


                var client = new RestClient();
                client.BaseUrl = new Uri("http://www.pathofexile.com/api/public-stash-tabs");

                var request = new RestRequest(Method.GET);

                if (next_change_id != null)
                {
                    request.Resource = next_change_id;
                }
                request.RequestFormat = DataFormat.Json;

                var response = client.Execute(request);
                timer.Stop();
                var elapsedMs = timer.ElapsedMilliseconds;

                Console.WriteLine("Request took " + elapsedMs + " ms");
                timer = System.Diagnostics.Stopwatch.StartNew();
                JsonSerializer jsonSerializer = new JsonSerializer();
                JsonDeserializer json = new JsonDeserializer();




                var content = json.Deserialize<PublicStashTabs>(response);

                timer.Stop();
                elapsedMs = timer.ElapsedMilliseconds;

                timer = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine("Deserialization took " + elapsedMs + " ms");
                next_change_id = content.next_change_id;
                int itemCount = 0;
                foreach (StashTab stash in content.stashes)
                {
                    foreach (Items item in stash.items)
                    {
                        //STRIP LOCALIZATION INFO, ENGLISH ONLY APPLICATION
                        if (item.league == "Hardcore Harbinger")
                        {
                            if (item.name.StartsWith("<<"))
                            {
                                item.name = item.name.Substring(28);
                            }
                            else if (item.typeLine.StartsWith("<<"))
                            {
                                item.typeLine.Substring(27);

                            }
                            if (item.name.ToLower() == "rise of the phoenix"|| item.name.ToLower() == "the flow untethered" || item.typeLine.ToLower() == "rise of the phoenix"  || item.typeLine.ToLower() == "the flow untethered")
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(new { stash.lastCharacterName, item.name, item.typeLine, item.note }, Formatting.Indented));
                            }
                        }
                    }
                    itemCount += stash.items.Count;
                }
                timer.Stop();
                elapsedMs = timer.ElapsedMilliseconds;
                Console.WriteLine("Search took: " + elapsedMs + " ms");
                Console.WriteLine(content.stashes.Count + " Stash tabs searched. ");
                Console.WriteLine(itemCount + " Items searched.");
                Console.WriteLine("Performing Search #:" + count++ + " Id: " + next_change_id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool IsEscapeCharacter(int character)
        {
            if (character == 27)
            {
                return true;
            }
            return false;
        }
    }
}