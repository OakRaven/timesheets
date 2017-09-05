(function() {
    "use strict";

    angular
        .module("app")
        .service("TimesheetService", TimesheetService);

    TimesheetService.$inject = [];

    function TimesheetService(api, session) {
        var vm = this;

        vm.load = load;

        function load(callback) {
            callback(null, {
                recentTimesheets: [
                    { Id: 1, WeekEnding: "2017-08-31", UserId: 1, TotalHours: 32, Status: "Submitted" },
                    { Id: 2, WeekEnding: "2017-09-01", UserId: 1, TotalHours: 0, Status: "In Progress" },
                    { Id: 3, WeekEnding: "2017-08-25", UserId: 1, TotalHours: 40, Status: "Submitted" },
                    { Id: 4, WeekEnding: "2017-08-18", UserId: 1, TotalHours: 40, Status: "Submitted" },
                    { Id: -1, WeekEnding: "2017-09-08", UserId: 1, TotalHours: 0, Status: "New" }
                ]
            });
        }
    }
})();