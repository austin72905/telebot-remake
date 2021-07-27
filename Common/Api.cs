using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace TelebotRemake.Common
{
    public static class Api
    {
        public static void RobotApi(int chat_id,string text)
        {
            Task.Run(async ()=>
            {
                var httpclient = new HttpClient();
                string baseUrl = "https://api.telegram.org/bot";
                var postdata = new Dictionary<string, string>()
                {
                    { "chat_id",chat_id.ToString()},
                    { "text",text},
                    { "parsr_mode","HTML"}
                };
                string url = $"{baseUrl}/sendMessage";

                var content = new FormUrlEncodedContent(postdata);
                var response = await httpclient.PostAsync(url, content);
            });
        } 
    }
}