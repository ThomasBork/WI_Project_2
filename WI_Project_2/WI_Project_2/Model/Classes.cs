using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_Project_2.Model
{
    public static class Classes
    {
        public static Dictionary<ClassEnum, int> ClassCount = new Dictionary<ClassEnum, int>();
        public static Dictionary<ClassEnum, Dictionary<Token, int>> ClassOccurances = new Dictionary<ClassEnum, Dictionary<Token, int>>();

        public static void IncrementUse(ClassEnum ce, Token t)
        {
            if(!ClassCount.ContainsKey(ce))
            {
                ClassCount.Add(ce, 0);
                ClassOccurances.Add(ce, new Dictionary<Token, int>());
            }
            ClassCount[ce]++;

            if(!ClassOccurances[ce].ContainsKey(t))
            {
                ClassOccurances[ce][t] = 0;
            }

            ClassOccurances[ce][t]++;
        }
    }

    public enum ClassEnum
    {
        Negative,
        Neutral,
        Positive
    }
}
