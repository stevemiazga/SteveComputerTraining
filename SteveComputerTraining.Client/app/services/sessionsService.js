'use strict';
app.factory('sessionsService', ['$http', function ($http) {

    //var serviceBase = 'http://localhost:2845/';
    //var serviceBase = 'http://localhost:88/';
    var serviceBase = 'http://stevecomputertrainingwebapi.azurewebsites.net/';
    var sessionsServiceFactory = {};

    var _getSessionsByUserName = function (userName) {

        return $http.get(serviceBase + 'api/sessions/' + userName).then(function (results) {
            return results;
        });
    };

    var _getSessionBySessionId = function (sessionId) {

        return $http.get(serviceBase + 'api/sessions/' + sessionId).then(function (results) {
            return results;
        });
    };

    var _existsSessionReserveByScheduleId = function (userName, scheduleId) {

        return $http.get(serviceBase + 'api/sessions/' + userName + '/exists/' + scheduleId).then(function (results) {
            return results;
        });
    };

    var _createSession = function (session) {

        return $http.post(serviceBase + 'api/sessions', session);
    };

    var _deleteSession = function (sessionId) {

        return $http.delete(serviceBase + 'api/sessions/' + sessionId);
    };

    sessionsServiceFactory.getSessionBySessionId = _getSessionBySessionId;
    sessionsServiceFactory.createSession = _createSession;
    sessionsServiceFactory.getSessionsByUserName = _getSessionsByUserName;
    sessionsServiceFactory.deleteSession = _deleteSession;
    sessionsServiceFactory.existsSessionReserveByScheduleId = _existsSessionReserveByScheduleId;

    return sessionsServiceFactory;

}]);