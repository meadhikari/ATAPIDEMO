using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JulMar.Atapi;
using System.Threading.Tasks;

namespace TAPITEST101
{
    class Program
    {
        static void Main(string[] args)
        {
           TapiManager tapi = new TapiManager("sample");
           tapi.Initialize();

            //listener goes here
           String reply = makeRqeusest("apiurl", "phone_number");



        }

        public static String makeRqeusest(String url, String message)
        {
            // this is what we are sending
            string post_data = message;

            // this is where we will send it
            string uri = url;

            // create a request
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)
            System.Net.WebRequest.Create(uri); request.KeepAlive = false;
            request.ProtocolVersion = System.Net.HttpVersion.Version10;
            request.Method = "POST";

            // turn our request string into a byte stream
            byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

            // this is important - make sure you specify type this way
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            System.IO.Stream requestStream = request.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            // grab the response and return
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            String result = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;
        }
            
    }
}
