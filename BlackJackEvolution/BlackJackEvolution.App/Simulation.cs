using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackEvolution.App
{
    public class Simulation
    {
        public const int NUM_PLAYERS = 2000;
        public const int TABLE_SIZE = 5;
        public const int NUM_TABLES = 400;
        public const int BET = 10;
        public const int INITIAL_CHIPS = 5000;

        public const int SET_SIZE = 10;

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


            int generation = 0;
            while (generation < 5000)
            {
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

                // play sets of SET_SIZE hands until half the players are broke
                int set = 0;
                int count = 0;
                while (count < (NUM_PLAYERS / 2))
                {
                    // TODO: make this multithreaded
                    for (int s = 0; s < SET_SIZE; s++)
                        foreach (var table in tables)
                        {
                            var results = table.PlayHand();
                            //Console.WriteLine(results);
                        }
                    count = players.Count(p => p.Chips < BET);
                    set++;

                    //Console.WriteLine("After set {0}, {1} players are out", set, count);
                }
                Console.WriteLine("Generation {0} lasted {1} sets", generation, set);

                // Sort the players by chips left
                Array.Sort(players, delegate (Player x, Player y) { return y.Chips.CompareTo(x.Chips); });

                // Mate
                int sire = 0;
                int born = (NUM_PLAYERS / 2) + 1;
                while (born < NUM_PLAYERS)
                {
                    int dam = sire;
                    while (dam == sire)
                        dam = Random.Next(NUM_PLAYERS / 2);
                    players[born] = new Player(players[sire], players[dam]);
                    //Console.WriteLine("Player {0} produced from player {1} and {2}", born, sire, dam);

                    if (Random.Next(3) == 0)
                        sire++;

                    born++;
                }

                generation++;
            }

        }
    }
}
