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

namespace WindowsFormsApp1
{
    class WebServiceCall: IWebServiceCall
    {


        public void POST(Statistics statsToSave)
        {

            try
            {
                string webAddr = "http://localhost:56233/api/Match";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\n" + "\"teamOne\": " + "\"" + statsToSave.name1.ToString() + "\",\n" + "\"teamTwo\": " + "\"" + statsToSave.name2.ToString() + "\",\n" + "\"scoreOne\": " + "\"" + statsToSave.score1 + "\",\n" + "\"scoreTwo\": " + "\"" + statsToSave.score2 + "\",\n" + "\"date\": " + "\"" + statsToSave.date.ToString() + "\",\n" + "}";

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

        public void GET()
        {
            string url = @"http://localhost:56233/api/Match";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string json = reader.ReadToEnd();
                Debug.WriteLine(json);
                List<Matches> items = JsonConvert.DeserializeObject<List<Matches>>(json);

            }



        }
    }

    public class Matches
    {
        public int id { get; set; }
        public string teamOne { get; set; }
        public string teamTwo { get; set; }
        public int? scoreOne { get; set; }
        public int? scoreTwo { get; set; }
        public DateTime? date { get; set; }
    }
}
