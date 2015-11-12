using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Mocks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> allLines = new List<string>();
            int lowEndNumber = 1;
            int totalNumber = 100;
            List<NumberWordPairing> pairings = new List<NumberWordPairing>();
            NumberWordPairing nw = new NumberWordPairing();
            nw.NumbersDivisibleBy = new List<int> {3 };
            nw.DisplayWord = "Fizz";
            pairings.Add(nw);

            NumberWordPairing nw1 = new NumberWordPairing();
            nw1.NumbersDivisibleBy = new List<int>() { 5 };
            nw1.DisplayWord = "Buzz";
            pairings.Add(nw1);

            NumberWordPairing nw2 = new NumberWordPairing();
            nw2.NumbersDivisibleBy = new List<int>() { 3,5 };
            nw2.DisplayWord = "FizzBuzz";
            pairings.Add(nw2);
            
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

            List<int> divisble3 = new List<int>();
            List<int> divisble5 = new List<int>();
            List<int> divisble35 = new List<int>();
            List<int> notDivisible = new List<int>();
            int counter = 0;
            foreach(string n in allLines) //This loop extracts all the return cases and places them into respective lists
            {
                counter++;
                if(n=="Fizz")
                {
                    divisble3.Add(counter);
                }
                else if(n=="Buzz")
                {
                    divisble5.Add(counter);
                }
                else if(n=="FizzBuzz")
                {
                    divisble35.Add(counter);
                }
                else
                {
                    notDivisible.Add(Convert.ToInt32(n));
                }
            }

            bool d3correct = false;
            bool d5correct = false;
            bool d35corect = false;
            bool notDCorrect = false;

            //bools below are checked to see if each of those cases are correct, if correct the test returns passing
            if(divisble3.All(z=>z%3==0)) 
            {
                d3correct = true;
            }
            if (divisble5.All(z => z % 5 == 0))
            {
                d5correct = true;
            }
            if (divisble35.All(z => z % 3 == 0) && divisble35.All(z => z % 5 == 0))
            {
                d35corect = true;
            }
            if (notDivisible.All(z => z % 3 != 0) && notDivisible.All(z => z % 5 != 0))
            {
                notDCorrect = true;
            }

            Assert.IsTrue(d3correct == true && d5correct == true && d35corect == true && notDCorrect == true);
        }
        
    }
}
