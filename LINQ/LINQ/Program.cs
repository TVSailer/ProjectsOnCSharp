using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Player> players = new List<Player>
            {
                new Player("Bob", 34),
                new Player("Tom", 398),
                new Player("Vog", 400),
                new Player("Jon", 36)
            };

            var filteredPlayers = from Player player in players where player.Level > 100 select player;
            var filteredPlayers2 = players.Where(player => player.Level < 100).Select(player => player);
            var filteredPlayers3 = players.Where(player => player.Name.ToUpper().StartsWith("T"));
            
            foreach (var player in filteredPlayers3)
            {
                player.PrintInfo();
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }

        public Player(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public void PrintInfo() => Console.WriteLine($"Name: {Name} Level: {Level}");
    }
}