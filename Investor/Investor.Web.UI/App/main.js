var app;
(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', main);

    function main() {
        var vm = this;
        vm.food = 'pizza';
    }
})();

app.controller('ClientController', function ($scope, ClientService) {
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


app.factory('ClientService', ['$http', function ($http) {
    var urlBase = 'http://localhost:13254/api.invest.com/clients';
    var ClientService = {};
    ClientService.getClients = function () {
        return $http.get(urlBase + '/3');
    };
    return ClientService;
}]);
