using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_Project_2.Model
{
    public class Review
    {
        //public string productID;
        //public string userID;
        //public string profileName;
        //public string helpfulness;
        private float _score;
        public float score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                UpdateClass(_score);
            }
        }
        //public long time;
        //public string summary;
        public string text;
        public List<Token> Tokens = new List<Token>();

        public ClassEnum Class { get; set; }

        public void UpdateClass(float value)
        {
            if(value <= 2)
            {
                Class = ClassEnum.Negative;
            }
            else if(value >= 4)
            {
                Class = ClassEnum.Positive;
            }
            else
            {
                Class = ClassEnum.Neutral;
            }
        }

        public void AddToken(string s)
        {
            if(!Token.AllTokens.ContainsKey(s))
            {
                Token.AllTokens.Add(s, new Token(s));
            }
            var token = Token.AllTokens[s];
            Tokens.Add(token);
            token.Occurances++;
            Classes.IncrementUse(Class, token);
        }
    }
}
