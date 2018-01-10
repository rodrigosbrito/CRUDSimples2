angular.module("MyApp")
.controller("GetAllClientesController", function ($scope, GetAllClientesService) {
    debugger;
    $scope.Clientes = null;
    GetAllClientesService.GetAll().then(function (d) {
        $scope.Clientes = d.data;
    }, function (error) {
        alert("Ocorreu um Erro");
    });
})
.factory("GetAllClientesService", function ($http) {
    var fac = {};
    fac.GetAll = function () {
        return $http.get("/Clientes/GetAll");
    }
    return fac;
});