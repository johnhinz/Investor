app.controller('ClientController', function ($scope, $http) {
    $scope.clients = [];

    $scope.submit = function(){  
        //$http.get('http://localhost:13254/api.invest.com/clients/' + $scope.clientId)
        //    .success(function (data) {
        //            $scope.clients = data;
        //            console.log(data);
        //        })
        //    .error(function (data) {
        //        console.log('Error: ' + data);
        //    })

        $http.get('http://localhost:13254/api.invest.com/clients/' + $scope.clientId), 
                    { headers: { 'Authorization': 'Basic dXNlcjpwYXNz' } }
            .success(function (data) {
                    $scope.clients = data;
                    console.log(data);
                })
            .error(function (data) {
                console.log('Error: ' + data);
            })

 
    }

});
