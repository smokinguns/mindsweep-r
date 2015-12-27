;(function(){
    'use strict';
    
    angular.module('minesweep-r.api')
        .factory('Api', Api)
        
    Api.$inject = ['$http','$q'];
        
    function Api($http,$q) {
        
        var api = {
            getGameBoard : getGameBoard,
            getPlayers : getPlayers
        }         
        
        function getGameBoard(numberOfMines, boardHeight,boardWidth)
        {
			var deferred = $q.defer();
            $http({
                url: 'http://api.minesweep-r.com/minesweepr.api/api/gameboard',
                method: 'GET',
                params:{
                    numberOfMines:numberOfMines,
                    boardHeight:boardHeight,
                    boardWidth:boardWidth
                }
            }).then(function(result){
				deferred.resolve(result.data);
			}).catch(function(err){
				deferred.reject(err.reason);
			});
			return deferred.promise;
        }
        function getPlayers()
        {
			var deferred = $q.defer();
            $http({
                url: 'http://192.168.1.22/minesweepr.api/api/players',
                method: 'GET',
                
            }).then(function(result){
				deferred.resolve(result.data);
			}).catch(function(err){
				deferred.reject(err.reason);
			});
			return deferred.promise;
        }
        
        return api;
    }
}());