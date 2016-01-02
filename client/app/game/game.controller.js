;(function() {
    angular.module('minesweep-r.game')
        .controller('GameController', GameController);

    GameController.$inject = ['Api','Hub','$rootScope'];

    function GameController(api,Hub, $rootScope) {

        var vm = this;

        vm.loggedIn = false;
        vm.loading = true;
        vm.onlineUsers = [];
        vm.userName = '';
        vm.player = null;
        vm.opponent = null;
        vm.handleClick = handleClick;
        vm.challengePlayer = challengePlayer;
        vm.resetAllGames = resetAllGames;
        vm.game = null;
        vm.login = login;

        function resetAllGames() {
            api.reset().then(function() {
                vm.userName = '';
                vm.player = null;
                vm.opponent = null;
                vm.game = null;
                api.getPlayers().then(function(players) {
                    vm.onlineUsers = players;
                });
            });
        }

        function handleClick(x, y) {
            if (!vm.player.atBat) {
                return;
            }
            vm.player.atBat = false;
            vm.opponent.atBat = true;
            checkPosition(x,y);
            hub.advanceTurn(vm.game.gameId, vm.player.userName,x,y);
        }
        function challengePlayer(userName) {
            //(player1,player2)
            hub.startGame(vm.userName, userName); //Calling a server method
        }

        function login() {
            vm.loggedIn = true;
            hub.login(vm.userName);
        }

        function init() {
            vm.loading = false;
            api.getPlayers().then(function(players) {
                vm.onlineUsers = players;
            });
            //resetGameBoard();
        }

        function checkPosition(x,y) {
            if (x < 0 || y < 0 || x >= vm.game.boardWidth || y >= vm.game.boardHeight) {
                return;
            } else {
                if (vm.game.gameBoard[y][x] === undefined ||
                    vm.game.gameBoard[y][x].clicked === true) {
                    return;
                }
                vm.game.gameBoard[y][x].clicked = true;
                if (vm.game.gameBoard[y][x].numberOfSurroundingMines > 0 ||
                   vm.game.gameBoard[y][x].hasMine) {
                    return;
                }
                var stuff = [{
                    'x': x - 1,
                    'y': y
                },{
                    'x': x,
                    'y': y - 1
                },{
                    'x': x + 1,
                    'y': y
                },{
                    'x': x,
                    'y': y + 1
                },{
                    'x': x + 1,
                    'y': y - 1
                },{
                    'x': x - 1,
                    'y': y - 1
                },{
                    'x': x - 1,
                    'y': y + 1
                },{
                    'x': x + 1,
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
            'updatePlayers':function(players) {
                vm.onlineUsers = players;
                $rootScope.$apply();
            },
            'updateBoard':function(x,y) {
                checkPosition(x,y);
                vm.player.atBat = true;
                vm.opponent.atBat = false;
                $rootScope.$apply();
            },'acceptGame':function(game) {
                vm.game = game;
                if (game.player1.userName === vm.userName) {
                    vm.player = game.player1;
                    vm.opponent = game.player2;
                } else {
                    vm.player = game.player2;
                    vm.opponent = game.player1;
                }
                $rootScope.$apply();
            }
        },

        //server side methods
        methods: ['startGame','login','advanceTurn'],

        //query params sent on initial connection
        queryParams:{
        },
        rootPath:'http://192.168.1.22/minesweepR.api/signalr/hubs',
        //handle connection error
        errorHandler: function(error) {
            console.error(error);
        },

        //specify a non default root
        //rootPath: '/api

        stateChanged: function(state) {
            switch (state.newState) {
              /* jshint -W117 */
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
