/**
 * angular-starter-kit
 *
 * @author Andrea SonnY <andreasonny83@gmail.com>
 * @copyright 2016 Andrea SonnY <andreasonny83@gmail.com>
 *
 * This code may only be used under the MIT style license.
 *
 * @license MIT  https://andreasonny.mit-license.org/@2016/
 */
(function() {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    function HomeController() {
        var vm = this;

    }

    /**
     * initialize the controller
     */
    HomeController.prototype._init = function() {
        this.pageReady = true;
    };

    HomeController.prototype.next = function(isValid) {
        var vm = this;
        // If the form is not validated, show an error message
        if (!isValid) {
            alert('You must fill all the required information first.');
            return;
        }

        vm.selectedIndex += 1;
    };

    HomeController.$inject = [];
})();