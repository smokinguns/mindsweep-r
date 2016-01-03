;(function() {
    'use strict';

    angular.module('minesweep-r.api')
        .factory('Api', Api);

    Api.$inject = ['$http','$q'];

    function Api($http,$q) {

        var api = {
            getPlayers : getPlayers,
            reset:reset
        };

        function getPlayers() {
            var deferred = $q.defer();
            $http({
                url: 'http://api.minesweep-r.com/api/players',
                method: 'GET'
            }).then(function(result) {
                deferred.resolve(result.data);
            }).catch(function(err) {
                deferred.reject(err.reason);
            });
            return deferred.promise;
        }

        function reset()
        {
            var deferred = $q.defer();
            $http({
                url: 'http://api.minesweep-r.com/api/games',
                method: 'DELETE'
            }).then(function(result) {
                deferred.resolve(result.data);
            }).catch(function(err) {
                deferred.reject(err.reason);
            });
            return deferred.promise;
        }
        return api;
    }
}());
