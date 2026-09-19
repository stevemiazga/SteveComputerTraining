'use strict';
app.factory('schedulesService', ['$http', function ($http) {

    var serviceBase = 'http://stevecomputertrainingwebapi.azurewebsites.net/';
    var schedulesServiceFactory = {};

    var _getSchedules = function () {

        return $http.get(serviceBase + 'api/schedules').then(function (results) {
            return results;
        });
    };

    var _getSchedule = function (id) {

        return $http.get(serviceBase + 'api/schedules/' + id).then(function (results) {
            return results;
        });
    };

    var _updateScheduleSeats = function (schedule) {
        return $http.put(serviceBase + 'api/schedules/' + schedule.scheduleId,schedule);
    };

    var _updateScheduleDates = function () {
        return $http.put(serviceBase + 'api/schedules/dates/');
    };

    schedulesServiceFactory.getSchedules = _getSchedules;
    schedulesServiceFactory.getSchedule = _getSchedule;
    schedulesServiceFactory.updateScheduleSeats = _updateScheduleSeats;
    schedulesServiceFactory.updateScheduleDates = _updateScheduleDates;

    return schedulesServiceFactory;

}]);