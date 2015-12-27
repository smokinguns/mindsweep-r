using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using MinesweepR.Api.Models;
namespace MinesweepR.Api.Service
{
    public class PlayerService
    {
        public static List<Player> Players { get; set; }

        public void Add(Player player)
        {
            if (Players == null)
            {
                Players = new List<Player>() {player};
            }else{
                var existingPlayer = Players.FirstOrDefault(p => p.PlayerName == player.PlayerName);
                if (existingPlayer == null)
                {
                    Players.Add(player);
                }
            }
            
        }
        public IEnumerable<Player> Get()
        {
            return Players;
        }

        public Player Get(string playerId)
        {
            return Players.FirstOrDefault(p => p.ConnectionId == playerId);
        }
    }
}