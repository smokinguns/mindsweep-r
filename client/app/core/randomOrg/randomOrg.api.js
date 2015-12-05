;(function(){
    'use strict';
    
    angular.module('minesweep-r.randomOrg')
        .factory('randomOrgApi', randomOrgApi)
        
    randomOrgApi.$inject = ['$http'];
        
    function randomOrgApi($http) {
        
        var api = {
            getRandomNumbers : getRandomNumbers
        }         
        
        function getRandomNumbers(min, max, numberOfRandoms)
        {
            var xsrf = ({
                'jsonrpc': '2.0',
                'method': 'generateIntegers',
                'params': {
                'apiKey': 'd2319b89-8389-4d24-b1eb-4dbd80009153',
                'n': numberOfRandoms,
                'min': min,
                'max': max,
                'replacement': false,
                'base': 10
                },
                'id': 27846
            });
            
            return $http({
                url: 'https://cors-anywhere.herokuapp.com/https://api.random.org/json-rpc/1/invoke',
                method: 'POST',
                headers: {
                'Content-Type': 'application/json-rpc'
                },
                data: xsrf
            });
        }
        
        return api
        
    }
}());