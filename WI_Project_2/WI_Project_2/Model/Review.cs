using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_Project_2.Model
{
    public class Review
    {
        public string ProductID { get; set; }
        public string UserID { get; set; }
        public string ProfileName { get; set; }
        public string Helpfulness { get; set; }
        public float Score { get; set; }
        public long Time { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public List<Token> Tokens { get; set; }

        public Review ()
        {
            this.Tokens = new List<Token>();
        }
    }
}
