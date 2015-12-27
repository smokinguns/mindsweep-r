using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MinesweepR.Api.Models;
using System.Threading.Tasks;
using MinesweepR.Api.Service;
namespace MinesweepR.Api.Hubs
{
    public class GameHub : Hub
    {
 


        public void JoinGame(string gameId)
        {
            Action<GameBoardPosition[,]> sendBoard = (board) =>
            {
                Clients.Client(Context.ConnectionId).initBoard(board); 
            };
            var gameService = new GameService();
            var playerService = new PlayerService();
            var player = playerService.Get(Context.ConnectionId);
            var game = gameService.Get(gameId);
            if (game == null)
            {
                var gameBoard = new GameBoardService().GenerateBoard(10, 10, 10);
                game = gameService.Add(player, gameId, gameBoard); 
                sendBoard(game.GameBoard);
            }
            else
            {
                if (game.Player2 == null)
                {
                    gameService.Join(player, game);
                    
                    sendBoard(game.GameBoard);
                }
            }
        }

        public void Login(string playerName)
        {
            var playerService = new PlayerService();
            playerService.Add(new Player() { ConnectionId = Context.ConnectionId, PlayerName = playerName });

            var players = playerService.Get();
            foreach (var plyr in players )
            {
                Clients.Client(plyr.ConnectionId).updatePlayers(players); 
            }
        }
       
        public override Task OnConnected()
        {
            CheckConnection();

            
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
           // GameData.Remove(GameData.FirstOrDefault(a => a.ConnectionId == Context.ConnectionId));

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            CheckConnection();

            return base.OnReconnected();
        }

        private void CheckConnection()
        {
         
        }
    }
}