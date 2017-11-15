using System;
using System.Collections.Generic;

namespace Lotto
{

    class Player
    {
        private string name;
        private int score;
        private DateTime playDate;
        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 8)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Please enter less than 9 characters.");
                }
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public DateTime PlayDate
        {
            get
            {
                return playDate;
            }
            set
            {
                playDate = value;
            }
        }

        public Player(string name, int score, DateTime playDate)
        {
            this.Name = name;
            this.Score = score;
            this.PlayDate = playDate;
        }

        public Player(string name, DateTime playDate)
        {
            this.Name = name;
            this.PlayDate = playDate;
        }
    }
}
