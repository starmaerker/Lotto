using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lotto
{

    class Program
    {
               
        static void Main()
        {
            bool loop = true;
            int temp;
            string feed;
            string input;
            string[] myNumbers = new string[] { };
            int[] numberArray = new int[] { };
            string player = "";
            Playerlist playerList = new Playerlist();
            

            while (loop)
            {

                while (true)
                {
                    Console.WriteLine("Please enter your name.");
                    player = Console.ReadLine();

                    while (player.Trim() == "")
                    {
                        Console.WriteLine("Please enter your name.");
                        player = Console.ReadLine();
                    }

                    while (Playerlist.Existence(player, playerList))
                    {
                        Console.WriteLine("Playername existing. Choose another one or press w to continue as {0}.", player);
                        input = Console.ReadLine();
                        if (input == "w")
                        {
                            break;
                        }
                    }

                    Player newPlayer = new Player(player, DateTime.Now);
                                        
                    if (!Playerlist.Existence(newPlayer, playerList))
                    {
                        Playerlist.AddPlayer(newPlayer, playerList);
                    }
                    
                    Console.WriteLine("{0} please enter 6 distinct numbers between 1 and 49.", player);
                    input = Console.ReadLine();
                    myNumbers = Regex.Replace(input, @"\s+", " ").Trim().Split(' ');

                    if (myNumbers.All(number => Int32.TryParse(number, out temp)))
                    {
                        numberArray = Array.ConvertAll(myNumbers, Int32.Parse);
                    }
                    else
                    {
                        Console.WriteLine("Wrong format.");
                        break;
                    }

                    if (Lotto6out49.CheckForDuplicates(numberArray))
                    {
                        Console.WriteLine("You entered a duplicate number.");
                        break;
                    }

                    if (Array.Exists(numberArray, element => element < 1 || element > 49))
                    {
                        Console.WriteLine("You entered a number outside 1-49.");
                        break;
                    }

                    if (numberArray.Length != 6)
                    {
                        Console.WriteLine("You entered {0} numbers.", myNumbers.Length);
                        break;
                    }


                    int[] generated = Lotto6out49.GenerateNumbers();

                    Console.WriteLine();

                    Lotto6out49.DisplayArray(generated);

                    Console.WriteLine();

                    newPlayer.Score = Lotto6out49.CheckRightNumber(numberArray, generated);

                    Console.WriteLine("You have {0} right rumber(s).", newPlayer.Score);

                    Console.WriteLine();

                    Playerlist.SetIfHighScore(newPlayer, playerList);
                                        

                    Console.WriteLine("If you wanna quit enter q or press w to continue or h to show highscore.");


                    feed = Console.ReadLine();

                    while (!(feed == "q" || feed == "w" || feed == "h"))
                    {
                        Console.WriteLine("Please enter q or w or h");
                        feed = Console.ReadLine();
                    }

                    if (feed == "q")
                    {
                        loop = false;
                        break;
                    }

                    if (feed == "h")
                    {
                        Playerlist.GetHighscore(playerList);

                        break;
                    }

                    if (feed == "w")
                    {
                        break;
                    }

                }
            }

        }
    }
}


