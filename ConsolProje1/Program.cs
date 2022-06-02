using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace ConsolProje1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("CustomerId:");
            string Customerid=Console.ReadLine();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44393/weatherforecast/GetOrderDetails?customerid=" + Customerid);
            request.Method = "GET";
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }

            var OrderDetailsList = JsonSerializer.Deserialize<List<OrderDetails>>(test, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var toplam = OrderDetailsList[0].Toplam;
            

            string to = "TRY";

            string from = "USD";

            


            

            HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create($"https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={toplam}" );
            request2.Method = "GET";
            request2.Headers.Add("apikey", "GpCIgaUazOpoqTgJtCn4w7TSTsuAWPTJ");
            String test2 = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test2 = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                Console.WriteLine(test2);
            }
            
            

        }
    }
}
