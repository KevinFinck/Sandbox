var debugAjaxCall = false;

function showOtherAjaxResult(xmlhttp) {
    if (debugAjaxCall)
        alert("ReadyState: " + xmlhttp.readyState +
              "\nStatus: " + xmlhttp.status);
}

function loadXMLDoc() {

    var xmlhttp;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            document.getElementById("ajaxTestDiv").innerHTML = xmlhttp.responseText;
        } else { showOtherAjaxResult(xmlhttp); }
    }

    xmlhttp.open("GET", "ajax_test_data.html", true);
    // To prevent cached response, add unique id to url: 
    // xmlhttp.open("GET", "demo_get.asp?t=" + Math.random(), true);

    xmlhttp.send();


    // Example to po
}

function masterAjaxCall(url, callBackFunction) {
}

function useMasterAjaxCall() {
    masterAjaxCall("ajax_info.txt", function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            document.getElementById("ajaxTestDiv").innerHTML = xmlhttp.responseText;
        }
    });
}


function ajaxPostFormData() {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open("POST", "ajax_test.asp", true);
    xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xmlhttp.send("fname=Henry&lname=Ford");
}

function ajaxSyncCall() {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open("GET", "ajax_info.txt", false);
    xmlhttp.send();
    document.getElementById("ajaxTestDiv").innerHTML = xmlhttp.responseText;
}

function ajaxWithXmlResposne() {
    var xmlhttp = new XMLHttpRequest();
    //...make call...

    var xmlDoc = xmlhttp.responseXML;
    var txt = "";
    var x = xmlDoc.getElementsByTagName("ARTIST");
    for (var i = 0; i < x.length; i++) {
        txt = txt + x[i].childNodes[0].nodeValue + "<br>";
    }
    document.getElementById("ajaxTestDiv").innerHTML = txt;
}



function buildTableFromAjaxResultTest() {
    buildTableFromAjaxResult("ajax/cd_catalog.xml");
}
function buildTableFromAjaxResult(url) {
    var xmlhttp;
    var txt, xx, x, i;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            txt = "<table border='1'><tr><th>Title</th><th>Artist</th></tr>";
            x = xmlhttp.responseXML.documentElement.getElementsByTagName("CD");
            for (i = 0; i < x.length; i++) {
                txt = txt + "<tr>";
                xx = x[i].getElementsByTagName("TITLE");
                {
                    try {
                        txt = txt + "<td>" + xx[0].firstChild.nodeValue + "</td>";
                    }
                    catch (er) {
                        txt = txt + "<td>&nbsp;</td>";
                    }
                }
                xx = x[i].getElementsByTagName("ARTIST");
                {
                    try {
                        txt = txt + "<td>" + xx[0].firstChild.nodeValue + "</td>";
                    }
                    catch (er) {
                        txt = txt + "<td>&nbsp;</td>";
                    }
                }
                txt = txt + "</tr>";
            }
            txt = txt + "</table>";
            document.getElementById('ajaxTestDiv').innerHTML = txt;
        } else { showOtherAjaxResult(xmlhttp); }
    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}








//function addButton(buttonId, label, funcName) {
function addButton(buttonId, funcName) {
        $("#divButtons")
        .prepend("<input id=\"" + buttonId + "\" type=\"button\" value=\" Run " + funcName + " \" onclick=\"" + funcName + "()\" />&nbsp&nbsp;");
//    $(buttonId).click(func);
}



function initializePage() {
    addButton("ajaxTestButton", "loadXMLDoc");
    addButton("buildTableFromAjaxResultTestButton", "buildTableFromAjaxResultTest");
}


$(document).ready(initializePage);
