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

        public static List<Review> LoadReviews(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var reviews = new List<Review>();

            for (var i = 0; i < lines.Length; i += 9)
            {
                Review review = new Review();

                review.ProductID = Helper.TextAfterSpace(lines[i]);
                review.UserID = Helper.TextAfterSpace(lines[i + 1]);
                review.ProfileName = Helper.TextAfterSpace(lines[i + 2]);
                review.Helpfulness = Helper.TextAfterSpace(lines[i + 3]);
                review.Score = float.Parse(Helper.TextAfterSpace(lines[i + 4]));
                review.Time = long.Parse(Helper.TextAfterSpace(lines[i + 5]));
                review.Summary = Helper.TextAfterSpace(lines[i + 6]);
                review.Text = Helper.TextAfterSpace(lines[i + 7]);

                reviews.Add(review);
            }

            return reviews;
        }

        public static void Tokenize (List<Review> reviews)
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
            var words = review.Text.Split(' ');
            bool negate = false;
            foreach(var word in words)
            {
                if (word != "")
                {
                    review.Tokens.Add(new Token(Helper.RemoveAllChars(word, STOP_SYMBOLS), !negate));

                    if (NEGATE_WORDS.Contains(word) ||
                       word.EndsWith("n't"))
                    {
                        negate = !negate;
                    }

                    if (STOP_SYMBOLS.Contains(word.Last()))
                    {
                        negate = false;
                        review.Tokens.Add(new Token(word.Last().ToString(), true));
                    }
                }
            }
            review.Text = null;
        }
    }
}
