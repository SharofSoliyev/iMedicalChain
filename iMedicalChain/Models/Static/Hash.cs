using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace iMedicalChain.Models.Static
{
    public static class Hash
    {
        public  static string getHash(string ts, string dat, string prvHash, int nonce)
        {

            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(ts + dat + prvHash + nonce))
                    .Select(item => item.ToString("x2"))); ;
            }
        }
    }
}
