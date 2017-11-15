using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lotto
{

    class Lotto6out49
    {
        static void CheckIfHighScore(Player player, List<Player> playerList)
        {
            
            foreach (Player spieler in playerList)
            {
                if (player.Name == spieler.Name && player.Score > spieler.Score)
                {
                    spieler.Score = player.Score;
                }
            }
            
            
        }

        static void GetHighscore(List<Player> playerList)
        {
            int counter = 1;

            playerList.Sort(delegate (Player a, Player b) { return a.Score.CompareTo(b.Score); });
            playerList.Reverse();

            foreach (Player spieler in playerList)
            {

                Console.WriteLine(counter + ". " + spieler.Name + " Score: " + spieler.Score + " Playdate: " + spieler.PlayDate);
                counter++;
            }

            Console.WriteLine();
        }

        static int CheckRightNumber(int[] numberArray, int[] generated)
        {
            int result = 0;
            
            foreach (int value in numberArray)
            {
                if (IsInArray(value, generated))
                {
                    Console.Write(value + " ");
                    result++;
                }
            }

            Console.WriteLine();

            return result;       

        }


        static bool IsInArray(int number, int[] numberArray)
        {
            bool result = false;

            foreach (int value in numberArray)
            {
                if (number == value)
                {
                    result = true;
                }
            }

            return result;

        }

        static void DisplayArray(int[] arr)
        {
            foreach (int number in arr)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        static int[] GenerateNumbers()
        {
            Random rand = new Random();
            int i = 0;
            int temp;

            int[] result = new int[6];

            while (i < 6)
            {
                temp = rand.Next(1, 50);
                if (!IsInArray(temp, result))
                {
                    result[i] = temp;
                    i++;
                }
            }

            return result;
        }

        static bool CheckForDuplicates(int[] numberArray)
        {
            bool result = false;

            for (int i = 0; i < numberArray.Length - 1; i++)
            {
                for (int j = i + 1; j < numberArray.Length; j++)
                {
                    if (numberArray[i] == numberArray[j])
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }


        static void Main()
        {


            bool loop = true;
            int temp;
            string feed;
            string input;
            string[] myNumbers = new string[] { };
            int[] numberArray = new int[] { };
            string player;
            List<Player> playerList = new List<Player>();
            

            while (loop)
            {

                while (true)
                {
                    Console.WriteLine("Please enter your name.");
                    player = Console.ReadLine();


                    while (playerList.Exists(element => element.Name == player))
                    {
                        Console.WriteLine("Playername existing. Choose another one or press w to continue as {0}.", player);
                        input = Console.ReadLine();
                        if (input == "w")
                        {
                            break;
                        }
                    }

                    Player newPlayer = new Player(player, DateTime.Now);
                    //playerList.Add(newPlayer);

                    
                    if (!playerList.Exists(element => element.Name == player))
                    {
                        playerList.Add(newPlayer);
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

                    if (CheckForDuplicates(numberArray))
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


                    int[] generated = GenerateNumbers();



                    Console.WriteLine();
                    //DisplayArray(numberArray);
                    DisplayArray(generated);

                    Console.WriteLine();

                    newPlayer.Score = CheckRightNumber(numberArray, generated);

                    Console.WriteLine("You have {0} right rumber(s).", newPlayer.Score);

                    

                    Console.WriteLine();

                    CheckIfHighScore(newPlayer, playerList);
                    

                    

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
                        Console.WriteLine("test: " + newPlayer.Score);

                        GetHighscore(playerList);

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


