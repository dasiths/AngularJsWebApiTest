// Define the `BookListController` controller on the `BookcatApp` module
app.controller('BookListController', function BookListController($scope, $http, crudService) {
    $scope.status = 'Loading books...';

    loadAllBooks();

    function loadAllBooks() {

        var promise = crudService.getAllBooks();

        promise.then(
            function (response) {
                $scope.Books = response.data;
                $scope.status = 'Loaded. Code: ' + response.status;
            },
            function (data) {
                $scope.Books = null;
                $scope.status = 'Error: ' + data;
            });
    }


});