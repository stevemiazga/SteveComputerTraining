'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        if ($scope.loginForm.$valid) {
            authService.login($scope.loginData).then(function (response) {

                $location.path('/sessions/' + $scope.loginData.userName);

            },
             function (err) {
                 //$scope.message = err.error_description;
                 $scope.message = err;
             });
        };
    }
}]);