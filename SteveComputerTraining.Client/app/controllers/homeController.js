'use strict';
app.controller('homeController', ['$scope', 'coursesService','schedulesService' ,function ($scope, coursesService, schedulesService) {
    $scope.viewLoading = true;

    $scope.courses = [];
    $scope.categories = [];
    var category = {
        category: ""
    };

    coursesService.getCourses().then(function (results) {

        $scope.courses = results.data;

    }).then(function () { 
        schedulesService.updateScheduleDates();
        angular.forEach($scope.courses, function (courseitem, index) {
            var exists = false;

            angular.forEach($scope.categories, function(categoryitem, index){
                if (courseitem.category == categoryitem.category){
                    exists = true;
                }
            });

            if (exists == false) {
                var category = {};
                category.category = courseitem.category;
                $scope.categories.push(category);
            }

        });

        $scope.viewLoading = false;

    }), function (error) {
        //alert(error.data.message);
    };

}]);