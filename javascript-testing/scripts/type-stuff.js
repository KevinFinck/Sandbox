/*global console: false, jQuery: false */
///<refernce path="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js" />

//var page = new Object();

//page.typedFunction = function (paramsList, f) {
function typedFunction(paramsList, f) {
    //optionally, ensure that typedFunction is being called properly  -- here's a start:
    if (!(paramsList instanceof Array)) throw Error('invalid argument: paramsList must be an array');

    //the type-checked function
    return function () {
        for (var i = 0, p, arg; p = paramsList[i], arg = arguments[i], i < paramsList.length; i++) {
            if (typeof p === 'string') {
                if (typeof arg !== p) throw new Error('expected type ' + p + ', got ' + typeof arg);
            }
            else { //function
                if (!(arg instanceof p)) throw new Error('expected type ' + String(p).replace(/\s*\{.*/, '') + ', got ' + typeof arg);
            }
        }
        //type checking passed; call the function itself
        return f.apply(this, arguments);
    }
}

//page.testTypedFunction = function() {
function testTypedFunction() {
    console.log("*** testTypedFunction() ***");

    
    //usage:
    var ds = typedFunction([Date, 'string'], function (d, s) {
        console.log(d.toDateString(), s.substr(0));
    });

    //Error: expected type function Date(), got string
    try {
        ds('notadate', 'test');
    } catch (ex) {
        alert(ex.message);
    }

    //Error: expected type function Date(), got undefined
    try {
        ds();
    } catch (ex) {
        alert(ex.message);
    }

    //Error: expected type string, got number
    try {
        ds(new Date(), 42);
    } catch (ex) {
        alert(ex.message);
    }

    ds(new Date(), 'success');
}


function testHtmlString() {
    console.log("*** testHtmlString() ***");

    console.log($("<b>hello</b><br/>").appendTo("body"));

    // Appends <b>hello</b>:
    console.log($("<b>hello</b>bye<br/>").appendTo("body"));

    // Syntax error, unrecognized expression: bye<b>hello</b>
    try {
        console.log($("bye<b>hello</b>").appendTo("body"));
    } catch (ex) {
        alert(ex.message);
    }

    // Appends bye<b>hello</b>:
    console.log($($.parseHTML("bye<b>hello</b><br/>")).appendTo("body"));

    // Appends bye<b>hello</b>:
    console.log($($.parseHTML("bye<b>hello</b><br/>")).appendTo("body"));

    // Appends <b>hello</b>wait<b>bye</b>:
    console.log($("<b>hello</b>wait<b>bye</b><br/>").appendTo("body"));

}

function testMath() {
    console.log("*** testMath() ***");

    var arr = [1234563995.721, 12345691212.718, 1234568421.5891, 12345677093.49284];

    var sum = 0;
    for (var i = 0; i < arr.length; i++) {
        sum += arr[i];
        console.log(arr[i]);
    }

    console.log("Math.round(sum) = " + Math.round(sum * 1e12) / 1e12);
    console.log("sum.toFixed(precision) = " + sum.toFixed(5));

    // Add decimals together, requires rounding to get expected result.
    console.log("0.1 + 0.2 = " + (Math.round((0.1 + 0.2) * 1e12) / 1e12));
    console.log("0.1 + 0.2 = " + ((0.1 + 0.2).toFixed(5)));
}

function testIteration() {
    console.log("*** testIteration() ***");

    var obj = {
        name: "Pete",
        age: 15
    };
    for( key in obj ) {
        console.log( "key is " + [ key ] + ", value is " + obj[ key ] );
    }
    // Note that for-in-loop can be spoiled by extending Object.prototype (see Object.prototype is verboten) so take care when using other libraries.

    // jQuery provides a generic each function to iterate over properties of objects, as well as elements of arrays:

    jQuery.each( obj, function( key, value ) {
        console.log( "key", key, "value", value );
    });

}


//----------------------------------------------------------------------------
// Test Items
//----------------------------------------------------------------------------
//page.testAll = function() {
function testAll() {
    //testTypedFunction();
    //testHtmlString();
    //testMath();
    testIteration();
}

//$(document).ready(page.testAll());
$(document).ready(testAll());
