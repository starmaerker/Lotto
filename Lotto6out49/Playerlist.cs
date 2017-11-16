using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Playerlist
    {
        private List<Player> playerList;

        public List<Player> PlayerList
        {
            get
            {
                return playerList;
            }
            set
            {
                playerList = value;
            }
        }

        public Playerlist()
        {
            this.PlayerList = new List<Player>();
        }

        public static bool Existence(Player player, Playerlist toCheckList)
        {
            bool result = toCheckList.PlayerList.Exists(element => element.Name == player.Name);

            return result;
        }

        public static bool Existence(string player, Playerlist toCheckList)
        {
            bool result = toCheckList.PlayerList.Exists(element => element.Name == player);

            return result;
        }

        public static void AddPlayer(Player player, Playerlist toAddList)
        {
            toAddList.PlayerList.Add(player);
        }

        public static void SetIfHighScore(Player player, Playerlist toCheckList)
        {

            foreach (Player spieler in toCheckList.playerList)
            {
                if (player.Name == spieler.Name && player.Score > spieler.Score)
                {
                    spieler.Score = player.Score;
                    spieler.PlayDate = player.PlayDate;
                }
            }
        }

        public static void GetHighscore(Playerlist toCheckList)
        {
            int counter = 1;

            toCheckList.playerList.Sort(delegate (Player a, Player b) { return a.Score.CompareTo(b.Score); });
            toCheckList.playerList.Reverse();

            foreach (Player spieler in toCheckList.playerList)
            {

                Console.WriteLine(counter + ". " + spieler.Name + " Score: " + spieler.Score + " Playdate: " + spieler.PlayDate);
                counter++;
            }

            Console.WriteLine();
        }
    }
}
