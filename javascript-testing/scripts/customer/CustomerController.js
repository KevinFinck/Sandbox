(function () {
    'use strict';

    var controllerId = 'customer';
    angular.module('app')
        .controller(controllerId, ['$scope', '$http', customer]);

    function customer($scope, $http) {
        $scope.customers =
        [
            { "Company": "ACME", "City": "abc", "Country": "USA" },
            { "Company": "Some", "City": "other", "Country": "place" }
        ];

        return $http.get("/api/customers")
            .success(function (response) {
                var result = response;
            });
    }
})();
