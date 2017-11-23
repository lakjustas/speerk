using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;
using System.Json;
using System.Runtime.Serialization.Json;

namespace SpeerkMobileApp
{
    class WebServiceCall
    {

        public void POST(Matches statsToSave)
        {

            try
            {
                string webAddr = "http://192.168.0.103/MyService/api/Match";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\n" + "\"teamOne\": " + "\"" + statsToSave.teamOne.ToString() + "\",\n" + "\"teamTwo\": " + "\"" + statsToSave.teamTwo.ToString() + "\",\n" + "\"scoreOne\": " + "\"" + statsToSave.scoreOne + "\",\n" + "\"scoreTwo\": " + "\"" + statsToSave.scoreTwo + "\",\n" + "\"date\": " + "\"" + statsToSave.date.ToString() + "\",\n" + "}";

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

        public List<Matches> GET()
        {
            /*
            string url = @"http://localhost:56233/api/Match";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string json = reader.ReadToEnd();

                List<Matches> matchStats = JsonConvert.DeserializeObject<List<Matches>>(json);
  
                return matchStats;

            }
            */
            List<Matches> match = null ;

            return match;

        }

    }
}