using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpeerkMobileApp
{
    public class WebServiceCall : IWebServiceCall
    {

        public void POST(Match statsToSave)

        {

            try
            {
                string webAddr = @"http://speerkservices.azurewebsites.net/api/Match";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(statsToSave);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    Console.WriteLine(responseText);

                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }



        }


        public List<Match> GET()
        {
            string url = @"http://speerkservices.azurewebsites.net/api/Match";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string json = reader.ReadToEnd();

                    List<Match> matchStats = JsonConvert.DeserializeObject<List<Match>>(json);
                    return matchStats;

                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            


        }

        public Match GET(int id)
        {
            Match match;
            string url = "http://speerkservices.azurewebsites.net/api/Match" + id.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string json = reader.ReadToEnd();

                match = JsonConvert.DeserializeObject<Match>(json);
                return match;

            }
        }
    }
}

