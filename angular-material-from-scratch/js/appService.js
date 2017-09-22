'use strict'

var app = angular.module('myApp');

app.factory('notifyService', ['$window', function(win) {
  var notifyService = {};

  notifyService.notify = function(msg) {
    win.alert('Factory: ' + msg);
  }

  return notifyService;
}]);
