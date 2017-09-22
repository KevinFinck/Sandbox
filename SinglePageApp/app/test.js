(function() {
    'use strict';

    var app = angular.module('spaApp', []);

    app.controller('spaController',
        ['$scope', 'helloWorldService', 'helloWorldFactory',
        function (scope, service, factory) {
            //scope.message = "Hello from Controller!";
            //scope.message = service.hello();
            scope.message = factory.hello();
            scope.exitMessage = factory.goodBye();
        }]);

    app.service('helloWorldService', function () {
        this.hello = function() {
            return "Hello World, from you Service";
        };
    });

    app.factory('helloWorldFactory', function() {
        return {
            hello: function() {
                return "Hello World via the Factory";
            },
            goodBye: function () { return "Goodbye!"; }
        }
    });
})();