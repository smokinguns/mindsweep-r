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
        public static int GameId = 0;
        public void AdvanceTurn(string gameId, string userName, int clickX, int clickY)
        {
            var game = new GameService().Get(gameId);
            var player = game.Player1.UserName == userName ? game.Player2 : game.Player1;
       
            Clients.Client(player.ConnectionId).updateBoard(clickX, clickY);
        }

        public void startGame(string player1Name, string player2Name)
        {
           
          
            var gameBoardService = new GameBoardService();
            var gameBoard = gameBoardService.GenerateBoard(10, 10, 10);

            var userService = new UserService();
            
            var user = userService.Get(player1Name);
            user.GameInProgress = true;
            var player1 = new Player() { ConnectionId = user.ConnectionId, UserName = user.UserName, AtBat = true };
            
            user = userService.Get(player2Name);
            var player2 = new Player() { ConnectionId = user.ConnectionId, UserName = user.UserName };
            user.GameInProgress = true;
            var gameService = new GameService();
            var game = gameService.Add(player1, player2, (GameId++).ToString(), gameBoard);
            game.numberOfMines = 10;
            game.boardHeight = 10;
            game.boardWidth = 10;
            Clients.Client(player1.ConnectionId).acceptGame(game);
            Clients.Client(player2.ConnectionId).acceptGame(game);
            Clients.All.updatePlayers(userService.Get());
        }

        public void Login(string userName)
        {
            var userService = new UserService();
            userService.Add(new User() { ConnectionId = Context.ConnectionId, UserName = userName });

            var onlineUsers = userService.Get();
            foreach (var onlineUser in onlineUsers)
            {
                Clients.Client(onlineUser.ConnectionId).updatePlayers(onlineUsers); ; 
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