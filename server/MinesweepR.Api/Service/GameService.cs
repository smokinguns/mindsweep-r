using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinesweepR.Api.Models;
namespace MinesweepR.Api.Service
{
    public class GameService
    {
        public static List<Game> Games;
        public GameService()
        {
            if (Games == null)
            {
                Games = new List<Game>();
            }
        }
        public Game Add(Player player, string gameId, GameBoardPosition[,] gameBoard)
        {
            var game = new Game() { GameId = gameId, Player1 = player, GameBoard = gameBoard };
            Games.Add(game);
            return game;
        }
        public void Join(Player player, Game game)
        {
            game.Player2 = player;
        }


        public IEnumerable<Game> Get()
        {
            return Games;
        }

        public Game Get(string gameId)
        {
            return Games.FirstOrDefault(g=>g.GameId == gameId);
        }
    }
}