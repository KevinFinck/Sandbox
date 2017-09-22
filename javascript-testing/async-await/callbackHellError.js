"use strinct";

var Api = require("./Api.js");

function callbackHell() {
    const api = new Api();
    let user, friends
    api.getUser().then(function (returnedUser) {
      user = returnedUser

      api.getFriends(user.id).then(function (returnedFriends) {
        friends = returnedFriends

        api.throwError().then(function () {
          console.log('Error was not thrown')

          api.getPhoto(user.id).then(function (photo) {
            console.log('callbackErrorHell', { user, friends, photo })
          }, function (err) {
            console.error(err)
          })
        }, function (err) {
          console.error(err)
        })
      }, function (err) {
        console.error(err)
      })
    }, function (err) {
      console.error(err)
    })
}
callbackHell();

