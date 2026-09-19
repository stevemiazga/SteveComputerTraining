'use strict';
app.controller('sessionsController', ['$scope', '$location', '$routeParams', 'sessionsService', 'schedulesService', 'authService', function ($scope, $location, $routeParams, sessionsService, schedulesService, authService) {

    if ($routeParams['userName'] != null) {
        $scope.sessions = [];

        sessionsService.getSessionsByUserName($routeParams['userName']).then(function (results) {

            $scope.sessions = results.data;

        }, function (error) {
            //alert(error.data.message);
        });

        $scope.deleteMarkSession = function (sessionId) {
            $location.path("/session/" +sessionId);
        }

        $scope.goSchedules = function () {
            $location.path("/schedules");
        }
    }

    if ($routeParams['sessionId'] != null) {

        $scope.session = [];

        sessionsService.getSessionBySessionId($routeParams['sessionId']).then(function (results) {

            $scope.session = results.data;

        }, function (error) {
            alert(error.data.message);
        });

        var userName = authService.authentication.userName

        $scope.cancelSession = function () {
            $location.path("/sessions/" + userName);
        };

        $scope.deleteSessionBySessionId = function (session) {
            schedulesService.getSchedule(session.scheduleId).then(function (results) {
                schedule = results.data;
                schedule.remainingSeats = schedule.remainingSeats + 1;
            }).then(function () {
                sessionsService.deleteSession(session.sessionId)}).then(function () {
                schedulesService.updateScheduleSeats(schedule).then(function () {
                    $location.path("/sessions/" + userName);
                });
            });
        };
    }
}]);