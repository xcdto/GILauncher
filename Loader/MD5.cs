using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Loader
{
    public class Md5Hash
    {
        public static Process[] procs;
        public static bool Md5Protect(string source, string fileHost)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                string has2 = (fileHost);
                bool hash3 = VerifyMd5Hash(md5Hash, source, has2);
                if (VerifyMd5Hash(md5Hash, source, has2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static string GetMd5Hash(MD5 md5Hash, string source)
        {
            FileStream file = new FileStream(source, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }


        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {

            string hashOfInput = GetMd5Hash(md5Hash, input);


            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

    }
}
