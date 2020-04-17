using System;
using System.Diagnostics;
using System.Linq;

namespace WordRanking
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Please enter the book title you wish to read:");
                var title = Console.ReadLine();
                var length = AskLength();
                var order = AskOrder();
                Stopwatch timer = new Stopwatch();
                timer.Start();
                var cw = new CountWords();
                var countListing = cw.CountWordsAndOrder(title, length, order);
                Console.WriteLine("-----------------------------------------------------------------------");
                for (int i = 0; i<=49; i++)
                {
                    Console.WriteLine(countListing.Keys.ElementAt(i) + " - " + countListing.Values.ElementAt(i));
                }
                timer.Stop();

                Console.WriteLine("This process took -" + timer.Elapsed);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public static int AskLength()
        {
            Console.WriteLine("Please enter length of the words (and up) you wish to count");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int length))
            {
                AskLength();
            }
            return length;
        }
        public static string AskOrder()
        {
            Console.WriteLine("Please enter whether you would like to sort them in ascending (enter asc) order or decending (enter desc) order");
            var input = Console.ReadLine();
            if (input != "asc" && input != "desc")
            {
                AskOrder();
            }
            return input;
        }
    }
}
