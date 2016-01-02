;(function() {
    angular.module('minesweep-r', ['ui.bootstrap',
                                  'ui.router',
                                  'minesweep-r.player',
                                  'minesweep-r.game',
                                  'minesweep-r.fixedLength',
                                  'timer',
                                  'minesweep-r.api','SignalR'
                                ]);
}());
