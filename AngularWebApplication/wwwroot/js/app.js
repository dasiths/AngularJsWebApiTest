// Define the `BookcatApp` module
var BookcatApp = angular.module('booksApp', []);

// Define the `BookListController` controller on the `BookcatApp` module
BookcatApp.controller('BookListController', function BookListController($scope, $http) {
    $http.get("http://localhost:50829/api/books")
        .then(function (response) {
            $scope.Books = response.data;
            $scope.hello = 'Loaded';
        });

    //$scope.Books = [
    //    {
    //        Name: 'Nexus S',
    //        Author: 'Fast just got faster with Nexus S.'
    //    }, {
    //        Name: 'Motorola XOOM™ with Wi-Fi',
    //        Author: 'The Next, Next Generation tablet.'
    //    }, {
    //        Name: 'MOTOROLA XOOM™',
    //        Author: 'The Next, Next Generation tablet.'
    //    }
    //];

    $scope.hello = 'Hello';
});