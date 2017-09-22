
var add = // add will get the RETURN VALUE of the self invoking function
    (   // Parens required to allow () to self-invoke this function.
        function () {           // Anonymous run-once function
            var counter = 0;    
            return function () { return counter += 1; } // Function returned and assigned to add.
        }
    )();

add();
add();
add();

// the counter is now 3