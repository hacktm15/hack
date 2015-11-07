using System.Security.Cryptography;
using System.Text;

namespace FestivalGatherer.Utilities
{
    public static class HmcSha1
    {
        public static string Hash2(string apiKey, string secretkey, string querry)
        {
            var composeQuerry = string.Format("/events?{0}&key={1}", querry, apiKey);
            var keyByte = Encoding.ASCII.GetBytes(secretkey);
            using (var hmacsha1 = new HMACSHA1(keyByte))
            {
                hmacsha1.ComputeHash(Encoding.ASCII.GetBytes(composeQuerry));
                return "http://api.festivalslab.com" + composeQuerry + "&signature=" + ByteToString(hmacsha1.Hash).ToLower();
            }
        }
        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
        }  
    }
}