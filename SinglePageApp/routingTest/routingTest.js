var app =
    angular.module('routingTest', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
          .when('/', {
              templateUrl: 'home/home.html',
              controller: 'homeController'
          })
          .when('/about', {
              templateUrl: 'about/about.html',
              controller: 'aboutController'
          })
          .otherwise({
              redirectTo: '/'
          });
    }])

    .controller('mainController', function ($scope) {
        $scope.message = "Main Content";
    });
