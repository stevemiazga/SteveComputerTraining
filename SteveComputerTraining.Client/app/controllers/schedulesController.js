'use strict';
app.controller('schedulesController', ['$scope', '$location', 'schedulesService', 'sessionsService' ,'authService', function ($scope, $location ,schedulesService, sessionsService,authService) {

    $scope.schedules = [];

    schedulesService.getSchedules().then(function (results) {

        $scope.schedules = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

    $scope.authentication = authService.authentication;

    $scope.backHome = function () {
        $location.path("/home");
    }

    $scope.reserveSeat = function (schedule) {
        $location.path("/reserve/" + schedule.scheduleId);

    };


}]);