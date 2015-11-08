using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApplicationClearMeasure
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager test = new Manager();
            bool outOfMemoryprotect = false; //this variable signals if its going to protect against out of memory error.
            int totalNumber = 1000000; //total number is the variable for the total amount of numbers they want.
            int lowEndNumber = 0;
            List<NumberWordPairing> pairings = new List<NumberWordPairing>();

            ///Insert NumberWordPairings Below, you can enter as many as desired. This will only write out specific pairings that match EXACTLY the int list.
            #region NumberWordPairings
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
            #endregion


                if (totalNumber > 500)
                {
                    outOfMemoryprotect = true;
                }
                
            

            if(outOfMemoryprotect==false)
            {
                lowEndNumber = 1;
                List<string> n = test.FizzBuzzMethod(lowEndNumber, totalNumber, pairings);
                foreach (string d in n)
                {
                    Console.WriteLine(d);
                }
                Console.Read();
            }
            else
            {
                int totalNumberSection = 500;
                while (totalNumberSection <= totalNumber)
                {
                    if(lowEndNumber==0)
                    {
                        lowEndNumber=1;
                    }
                    List<string> n = test.FizzBuzzMethod(lowEndNumber, totalNumberSection,pairings);
                    foreach (string s in n)
                    {
                        Console.Out.WriteLine(s);
                    }
                    
                    lowEndNumber = totalNumberSection + 1;
                    
                    totalNumberSection += 500;
                    if(totalNumberSection>totalNumber)
                    {
                        totalNumberSection = totalNumber;
                    }
                }
                Console.Read();
            }

           
            
            
            
            


                
        }
    }
}
