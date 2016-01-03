;(function() {
    angular.module('minesweep-r.player')
        .factory('playerApi', playerApiFactory);

    playerApiFactory.$inject = ['$q'];

    function playerApiFactory($q) {
        var api = {
            registerPlayer: registerPlayer
        };

        return api;

        function registerPlayer(playerName) {
            // TODO:
            var deferred = $q.defer();

            deferred.resolve(playerName);

            return deferred.promise;
        }
    }
}());
