//----------------------------------------------------------------------------
// Other settings
//----------------------------------------------------------------------------
"use strict";



//----------------------------------------------------------------------------
// Enable jQuery in console:
//----------------------------------------------------------------------------
var jq = document.createElement('script');
jq.src = "https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js";
document.getElementsByTagName('head')[0].appendChild(jq);


//----------------------------------------------------------------------------
// Enable jQuery in console:
//----------------------------------------------------------------------------
// protype is forbidden...

//I don't see that much of a problem when you know that Object.prototype has been modified. I will use your example to explain a logical solution:

Object.prototype.hello = "hello"; // we extend Object.prototype with property "hello", that's what you said is forbidden.

var obj = {a: "A", b: "B", c: "C", d: "D"}; // create instance of Object
for (var key in obj) {
    console.log(key); // this will output: a,b,c,d,hello
}

//If you just simply add an if statement:
for (var key in obj) {
    if(obj.hasOwnProperty(key)) {
        console.log(key); // this will output: a,b,c,d but NOT hello
    }
}

// How about modifying object.prototype with defineProperty and enumerable: false?


//----------------------------------------------------------------------------
// Show number of AngularJS watchers.
//----------------------------------------------------------------------------
(function () {
    var root = $(document.getElementsByTagName('body'));
    var watchers = [];

    var f = function (element) {
        if (element.data().hasOwnProperty('$scope')) {
            angular.forEach(element.data().$scope.$$watchers, function (watcher) {
                watchers.push(watcher);
            });
        }

        angular.forEach(element.children(), function (childElement) {
            f($(childElement));
        });
    };

    f(root);

    console.log(watchers.length);
})();