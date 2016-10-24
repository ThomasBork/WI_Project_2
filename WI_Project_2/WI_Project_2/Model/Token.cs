using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_Project_2.Model
{
    public class Token
    {
        public static Dictionary<string, Token> AllTokens = new Dictionary<string, Token>();
        public string Text { get; set; }
        public int Occurances { get; set; }
        public Token(string text)
        {
            this.Text = text;
            this.Occurances = 0;
        }
    }
}
