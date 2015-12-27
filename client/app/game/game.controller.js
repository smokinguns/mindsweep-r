;(function(){
    angular.module('minesweep-r.game')
        .controller('GameController', GameController);
        
    GameController.$inject = ['Api','Hub','$rootScope'];
        
    function GameController(api,Hub, $rootScope) {

  var vm = this;
  vm.boardHeight = 9;
  vm.boardWidth = 9;
  vm.numberOfMines = 10;
  vm.gameId = "aaaaaa";
  vm.mineCoordinates = [];
  vm.loading = true;
  vm.players = [];
  vm.playerName = "";
  vm.handleClick = handleClick;
  vm.resetGameBoard = resetGameBoard;
  vm.joinGame = joinGame;
  vm.login = login;
  function handleClick(x, y){
     checkPosition(x,y);
  }
  function joinGame(){
    hub.joinGame(vm.gameId); //Calling a server method
  }
  
  function login(){
    hub.login(vm.playerName)
  }
  function resetGameBoard(){
      
  }
  
  function init(){
    vm.loading = false;
    api.getPlayers().then(function(players){
      vm.players = players;
    });
     //resetGameBoard();
  }

  function checkPosition(x,y){
    if (x < 0 || y < 0 || x >= vm.boardWidth || y >= vm.boardHeight ) {
      return;
    } else {
      if (vm.gameBoard[y][x] === undefined || vm.gameBoard[y][x].clicked === true) {
        return;
      }
      vm.gameBoard[y][x].clicked = true;
      if(vm.gameBoard[y][x].numberOfSurroundingMines >0 || vm.gameBoard[y][x].hasMine){
        return;
      }
      var stuff = [{
        'x': x - 1,
        'y': y
      }, {
        'x': x,
        'y': y - 1
      }, {
        'x': x + 1,
        'y': y
      }, {
        'x': x,
        'y': y + 1
      },{
        'x': x +1,
        'y': y -1
      },{
        'x': x-1,
        'y': y -1
      },{
        'x': x-1,
        'y': y + 1
      },{
        'x': x+1,
        'y': y + 1
      }];

     
        angular.forEach(stuff, function(value, key) {
       
        
          checkPosition(value.x, value.y);


        });
     
    }
    
    
  }

  
  //declaring the hub connection
    var hub = new Hub('GameHub', {

        //client side methods
        listeners:{
            'initBoard': function (board) {
                
                vm.gameBoard = board;
                $rootScope.$apply();
            },
            'updatePlayers':function(players){
              vm.players = players;
              $rootScope.$apply();
            }
        },

        //server side methods
        methods: ['joinGame','login'],

        //query params sent on initial connection
        queryParams:{
            
        },
        rootPath:'http://192.168.1.22/minesweepR.api/signalr/hubs',
        

        //handle connection error
        errorHandler: function(error){
            console.error(error);
        },

        //specify a non default root
        //rootPath: '/api

        stateChanged: function(state){
            switch (state.newState) {
                case $.signalR.connectionState.connecting:
                    //your code here
                    break;
                case $.signalR.connectionState.connected:
                    //your code here
                    break;
                case $.signalR.connectionState.reconnecting:
                    //your code here
                    break;
                case $.signalR.connectionState.disconnected:
                    //your code here
                    break;
            }
        }
    });

    
    
    
    
  
  init();





  }

  

}());