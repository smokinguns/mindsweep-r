;(function(){
    angular.module('minesweep-r.player')
        .config(playerRouteConfig);
        
    playerRouteConfig.$inject = ['$stateProvider'];
        
    function playerRouteConfig($stateProvider){
        $stateProvider
            .state('player', {
                url: '/player',
                templateUrl: '/app/player/index.html',
                controller: 'PlayerController',
                controllerAs: 'playerCtrl'
            });
    }
}());