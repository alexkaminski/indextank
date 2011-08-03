using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace IndexTank
{
    public class Indexing
    {
        public void PutDocument(PostValues value, string indexName)
        {
            string username = System.Configuration.ConfigurationManager.AppSettings["Username"];
            string password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            string url = System.Configuration.ConfigurationManager.AppSettings["URL"];

            string postData = Serilizer.SerializePostValue(value);
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/v1/indexes/" + indexName + "/docs");

            byte[] credentialBuffer = new UTF8Encoding().GetBytes(username + ":" + password);
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = byte1.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byte1, 0, byte1.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string returnString = response.StatusCode.ToString();

        }

        public void PutDocuments(List<PostValues> values, string indexName)
        {
            string username = System.Configuration.ConfigurationManager.AppSettings["Username"];
            string password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            string url = System.Configuration.ConfigurationManager.AppSettings["URL"];

            string postData = Serilizer.SerializePostValues(values);
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/v1/indexes/" + indexName + "/docs");

            byte[] credentialBuffer = new UTF8Encoding().GetBytes(username + ":" + password);
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = byte1.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byte1, 0, byte1.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string returnString = response.StatusCode.ToString();
        }

    }

    public class PostValues
    {
        public string docid { get; set; }
        public Dictionary<string, string> fields { get; set; }
        public Dictionary<string, double> variables { get; set; }
    }
}
