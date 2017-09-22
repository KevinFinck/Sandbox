function javascriptWay() {
    var obj = document.getElementById("h01");
    obj.innerHTML = "Hello jQuery";
}

function prototypeWay() {
    $("h01").insert("Hello Prototype!");

    $("h01").writeAttribute("style", "color:red").insert("Hello Prototype!");
}



function initializePage() {
    //document.getElementById("testButton").onclick = javascriptWay;
}

//onload = initializePage;
Event.observe(window, "load", prototypeWay);
