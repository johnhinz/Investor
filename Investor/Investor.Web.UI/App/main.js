function ClientGet($scope, $http) {
    $http.get('http://localhost:13254/api.invest.com/clients/1').
        success(function (data) {
            $scope.clients = data;
        });
}

