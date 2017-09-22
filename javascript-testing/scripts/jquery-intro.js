function javascriptWay() {
    var obj = document.getElementById("h01");
    obj.innerHTML = "Hello jQuery";
}

function jQueryWay() {
    $("#h01").attr("style", "color: red").html("Hello jQuery");
}

function initializePage() {
    //document.getElementById("testButton").onclick = javascriptWay;
    document.getElementById("testButton").onclick = jQueryWay;
}

onload = initializePage;