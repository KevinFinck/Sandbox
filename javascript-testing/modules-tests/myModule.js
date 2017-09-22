function helloModule(msg){
    window.alert(msg);
}

function getHelloMessage() {
    return "Hello world!!!";
}

export {helloModule, getHelloMessage as myHello}
