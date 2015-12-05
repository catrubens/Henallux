angular.module('SchoolApp', ['ngRoute'])
    .config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: 'partials/Students/List.html',
            controller: 'StudentsCtrl'
        }).
        otherwise({ redirectTo: '/' });
    }])
    .controller('StudentsCtrl', function ($scope, $http) {
        $http.get("/api/students").success(function (data, status, headers, config) {
            $scope.students = data;
        }).error(function (data, status, headers, config) {
            console.log("something went wrong!!!");
        });
    });