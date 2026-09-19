'use strict';
app.factory('authInterceptorService', ['$q', '$location', 'authDataService', function ($q, $location, authDataService) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        //smiazga
        //var authData = localStorageService.get('authorizationData');
        var authData = authDataService.getAuthData();
        //if (authData) {
        if (authData.token != "") {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    };

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            $location.path('/login');
        }
        return $q.reject(rejection);
    };

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);