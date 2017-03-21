// Define the `BookcatApp` module
var BookcatApp = angular.module('booksApp', []);

// Define the `BookListController` controller on the `BookcatApp` module
BookcatApp.controller('BookListController', function BookListController($scope, $http) {
    $scope.status = 'Loading books...';

    $http.get("http://localhost:50829/api/books")
        .then(function (response) {
            $scope.Books = response.data;
            $scope.status = 'Loaded. Code: ' + response.status;
        },
        function (data) {
            $scope.Books = null;
            $scope.status = 'Error: ' + data;
        });    
});