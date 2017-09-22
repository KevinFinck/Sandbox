app = angular.module('myMultiControllerApp', []);                                                                             

/*
app.config(function($routeProvider, $locationProvider) {                        
    $routeProvider                                                                
         .when('/home/', {                                            
             templateUrl: "templates/home.html",                                               
             controller:'homeController',                                
         })                                                                      
          .when('/about/', {                                       
              templateUrl: "templates/about.html",     
              controller: 'aboutController',  
          }) 
          .otherwise({                      
              template: 'does not exists'   
          });      
});
*/

/*

app.personController('sqlTestController', ['$scope', sqlTestController]);

function sqlTestController($scope, $http) {
    $scope.helloSql = "Hey there, i coulda been sql";
}

*/

/*
app.controller('serviceController', [
    '$scope',
    function serviceController($scope) {
        $http.get("http://localhost/WebApiService/api/customers")
            .success(
                function(response) {
                     $scope.customers = response;
                });
    }
]);
*/


app.controller('sqlTestController', [
    '$scope',
    function sqlTestController($scope) {
        $scope.customers =
            [
                { "Company": "ACME", "City": "abc", "Country": "USA" },
                { "Company": "Some", "City": "other", "Country": "place" }
            ];
    }
]);


app.controller('homeController', [              
    '$scope',                              
    function homeController($scope) {        
        $scope.message = 'HOME PAGE';                  
    }                                                
]);                                                  

app.controller('aboutController', [                  
    '$scope',                               
    function aboutController($scope) {        
        $scope.about = 'WE LOVE CODE';                       
    }                                                
]);

