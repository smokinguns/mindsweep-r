;(function(){
    angular.module('minesweep-r.player')
        .controller('PlayerController', PlayerController);
        
    PlayerController.$inject = ['playerApi'];
        
    function PlayerController(playerApi){
        var vm = this;
        
        vm.playerName = 'Hello World';
        vm.registerPlayer = registerPlayer;
        
        function registerPlayer(){
            playerApi.registerPlayer(vm.playerName)
                .then(function registerPlayerSuccess(){
                    // TODO: navigate to next state.
                    vm.playerName = 'Registered';
                });
        }
    }
}());