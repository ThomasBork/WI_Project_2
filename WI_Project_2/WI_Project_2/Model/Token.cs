using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_Project_2.Model
{
    public class Token
    {
        public bool IsPositive { get; set; }
        public string Text { get; set; }

        public Token (string text, bool isPositive)
        {
            this.Text = text;
            this.IsPositive = isPositive;
        }
    }
}
