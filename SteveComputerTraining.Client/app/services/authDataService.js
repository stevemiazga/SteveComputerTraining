'use strict';
app.factory('authDataService', function () {
     
    var authData = {
        token: "",
        userName: ""
    };

    var setAuthData = function (token, username) {
        authData.username = username;
        authData.token = token;
    };

    var getAuthData = function () {
        return authData;
    }

    return {
        setAuthData: setAuthData,
        getAuthData: getAuthData
    }
    
});