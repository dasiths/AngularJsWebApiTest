// <reference path="Module.js">
// <reference path="Service.js">

app.controller('BookListController', function BookListController($scope, $http, crudService) {
    $scope.status = 'Loading books...';
    $scope.IsNewRecord = 1; //The flag for the new record

    loadAllBooks();

    function loadAllBooks() {

        var promise = crudService.getAllBooks();

        promise.then(
            function (response) {
                $scope.Books = response.data;
                $scope.status = 'Loaded. Code: ' + response.status;
            },
            function (error) {
                $scope.Books = null;
                $scope.status = 'Error: ' + error;
                $log.error('failure loading Books', error);
            });
    }

    //Method to save and add
    $scope.save = function () {
        var Book = {
            Id: $scope.BookId,
            Name: $scope.BookName,
            Author: $scope.BookAuthor
        };

        //If the flag is 1 the it is a new record
        if ($scope.IsNewRecord === 1) {
            var promisePost = crudService.post(Book);
            promisePost.then(function (result) {
                $scope.BookId = result.data;
                loadAllBooks();
            }, function (error) {
                $scope.status = 'Error: ' + error;
                console.log("Err" + error);
            });
        } else { //Else Edit the record
            var promisePut = crudService.put($scope.BookId, Book);
            promisePut.then(function (result) {
                $scope.status = "Updated Successfuly";
                loadAllBooks();
            }, function (error) {
                $scope.status = 'Error: ' + error;
                console.log("Err" + error);
            });
        }

    }

    //Method to Delete
    $scope.delete = function () {
        var promiseDelete = crudService.delete($scope.BookId);
        promiseDelete.then(function (result) {
            $scope.status = "Deleted Successfuly";
            $scope.BookId = 0;
            $scope.BookName = "";
            $scope.BookAuthor = "";

            loadAllBooks();
        }, function (error) {
            $scope.status = 'Error: ' + error;
            console.log("Err" + error);
        });
    }

    //Method to Get Single Book
    $scope.get = function (Book) {
        var promiseGetSingle = crudService.get(Book.id);

        promiseGetSingle.then(function (result) {
            var res = result.data;
            $scope.BookId = res.id;
            $scope.BookName = res.name;
            $scope.BookAuthor = res.author;

            $scope.IsNewRecord = 0;
        },
            function (errorPl) {
                console.log('failure loading Employee', errorPl);
            });
    }

    //Clear the Scope models
    $scope.clear = function () {
        $scope.status = "";
        $scope.IsNewRecord = 1;
        $scope.BookId = 0;
        $scope.BookName = "";
        $scope.BookAuthor = "";
    }


});