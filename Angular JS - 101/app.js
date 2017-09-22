angular.module('weatherApp', [])
    .controller("weatherController",
    function($scope) {
        $scope.description = "A simple weather app.";
        console.log('weatherController created!')

        $scope.initialize = function() {

            if (typeof (Storage) != "undefined") {
                console.log("We have storage!");
            }
            else {
                console.log("Sorry buddy, no storage.");
            }

            var name;
            name = localStorage.getItem("storageTestName");
            if ((name == null) || (name.length < 1)) {
                name = "New Name";
                localStorage.setItem("storageTestName", name);
            }
            else {
                name = name + "*";
                localStorage.setItem("storageTestName", name);
            }
            console.log("Hi " + name + "!");

            console.log("You be inited.");
        }

        $scope.initialize();

    }
    );

