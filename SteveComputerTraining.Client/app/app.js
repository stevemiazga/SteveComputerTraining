var app = angular.module('ComputerTrainingApp', ['ngRoute']);

//app.config(function ($provide) {
//    $provide.decorator("$exceptionHandler",
//        ["$delegate",
//            function ($delegate) {
//                return function (exception, cause) {
//                    exception.message = "An error occurred. Please see if can try again. \n Message: " +
//                                                            exception.message;
//                    $delegate(exception, cause);
//                    alert(exception.message);
//                };
//            }]);
//});

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/about", {
        templateUrl: "/app/views/about.html"
    });

    $routeProvider.when("/contact", {
        templateUrl: "/app/views/contact.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/schedules", {
        controller: "schedulesController",
        templateUrl: "/app/views/schedules.html"
    });

    $routeProvider.when("/reserve/:scheduleId", {
        controller: "reserveController",
        templateUrl: "/app/views/reserve.html"
    });

    $routeProvider.when("/sessions/:userName", {
        controller: "sessionsController",
        templateUrl: "/app/views/sessions.html"
    });

    $routeProvider.when("/session/:sessionId", {
        controller: "sessionsController",
        templateUrl: "/app/views/session.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();

}]);