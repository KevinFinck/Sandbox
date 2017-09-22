
function paragraphClickTest() {

    $("p")
        .click(function () {
            $(this).hide();
        })
    ;

}
function buttonPTest() {
    $("#testMe")
        .val("buttonPTest()")
        .attr("disabled", false)
        .click(function () { $("#idTest").toggle(); });

    $("#testMeToo")
        .val("buttonPTest 2")
        .attr("disabled", false)
        .click(function () { $(".test").fadeToggle(); });
};

function animateDiv() {
    var div =  $("div");
    div.css("background-color", "blue")
        .animate({ left: '250px' });
}
function animateTest() {
    $("#testMeAlso")
        .val("animateTest()")
        .attr("disabled", false)
        .click(animateDiv);
        //.click(function () { $("div").animate({ left: '250px' }); });
}


function callBackTest() {
    $("#testMe")
        .val("callBackTest")
        .attr("disabled", false)
        .click(function() {
        $("p").hide("slow", function() {
            alert("The paragraph is now hidden");
        });
    });
}

function callBackTest2() {
    //Not working, dunno why
    $("#testMe")
        .val("callBackTest2()")
        .attr("disabled", false)
        .click(function(){
            $("#idTest").text(function(i,origText){
                return "Old text: " + origText + " New text: Hello world! (index: " + i + ")"; 
            });
        });
}

function addButton() {
    $("#divButtons")
        .prepend("<input id=\"dynoButton1\" type=\"button\" value=\"Dynamic Button\" />");
    $("#dynoButton1").click(function() { alert("Hello dyno world!"); });
}

function addElementTest() {
    $("#testMeAlso")
        .val("addElementTest()")
        .attr("disabled", false)
        .click(addButton);
}

function initializePage() {
    paragraphClickTest();
    buttonPTest();
    //animateTest();
    callBackTest2();
    addElementTest();
}


$(document).ready(initializePage);
// Or: $(initializePage);

/* This is short-hand for $(document.ready(function () {...
$(function () {

    // jQuery methods go here...

});
*/


