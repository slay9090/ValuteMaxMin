using System;
using System.Net;


namespace ValuteMaxMin.DB
{
    class GetHttpData
    {
        private string UrlToExchangeData { get; set; }

        public GetHttpData(string _urlToExchangeData) {
            UrlToExchangeData = _urlToExchangeData;
        }

        public string GetDocumentContents() {

     WebClient client = new WebClient();

            try
            {             
                string downloadString = client.DownloadString(UrlToExchangeData);
                return downloadString;
            }

            catch (HttpListenerException ex)
            {
                Console.WriteLine("Error http request: " + ex);
                return null;
            }
            finally {
                client.Dispose();
            }
        }

    }
}
