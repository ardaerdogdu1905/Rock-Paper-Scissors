using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class GameAlgo
    {

        private static readonly Random random = new Random();

        public void Start()
        {
            try
            {
                Console.WriteLine("~Welcome to Rock Paper Scissors Game~");
                Console.WriteLine("Press 's' to start");

                string start = Console.ReadLine().ToLower();

                if (start == "s")
                {
                    Console.Clear();
                    Console.WriteLine("How many times do you want to play the game?");
                    int gameNumber = int.Parse(Console.ReadLine());
                    Console.Clear();

                    int pcScore = 0;
                    int myScore = 0;

                    for (int i = 0; i < gameNumber; i++)
                    {
                        string computerMove = GetComputerMove();
                        string playerMove = GetPlayerMove();

                        Console.Clear();

                        Console.WriteLine("Rock.");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("Paper..");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("Scissors...");
                        System.Threading.Thread.Sleep(1000);

                        Console.Clear();

                        Console.WriteLine("My answer is: " + playerMove);
                        Console.WriteLine("Computer answer is: " + computerMove);

                        DetermineWinner(playerMove, computerMove, ref myScore, ref pcScore);

                        Console.WriteLine("My Score is: " + myScore);
                        Console.WriteLine("Pc Score is: " + pcScore);
                    }

                    Console.WriteLine(GetGameResult(myScore, pcScore));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You pressed a wrong key. Please try again.");
                    Start();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a correct value");
                Start();
            }
        }

        private string GetComputerMove()
        {
            int randomPc = random.Next(1, 4);

            switch (randomPc)
            {
                case 1:
                    return "rock";
                case 2:
                    return "paper";
                case 3:
                    return "scissors";
                default:
                    return string.Empty;
            }
        }

        private string GetPlayerMove()
        {
            Console.WriteLine("Please choose the move to take: Rock, Paper, or Scissors");
            string playerMove = Console.ReadLine().ToLower();

            if (playerMove != "rock" && playerMove != "paper" && playerMove != "scissors")
            {
                Console.WriteLine("You made a wrong choice");
                return GetPlayerMove();
            }

            return playerMove;
        }

        private void DetermineWinner(string playerMove, string computerMove, ref int myScore, ref int pcScore)
        {
            if (playerMove == computerMove)
            {
                Console.WriteLine("Tie");
            }
            else if ((playerMove == "rock" && computerMove == "scissors") ||
                     (playerMove == "paper" && computerMove == "rock") ||
                     (playerMove == "scissors" && computerMove == "paper"))
            {
                Console.WriteLine("You won");
                myScore++;
            }
            else
            {
                Console.WriteLine("Computer won");
                pcScore++;
            }
        }

        private string GetGameResult(int myScore, int pcScore)
        {
            if (myScore > pcScore)
            {
                return "You won the game...";
            }
            else if (myScore == pcScore)
            {
                return "Tie";
            }
            else
            {
                return "Pc won the game...";
            }
        }

    }
}
