using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MinesweepR.Api.Service;
using MinesweepR.Api.Models;
using Microsoft.Practices.Unity;
namespace MinesweepR.Api.Service
{
    public class GamesController : ApiController
    {
        GameService _GameService;
        public GamesController(GameService gameService)
        {
            _GameService = gameService;
        }
        public IEnumerable<Game> Get()
        {
            return _GameService.Get();
        }
    
        public void Delete()
        {

            //TODO:this is temporary to aid in cleaning up gaems for testing
            var userService = new UserService();
            foreach (var game in _GameService.Get())
            {
                userService.Delete( game.Player1.UserName);
                
               userService.Delete(game.Player2.UserName);
                

            }
       
            _GameService.Delete();
        }
    }
}
