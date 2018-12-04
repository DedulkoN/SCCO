
using System.Text;
using System.Security.Cryptography;

namespace AcsessSCCO
{
    static class ClassCipler
    {
        public static string GetHashString(string s)
        {
           
            byte[] bytes = Encoding.Unicode.GetBytes(s);         
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty; 
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
