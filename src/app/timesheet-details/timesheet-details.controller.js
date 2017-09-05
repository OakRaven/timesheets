(function() {
    'use strict';

    angular
        .module('app')
        .controller('TimesheetDetailsController', TimesheetDetailsController);

    TimesheetDetailsController.$inject = ["TimesheetDetailsService"];

    function TimesheetDetailsController(
        timesheetDetailService
    ) {

        var vm = this;

        activate();

        /////////

        function activate() {}
    }
})();