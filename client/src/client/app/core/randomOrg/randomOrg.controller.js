;(function() {
    'use strict';

    angular.module('minesweep-r.randomOrg')
        .controller('RandomOrgController', RandomOrgController);

    RandomOrgController.$inject = ['$http', 'randomOrgApi'];

    function RandomOrgController($http, randomOrgApi) {
        var vm = this;

        vm.min = 0;
        vm.max = 100;
        vm.numberOfRandoms = 10;

        vm.randomNumbers = [];
        vm.getRandomNumbers = getRandomNumbers;

        function getRandomNumbers()
        {
            randomOrgApi.getRandomNumbers(vm.min, vm.max, vm.numberOfRandoms)
            .then(function(result) {
                /* jshint -W117 */
                vm.randomNumbers = _.sortBy(result.data.result.random.data);
            })
            .catch(function(reason) {
                // Something bad happened
            });
        }

    }
}());
