using System.Net.Http;
using System.Runtime.InteropServices;

namespace iMedicalChain
{
    public static class Connection
    {
       
        public async static void PostTextInfoMessage(string text)
        {
               try
                {
                    HttpClient client = new HttpClient();
                    string BaseUrl = $"https://api.telegram.org/bot5662480531:AAEgTvOklk6gNAKdA1LPRHU7ioUyeLgAW2s/sendMessage?chat_id=-1001667923670&text=" + text;
                    var result = await client.GetAsync(BaseUrl);
                }
                catch
                {


                }

            }

        }
    }
