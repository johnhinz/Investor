app.controller('ClientController', function ($scope, $http) {
    $scope.clients = [];
    $http.get('http://localhost:13254/api.invest.com/clients/1')
        .success(function (response) {
                $scope.clients = response.data;
        })
        .error(function (response) {
            console.log('Error: ' + response.data);
        })
    }
);
