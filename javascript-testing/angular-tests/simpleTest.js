function mySimpleController($scope, $http) {

    $scope.appName = "Hello world!!";

    $scope.doSomething = function () {
        return "I'm doing something..."
    }


    //------------------------------------------------------------------------
    // Using a module
    //------------------------------------------------------------------------

    // Need to install node to do this: npm init
    // var testModule = require('./testModule.js')
    // $scope.sayHello = testModule.sayHello();
    // $scope.speakSpanish = testModule.sayHelloEnEspanol();

}