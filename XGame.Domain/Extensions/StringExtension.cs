using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToMD5(this string passWord)
        {
            if (string.IsNullOrEmpty(passWord)) return "";
            var password = (passWord += "aaa");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));
            return sbString.ToString();
        }
    }
}
