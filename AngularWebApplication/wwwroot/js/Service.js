app.service('crudService', function ($http) {

    var baseUrl = 'http://localhost:50829/'

    //Create new record
    this.post = function (Book) {
        var request = $http({
            method: "post",
            url: baseUrl + "/api/books",
            data: Book
        });
        return request;
    }
    //Get Single Records
    this.get = function (Id) {
        return $http.get(baseUrl + "/api/books/" + Id);
    }

    //Get All Books
    this.getAllBooks = function () {
        return $http.get(baseUrl + "/api/books");
    }
    
    //Update the Record
    this.put = function (Id, Book) {
        var request = $http({
            method: "put",
            url: baseUrl + "/api/books/" + Id,
            data: Book
        });
        return request;
    }

    //Delete the Record
    this.delete = function (Id) {
        var request = $http({
            method: "delete",
            url: baseUrl + "/api/books/" + Id
        });
        return request;
    }
});