using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.challenges
{
    /*
        Verify the correct pattern(open, close) in string whit a pattern guide

        example to use the object
        
        for true:
        bool result = MatchPattern.Match("[([])]", new (char, char)[] { ('{', '}'), ('[', ']'), ('(', ')') });

        for false:
        MatchPattern.Match("[([]])", new (char, char)[] { ('{', '}'), ('[', ']'), ('(', ')') });
        
     */
    public static class MatchPattern
    {
        public static bool Match(string s, (char, char)[] patterns)
        {
            List<char> acum = new List<char>();
            if (s.Length <= 1)
            {
                return false;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (patterns.Any(x => x.Item1 == s[i]))
                {
                    acum.Add(s[i]);
                }
                if (patterns.Any(x => x.Item2 == s[i]))
                {
                    if (acum.Count() == 0)
                    {
                        return false;
                    }
                    (char, char) pattern = patterns.FirstOrDefault(x => x.Item2 == s[i]);
                    if (acum.Last() != pattern.Item1)
                    {
                        return false;
                    }
                    acum.RemoveAt(acum.Count -1);
                }
            }
            if (acum.Count() > 0)
            {
                return false;
            }
            return true;
        }
    }
}
