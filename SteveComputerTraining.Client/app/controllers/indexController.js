'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {


    $scope.dateTitle = (function () {
        var currentDate = new Date();
        var currentYear = currentDate.getFullYear();
        if (currentYear == 2016)
        {
            return currentYear;
        }
        else
        {
            return "2016 - " + currentYear
        }
    }());

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

    $scope.authentication = authService.authentication;

    var url = $location.url();

    if (authService.authentication.isAuth == false && (url.substring(1,4) == 'res' || url.substring(1,4) == 'ses')) {
        $location.path('/home');
    }

}]);