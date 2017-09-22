'use strict'

var app = angular.module('myApp');

app.controller('appController', ['$scope', 'notifyService', function($scope, notifyService) {
    $scope.greeting = 'Hello angular world!';

    $scope.clickMe = function(message) {
          notifyService.notify(message);
        }
      }
]);
