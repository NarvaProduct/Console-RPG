using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Utils
    {
        public static int CheckUserInput(string userInput, int possibleChoices)
        {
            int checkedInput;
            do
            {
                if (!int.TryParse(userInput, out checkedInput))
                {
                    Console.WriteLine($"Invalid Input. Valid options between (1-{possibleChoices})");
                    userInput = Console.ReadLine();
                }
            }
            while (checkedInput > possibleChoices || checkedInput <= 0);

            return checkedInput;
        }
    }
}
