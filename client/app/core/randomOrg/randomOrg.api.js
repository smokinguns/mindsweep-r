;(function() {
    'use strict';

    angular.module('minesweep-r.randomOrg')
        .factory('randomOrgApi', randomOrgApi);

    randomOrgApi.$inject = ['$http'];

    function randomOrgApi($http) {

        var api = {
            getRandomNumbers : getRandomNumbers
        };

        function getRandomNumbers(min, max, numberOfRandoms)
        {
            return $http({
                url: 'http://api.minesweep-r.com/api/MineCordinates',
                method: 'GET',
                params:{
                    count:numberOfRandoms,
                    min:min,
                    max:max
                }
            });
        }

        return api;

    }
}());
