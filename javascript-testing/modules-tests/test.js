// ECMAScript 6, requires webpack or such:   import {getHelloMessage} from './myModule.js';

var myMod = require("./myModule.js");

function testMe() {
    showMe();
}

function showMe() {
    alert("I'm showing: " + myMod.myHello);
}
