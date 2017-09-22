
function testLoad() {
    $("#ajaxTestDiv").load("ajax/demo_test.txt", function (responseTxt, statusTxt, xhr) {
        if (statusTxt == "success")
            alert("External content loaded successfully!");
        if (statusTxt == "error")
            alert("Error: " + xhr.status + ": " + xhr.statusText);
    });
}

function testLoadParagraph() {
    $("#ajaxTestDiv").load("ajax/demo_test.txt #p1");
}

function testAjaxCall() {
    $.ajax({
        url: "ajax/demo_test.txt", success: function (result) {
            $("#ajaxTestDiv").html(result);
        }
    });

}

function postTest() {
    //$.post("demo_test_post.asp",
    $.post("demo_test.txt",
    {
        name: "Donald Duck",
        city: "Duckburg"
    },
    function (data, status) {
        alert("Data: " + data + "\nStatus: " + status);
    });
}




//----------------------------------------------------------------------------
// Page load stuff.
//----------------------------------------------------------------------------

function addButton(buttonId, funcName) {
    $("#divButtons")
    .prepend("<input id=\"" + buttonId + "\" type=\"button\" value=\" Run " + funcName + " \" onclick=\"" + funcName + "()\" />&nbsp;&nbsp;");
    //    $(buttonId).click(func);
}

function initializePage() {
    addButton("testLoadButton", "testLoad");
    addButton("testLoadParagraph", "testLoadParagraph");
    addButton("testAjaxCall", "testAjaxCall");
    addButton("postTest", "postTest");
}

$(document).ready(initializePage);
