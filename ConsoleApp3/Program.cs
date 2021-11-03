using System;
using System.Linq;
using TwoCaptcha.Captcha;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web;
using System.Net;
using System.Net.Http;

using Leaf.xNet;

using System.Threading.Tasks;

namespace TwoCaptcha.Examples
{
    public class ReCaptchaV2Example
    { 
        static string captcha;
        static string cokie = @"cid=iBUwLf0X; _ga=GA1.2.649249011.1604941716; bnc-uuid=5f373dd0-5fe9-4cc8-9337-7f27ef4e6cc6; source=yandex.ru; afUserId=de904750-dc56-47e7-8135-b8be739f40ab-o; _hjid=bebc03ff-be03-4f1e-9825-47232b774f5d; __ssid=56373b9ebad26292a2bd25b7b849edf; lastRskxRun=1617007613382; rskxRunCookie=0; rCookie=5bs8mrkvh72mrofo66txekmuckzpk; userPreferredCurrency=USD_USD; nft-init-compliance=true; crypto_deposit_refactor=1; defaultMarketTab=spot; fiat-prefer-currency=RUB; campaign=web_share_link; theme=dark; __BINANCE_USER_DEVICE_ID__={""807b6dca480ea4a0b3d94c80e53a8341"":{""date"":1633777072195,""value"":""1633777072562GAWEbTERcCsPM9UOH56""}}; sensorsdata2015jssdkcross=%7B%22distinct_id%22%3A%2217080186%22%2C%22first_id%22%3A%22175adfb1ada810-0c0a3abdaddb2b-230346d-2073600-175adfb1adb94d%22%2C%22props%22%3A%7B%22%24latest_traffic_source_type%22%3A%22%E7%9B%B4%E6%8E%A5%E6%B5%81%E9%87%8F%22%2C%22%24latest_search_keyword%22%3A%22%E6%9C%AA%E5%8F%96%E5%88%B0%E5%80%BC_%E7%9B%B4%E6%8E%A5%E6%89%93%E5%BC%80%22%2C%22%24latest_referrer%22%3A%22%22%2C%22%24latest_utm_campaign%22%3A%22web_share_link%22%7D%2C%22%24device_id%22%3A%22175adfb1ada810-0c0a3abdaddb2b-230346d-2073600-175adfb1adb94d%22%7D; home-ui-ab=B; BNC_FV_KEY=31fe01a5643ba077a57f5322559e593fc9d9b090; BNC_FV_KEY_EXPIRE=1636011535047; cr00=794D670F3CA9DE92BAA411D339B54C3D; d1og=web.17080186.2742D3FE08FB262146D28B8430ED2D6C; r2o1=web.17080186.D0BA7B7C64B9A0A7811B4C24B3E835D8; f30l=web.17080186.367E2BCD4260E592AD506B02D88D87A3; logined=y; lang=en; p20t=web.17080186.C805771B072DD6251AB66AC2E06552AD";
        static string crsf = "dea230914b524f4247eb748ddb6d9f3b";
        static async Task Main(string[] args)
        {
            Console.WriteLine(crsf);
            List<string> cat = File.ReadAllLines("DragonMainlandVoucher.txt").ToList();

            cat=cat.OrderBy(a => Guid.NewGuid()).ToList();

            Console.WriteLine("введи каптчу");
            captcha = Console.ReadLine();

            Console.WriteLine("gogogo");
            int count = 0;


            try
            {
                while (true)
                {
                    if (DateTime.Now.Second == 58)
                    {
                        new Thread(() =>
                        {
                            for (int i = 0; i < 120; i++)
                            {
                                meth(captcha, cat[i]);
                            }
                        }).Start();

                        Thread.Sleep(100);

                        new Thread(() =>
                        {
                            for (int i = 120; i < 340; i++)
                            {
                                meth(captcha, cat[i]);
                            }
                        }).Start();

                         


                    }
                }
                
            }
            catch
            {

            }
                
            
        }




        static async Task meth(string x_token, string productId)
        { 


            Console.WriteLine(DateTime.Now);
                var url = "https://www.binance.com/bapi/nft/v1/private/nft/nft-trade/order-create";
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);


                httpRequest.Method = "POST";

                httpRequest.Headers["clienttype"] = "web";
                httpRequest.ContentType = "application/json";
                httpRequest.Headers["cookie"] = cokie;
                httpRequest.Headers["csrftoken"] = crsf;
                httpRequest.Headers["x-nft-checkbot-sitekey"] = "6LeUPckbAAAAAIX0YxfqgiXvD3EOXSeuq0OpO8u_";
                httpRequest.Headers["x-nft-checkbot-token"] = x_token;

                var data = @"{""amount"":""0.5"",""productId"":""5972053"",""tradeType"":0}";
                data = data.Replace("5972053", productId);
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }
                HttpWebResponse httpResponse = null;
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();


                var de = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();

                Console.WriteLine(httpResponse.StatusCode);
                Console.WriteLine(de.ToString() + productId);
               

        }
    }
}
