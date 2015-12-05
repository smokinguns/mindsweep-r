;(function(){
    angular.module('minesweep-r')
        .config(routeConfig);
    
    routeConfig.$inject = ['$stateProvider'];
    
    function routeConfig($stateProvider, $urlRouterProvider){
        // $stateProvider
        //     .state('notFound', {
        //         url: '*path',
        //         templateUrl: '/app/default.html',
        //         controller: 'HelloWorldController',
        //         controllerAs: 'ctrl'
        //     });
    }
}());