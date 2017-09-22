app = angular.module('simpleTest', []);                                                                             

function personController($scope, $http) {
    $scope.firstName = "Big";
    $scope.lastName = "Doe";
    $scope.fullName = function() {
        return $scope.firstName + " " + $scope.lastName + "!!";
    };

    $scope.nameArray = [
        { name: 'Jani', country: 'Norway' },
        { name: 'Hege', country: 'Sweden' },
        { name: 'Kai', country: 'Denmark' }
    ];

    // Read JSON file into model.
    // NOTE: Url below will not be returned by IIS.
    // var url = location.protocol + "//" + location.host + "/ajax/customers.json";
    $http
        //.get(url)
        .get("http://www.w3schools.com/website/Customers_JSON.php") // Using externally available file.
        .success(function (response) { $scope.names = response; })
        .error(function (data, status, headers, config) {
            alert("Error retrieving data: " + status);
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        })
    ;

}
