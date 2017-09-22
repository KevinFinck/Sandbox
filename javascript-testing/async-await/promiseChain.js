var Api = require("./Api.js");

function promiseChain () {
    const api = new Api()
    let user, friends
    api.getUser()
      .then((returnedUser) => {
        user = returnedUser
        return api.getFriends(user.id)
      })
      .then((returnedFriends) => {
        friends = returnedFriends
        return api.getPhoto(user.id)
      })
      .then((photo) => {
        console.log('promiseChain', { user, friends, photo })
      })
  }
promiseChain();
