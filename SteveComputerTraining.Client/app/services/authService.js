'use strict';
app.factory('authService', ['$http', '$q', 'authDataService', function ($http, $q, authDataService) {

    var serviceBase = 'http://stevecomputertrainingwebapi.azurewebsites.net/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _addUser = function (userName) {

        return $http.post(serviceBase + 'api/user/' + userName, userName);
    }

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        //var data = "username=" + loginData.userName + "&password=" + loginData.password + "grant_type=password";

        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }).success(function (response) {

            //smiazga
            //localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });
            authDataService.setAuthData(response.access_token, loginData.userName);

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        //localStorageService.remove('authorizationData');
        authDataService.setAuthData("", "");
        _authentication.isAuth = false;
        _authentication.userName = "";

    };

    var _fillAuthData = function () {

        //var authData = localStorageService.get('authorizationData');
        var authData = authDataService.getAuthData();
        if (authData.token != "" && authData.userName != "") {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.addUser = _addUser;

    return authServiceFactory;
}]);