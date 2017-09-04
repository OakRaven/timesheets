(function() {
    "use strict";

    angular
        .module('app')
        .service('TimesheetService', TimesheetService);

    TimesheetService.$inject = [];

    function TimesheetService(api, session) {
        var vm = this;

        vm.load = load;

        function load(callback) {
            callback(null, [
                { Id: 1, WeekEnding: '2017-08-31', UserId: 1 },
                { Id: 2, WeekEnding: '2017-09-01', UserId: 1 },
                { Id: 3, WeekEnding: '2017-08-25', UserId: 1 },
                { Id: 4, WeekEnding: '2017-08-18', UserId: 1 }
            ]);
        }
    }
})();