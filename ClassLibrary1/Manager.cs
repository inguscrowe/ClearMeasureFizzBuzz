using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Manager
    {
        public List<string> FizzBuzzMethod(int lowEndNumber, int totalNumber, List<NumberWordPairing> pairings)
        {
            List<string> allLines = new List<string>();
                for (int i = lowEndNumber; i <= totalNumber; i++)
                {
                    if (pairings.Any(z => z.NumbersDivisibleBy.All(b => i % b == 0)))
                    {
                        List<NumberWordPairing> insert = pairings.Where(z => z.NumbersDivisibleBy.All(b => i % b == 0)).ToList();
                        if (insert.Count == 1)
                        {
                            allLines.Add(insert[0].DisplayWord);
                        }
                        else
                        {
                            List<int> specific = new List<int>();
                            foreach (NumberWordPairing np in insert)
                            {
                                foreach (int n in np.NumbersDivisibleBy)
                                {
                                    if (specific.Any(z => z == n))
                                    {
                                        continue;
                                    }
                                    specific.Add(n);
                                }
                            }

                            NumberWordPairing writeThis = new NumberWordPairing();
                            foreach (NumberWordPairing np in insert)
                            {
                                if (np.NumbersDivisibleBy.All(e => specific.Contains(e)) && specific.Count == np.NumbersDivisibleBy.Count)
                                {
                                    writeThis = np;
                                }
                            }
                            if (writeThis != null)
                            {
                                allLines.Add(writeThis.DisplayWord);
                            }
                            else
                            {
                                allLines.Add(i.ToString());
                            }
                        }
                    }
                    else
                    {
                        allLines.Add(i.ToString());
                    }
                }
            
            return allLines;
        }

    }
}
