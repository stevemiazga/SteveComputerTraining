'use strict';
app.controller('reserveController', ['$scope', '$location', '$routeParams', 'schedulesService','sessionsService', 'authService', function ($scope, $location, $routeParams ,schedulesService, sessionsService , authService) {

    $scope.schedule = [];

    $scope.reserveExists

    if (authService.authentication.isAuth) {
        sessionsService.existsSessionReserveByScheduleId(authService.authentication.userName, $routeParams['scheduleId']).then(function (results) {
            $scope.reserveExists = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    }

    schedulesService.getSchedule($routeParams['scheduleId']).then(function (results) {

        $scope.schedule = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

    $scope.saveReserve = function (schedule) {

        var session = {
            courseId: schedule.courseId,
            courseTitle: schedule.courseTitle,
            scheduleId: schedule.scheduleId,
            startDate: schedule.startDate,
            endDate: schedule.endDate,
            classTime: schedule.classTime,
            userName: authService.authentication.userName
        };

        schedule.remainingSeats = schedule.remainingSeats - 1;

        sessionsService.createSession(session).then(function () {
            schedulesService.updateScheduleSeats(schedule).then(function () {
                $location.path("/sessions/" + session.userName);
            });
        });

    };
    
    $scope.cancelReserve = function () {
        $location.path("/schedules");
    }

}]);