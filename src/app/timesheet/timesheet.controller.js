(function() {
    'use strict';

    angular
        .module('app')
        .controller('TimesheetController', TimesheetController);

    TimesheetController.$inject = ["TimesheetService"];

    function TimesheetController(
        timesheetService
    ) {

        var vm = this;

        vm.message = "Please use the form below to enter your new timesheet.";
        vm.recentTimesheets = [];

        activate();

        /////////

        function activate() {
            timesheetService.load(function(err, data) {
                if (err) {
                    vm.message = "LOADING ERROR: " + err;
                } else {
                    vm.recentTimesheets = data;
                }
            })
        }
    }
})();