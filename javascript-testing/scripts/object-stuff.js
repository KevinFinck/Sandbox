
var samples =
{
    // -----------------------------------------------------------------------
    // Object Definition
    // -----------------------------------------------------------------------
    objectDefinition: function ()
    {
        console.log("Object Definition Examples");

        // -------------------------------------------------------------------
        var person = {};
        person.firstName = "John";
        person.lastName = "Doe";
        console.log(person.firstName + " " + person.lastName);

        // -------------------------------------------------------------------
        var otherPerson =
        {
            firstName: "Jane",
            lastName: "Doe"
        };
        console.log(otherPerson.firstName + " " + otherPerson.lastName);

        // -------------------------------------------------------------------
        var people = {};
        people["person"] = person;
        people["otherPerson"] = otherPerson;

        console.log(people["person"].firstName);
        console.log(people["otherPerson"].firstName);
    },

    // -----------------------------------------------------------------------
    // Object Literal
    // -----------------------------------------------------------------------
    objectLiteral: function () {
        console.log("Object Literal Examples");

        var myObject =
        {
            sayHello: function ()
            {
                console.log("hello");
            },

            myName: "Rebecca"
        };

        myObject.sayHello(); // "hello"
        console.log(myObject.myName); // "Rebecca"

        var myOther =
        {
            myName: "Becca"
        };
        myOther.sayHello = function () {
            console.log("Hello from me too.");
        };
        myOther.sayHello();
    },


    // -----------------------------------------------------------------------
    // Object Traversal
    // -----------------------------------------------------------------------
    objectTraversal: function () {
        console.log("Object Traversal");

        dump("myObject", this.myObject);

        var myObject1 = {
            validIdentifier: 123,
            "some string": 456,
            99999: 789
        };
        dump("myObject1", myObject1);
    },

    testFindParents: function () {
        console.log("*** findParents() ***");
        var a = {
            'light': 'good',
            'dark': {
                'black': 'bad',
                'gray': 'not so bad'
            }
        }
        console.log("Look for parent in: ");
        dump("a", a);

        var objparents = findParents(a, 'dark', 'a');

        dump("Parents", objparents);
    },

    testPrototypeModification: function() {
        console.log("*** testPrototypeModification() ***");
        try {
            "Abc".myFunction();
        } catch (ex) {
            console.log("Abc.myFunction: \n\t" + ex.message);
        }

        // No-no:
        String.prototype.myFunction = function () {
            console.log("You called myFunction. Thank you! :D");
        }
        "Try Again".myFunction();

        // Better:
        MyString = Object.create(String);
        MyString.myFunction = function () {
            console.log("Thanks for not changing the built-in prototype.");
        }

        var x = Object.create(MyString);
        console.log("x.myFunction:\t");
        x.myFunction();

        // Betterer
        var y = MyString;
        y = "It's all me baby!";
        console.log("y = " + y);
        console.log("y.myFunction:");
        y.myFunction();
    },

    testInheritance: function() {
        console.log("*** testInheritance() ***");
        var o = {
            a: 2,
            m: function(b) {
                return this.a + 1;
            },
            m1: function(b) {
                // return a + 1;  "a" is undefined
                return "";
            }
        }
        console.log(o.m()); // 3
        console.log(o.m1());
        // When calling o.m in this case, 'this' refers to o

        var p = Object.create(o);
        // p is an object that inherits from o

        p.a = 12; // creates an own property 'a' on p
        console.log(p.m()); // 13
        console.log(p.m1());
        // when p.m is called, 'this' refers to p.
        // So when p inherits the function m of o, 
        // 'this.a' means p.a, the own property 'a' of p        


        o = { a: 1 };
        // The newly created object o has Object.prototype as its [[Prototype]]
        // o has no own property named 'hasOwnProperty'
        // hasOwnProperty is an own property of Object.prototype. 
        // So o inherits hasOwnProperty from Object.prototype
        // Object.prototype has null as its prototype.
        // o ---> Object.prototype ---> null

        var a = ["yo", "whadup", "?"];
        // Arrays inherit from Array.prototype 
        // (which has methods like indexOf, forEach, etc.)
        // The prototype chain looks like:
        // a ---> Array.prototype ---> Object.prototype ---> null

        function f() {
            return 2;
        }
        // Functions inherit from Function.prototype 
        // (which has methods like call, bind, etc.)
        // f ---> Function.prototype ---> Object.prototype ---> null
    },

    testConstructor: function() {
        console.log("*** testConstructor ***");
        function myGraph() {
            this.vertices = [];
            this.edges = [];
        }

        myGraph.prototype = {
            addVertex: function (v) {
                this.vertices.push(v);
            }
        };

        var g = new myGraph();
        dump("g.vertices", g.vertices);
        g.vertices.push(1);
        g.addVertex(2);
        dump("g.vertices", g.vertices);
        dump("", g);

        // g is an object with own properties 'vertices' and 'edges'.
        // g.[[Prototype]] is the value of Graph.prototype when new Graph() is executed.
    },

    testObjectCreate: function () {
        console.log("*** testObjectCreate() ***");

        var a = { val: 1 };
        // a ---> Object.prototype ---> null

        var b = Object.create(a);
        // b ---> a ---> Object.prototype ---> null
        console.log("b.a: " + b.val); // 1 (inherited)

        var c = Object.create(b);
        // c ---> b ---> a ---> Object.prototype ---> null
        console.log("a.hasOwnProperty(\"val\"): " + a.hasOwnProperty("val"));
        console.log("b.hasOwnProperty(\"val\"): " + b.hasOwnProperty("val"));

        var d = Object.create(null);
        // d ---> null
        console.log("d.hasOwnProperty: " + d.hasOwnProperty);
        // undefined, because d doesn't inherit from Object.prototype
    }}


// ---------------------------------------------------------------------------
// Global functions.
// ---------------------------------------------------------------------------

function findParents(obj, key, rootName) {
    // NOTE: Prototype functions;  Object.getPrototypeOf() and Object.setPrototypeOf().
    var parentName = rootName || 'ROOT', result = [];
    function iterate(obj, doIndent){
        var parentPrevName = ''
        for (var property in obj) {
            if (obj.hasOwnProperty(property)){

                if (obj[property].constructor === Object) {
                    parentPrevName = parentName;
                    parentName = property;
                    iterate(obj[property]);
                    parentName = parentPrevName;
                }
                if (key === property) {
                    result.push('Found parent for key ['
                                    +key+' (value: '+obj[property]
                                    +')] => '+parentName);
                }

            }
        }
    }
    iterate(obj);
    return result;
}

function dump(name, object) {
    console.log("***" + name + "***");
    for (var prop in object) {
        // Determine if the property is on the object itself.
        // (not on the prototype)
        if (object.hasOwnProperty(prop)) {
            console.log("Property : " + prop + " ; value : " + object[prop]);
        }
    }
}



// ---------------------------------------------------------------------------
// Main
// ---------------------------------------------------------------------------

function Main() {
    //samples.objectDefinition();
    //samples.objectLiteral();
    //samples.objectTraversal();
    //samples.testFindParents();
    samples.testPrototypeModification(); "Testing Prototype scope.".myFunction();
    //samples.testInheritance();
    //samples.testConstructor();
    samples.testObjectCreate();
}

$(document).ready(Main());
