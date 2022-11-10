using System.Net.Http;
using System.Runtime.InteropServices;

namespace iMedicalChain
{
    public static class Connection
    {
        [DllImport("wininet.dll")]
        public extern static bool InternetGetConnectedState(out int description, int reservedValue);

        public static bool IsInternetAvailable()
        {
            int description;
            return InternetGetConnectedState(out description, 0);
        }
        public async static void PostTextInfoMessage(string text)
        {
            if (IsInternetAvailable())
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
}
