using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_Project_2.Controller
{
    public static class Helper
    {
        public static string TextAfterSpace (string s)
        {
            return s.Substring(s.IndexOf(' ') + 1);
        }

        public static string RemoveAllChars (string s, char[] removeStrings)
        {
            var sb = new StringBuilder();
            foreach(var c in s)
            {
                if(!removeStrings.Contains(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
