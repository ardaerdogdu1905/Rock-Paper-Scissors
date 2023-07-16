using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameAlgo game = new GameAlgo();

            while (true)
            {
                game.Start();

                Console.WriteLine("The game is done. Do you want to start over? Yes/No");
                string again = Console.ReadLine().ToLower();

                Console.Clear();

                if (again == "no")
                {
                    break;
                }
                else if (again != "yes")
                {
                    Console.WriteLine("Please enter a yes or no answer");
                }
            }

            Console.ReadKey();



        }
    }
}
