app = angular.module('mainApp', []);

app.controller('ngCustomerController',
    ['$scope',
    function ngCustomerController($scope) {

        $scope.customers = [
            { Id: 1, Company: 'abc', City: 'Jani', Country: 'Norway' },
            { Id: 2, Company: 'def', City: 'Hege', Country: 'Sweden' },
            { Id: 3, Company: "ACME", City: "abc", Country: "USA"}
        ];

    }
]);

