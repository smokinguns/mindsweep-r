;(function() {
    angular.module('minesweep-r.game')
        .config(playerRouteConfig);

    playerRouteConfig.$inject = ['$stateProvider'];

    function playerRouteConfig($stateProvider) {
        $stateProvider
            .state('game', {
                url: '/game',
                templateUrl: 'app/game/index.html',
                controller: 'GameController',
                controllerAs: 'gameCtrl'
            });
    }
}());
