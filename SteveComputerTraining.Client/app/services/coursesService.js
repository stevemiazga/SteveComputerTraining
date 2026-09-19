'use strict';
app.factory('coursesService', ['$http', function ($http) {

    var serviceBase = 'http://stevecomputertrainingwebapi.azurewebsites.net/';
    var coursesServiceFactory = {};

    var _getCourses = function () {

        return $http.get(serviceBase + 'api/courses').then(function (results) {
            return results;
        });
    };

    coursesServiceFactory.getCourses = _getCourses;

    return coursesServiceFactory;

}]);