using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEvolution.App
{
    public class Simulation
    {
        public const int NUM_PLAYERS = 1000;
        public const int TABLE_SIZE = 5;
        public const int NUM_TABLES = 200;
        public const int BET = 10;
        public const int INITIAL_CHIPS = 5000;

        public static readonly Random Random = new Random();

        Player[] players = new Player[NUM_PLAYERS];
        Table[] tables = new Table[NUM_TABLES];

        public void Start()
        {
            // Create initial batch of players
            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                players[i] = new Player();
                players[i].Name = i.ToString();
            }
            // Create initial batch of tables
            for (int i = 0; i < NUM_TABLES; i++)
            {
                tables[i] = new Table(TABLE_SIZE, Random);
                tables[i].Name = i.ToString();
            }

            // Give all the players chips; assign them to a table
            int tableNum = 0;
            int seatNum = 0;
            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                players[i].Chips = INITIAL_CHIPS;

                tables[tableNum].Seats[seatNum++].Player = players[i];
                if (seatNum >= TABLE_SIZE)
                {
                    seatNum = 0;
                    tableNum++;
                }

            }

            // play sets of 10 hands until half the players are broke
            int set = 0;
            int count = 0;
            while (count < (NUM_PLAYERS / 2))
            {
                for (int s = 0; s < 10; s++)
                    foreach(var table in tables)
                    {
                        var results = table.PlayHand();
                        //Console.WriteLine(results);
                    }
                count = players.Count(p => p.Chips < BET);
                set++;

                Console.WriteLine("After set {0}, {1} players are out", set, count);
            }


        }
    }
}
