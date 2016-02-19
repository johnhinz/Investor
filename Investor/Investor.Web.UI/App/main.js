app.controller('ClientController', function ($scope, $http) {
    $scope.clients = [];
    
    $http.get('http://localhost:13254/api.invest.com/clients/1')
        .success(function (data) {
                $scope.clients = data;
                console.log(data);
        })
        .error(function (data) {
            console.log('Error: ' + data);
        })
    }
);
