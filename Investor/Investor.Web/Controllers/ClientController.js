'use strict'
MyApp.factory('ClientService', ['$http', function ($http) {
    var urlBase = 'http://localhost:13254/api.invest.com/clients';
    var ClientService = {};
    ClientService.getClients = function () {
        return $http.get(urlBase + '/3');
    };
    return ClientService;
}]);

MyApp.controller('ClientController', function ($scope, ClientService) {
    getClients();
    function getClients() {
        ClientService.getClients()
            .success(function (clients) {
                $scope.clients = clients;
            })
            .error(function (error) {
                $scope.status = 'Unable to load client data: ' + error.message;
            });
    }
});

