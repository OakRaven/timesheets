(function() {
    "use strict";

    angular
        .module("app")
        .service("TimesheetDetailsService", TimesheetDetailsService);

    TimesheetDetailsService.$inject = [];

    function TimesheetDetailsService(api, session) {
        var vm = this;

        vm.load = load;

        function load(callback) {
            callback(null, {
                Id: 1,
                WeekEnding: "2017-08-31",
                Entries: [
                    { Id: 1, ProjectId: 1, Description: "Development", Sun: 0, Sat: 0, Mon: 4, Tue: 3, Wed: 0, Thu: 2, Fri: 0 },
                    { Id: 2, ProjectId: 2, Description: "Email support", Sun: 0, Sat: 0, Mon: 4, Tue: 5, Wed: 3, Thu: 0, Fri: 0 },
                    { Id: 3, ProjectId: 3, Description: "Meeting to discuss APA situation", Sun: 0, Sat: 0, Mon: 0, Tue: 0, Wed: 5, Thu: 6, Fri: 0 }
                ],
                Projects: [
                    { Id: 1, Client: { Name: "Beaumont Port" }, Name: "Work Package A", TotalHours: 42, HoursWorked: 34 },
                    { Id: 2, Client: { Name: "Atlantic Pilotage Authority" }, Name: "DABS II Support", TotalHours: 0, HoursWorked: 1232 },
                    { Id: 3, Client: { Name: "Nicom IT" }, Name: "General Meetings", TotalHours: 42, HoursWorked: 34 }
                ]
            });
        }
    }
})();