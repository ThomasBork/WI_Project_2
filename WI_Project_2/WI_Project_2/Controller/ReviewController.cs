using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WI_Project_2.Model;

namespace WI_Project_2.Controller
{
    public static class ReviewController
    {
        private static readonly string[] NEGATE_WORDS = new string[] { "never", "no", "nothing", "nowhere", "noone", "none", "not", "havent", "hasnt", "hadnt", "cant", "couldnt", "shouldnt", "wont", "wouldnt", "dont", "doesnt", "didnt", "isnt", "arent", "aint" };
        private static readonly char[] STOP_SYMBOLS = new char[] { '.', ',', ';', ':', '!', '?' };

        public static Review[] LoadReviews(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var reviews = new Review[lines.Length / 9 + 1];

            for (var i = 0; i < lines.Length; i += 9)
            {
                Review review = new Review();

                //review.productID = Helper.TextAfterSpace(lines[i]);
                //review.userID = Helper.TextAfterSpace(lines[i + 1]);
                //review.profileName = Helper.TextAfterSpace(lines[i + 2]);
                //review.helpfulness = Helper.TextAfterSpace(lines[i + 3]);
                review.score = float.Parse(Helper.TextAfterSpace(lines[i + 4]));
                //review.time = long.Parse(Helper.TextAfterSpace(lines[i + 5]));
                //review.summary = Helper.TextAfterSpace(lines[i + 6]);

                byte[] raw = Encoding.Default.GetBytes(Helper.TextAfterSpace(lines[i + 7]));
                review.text = Encoding.UTF8.GetString(raw);

                reviews[i / 9] = review;
            }

            return reviews;
        }

        public static void Tokenize (Review[] reviews)
        {
            var nextPrint = 1;
            var tokenized = 0;
            foreach(var review in reviews)
            {
                Tokenize(review);
                tokenized++;
                if(tokenized == nextPrint)
                {
                    nextPrint *= 2;
                    Console.WriteLine("TOKENIZED! " + tokenized + " : " + Program.sw.Elapsed.TotalSeconds);
                }
            }
        }

        public static void Tokenize(Review review)
        {
            var words = review.text.Split(' ');
            bool negate = false;
            foreach(var word in words)
            {
                if (word != "")
                {
                    review.AddToken(GetToken(word, !negate));

                    if (NEGATE_WORDS.Contains(word) ||
                       word.EndsWith("n't"))
                    {
                        negate = !negate;
                    }

                    if (STOP_SYMBOLS.Contains(word.Last()))
                    {
                        negate = false;
                        review.AddToken(word.Last().ToString());
                    }
                }
            }
            review.text = null;
        }

        private static string GetToken (string word, bool negate)
        {
            return negate ? Helper.RemoveAllChars(word, STOP_SYMBOLS) + "_NEG" : Helper.RemoveAllChars(word, STOP_SYMBOLS);
        }

        public static Dictionary<string, int> BuildVocabulary (Review[] reviews)
        {
            var vocabulary = new Dictionary<string, int>();

            foreach(var review in reviews)
            {
                foreach(var token in review.Tokens)
                {
                    if(vocabulary.ContainsKey(token.Text))
                    {
                        vocabulary[token.Text]++;
                    }
                    else
                    {
                        vocabulary[token.Text] = 1;
                    }
                }
            }

            return vocabulary;
        }
    }
}
