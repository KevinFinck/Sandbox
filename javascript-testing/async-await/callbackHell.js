"use strinct";

var Api = require("./Api.js");

(function callbackHell() {
  const api = new Api();
  let user, friends;

    api.getUser().then(function (returnedUser) {
        user = returnedUser
        api.getFriends(user.id).then(function (returnedFriends) {
          friends = returnedFriends
          api.getPhoto(user.id).then(function (photo) {
            console.log('callbackHell', { user, friends, photo })
          })
        })
    })
})();
