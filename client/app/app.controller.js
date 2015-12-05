;(function(){
    angular.module('minesweep-r')
        .controller('HelloWorldController', HelloWorldController);
    
    function HelloWorldController(){
        var vm = this;
        
        vm.message = 'Hello World';
    }
}());