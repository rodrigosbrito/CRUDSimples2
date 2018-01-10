angular.module("MyApp")
.controller("CreateClienteController", function ($scope, CreateClienteService) {
    $scope.Cliente = {
        Nome: "",
        DataNascimento: "",
        Email: "",
        Ativo: false
    };
    $scope.CreateCliente = function (data) {
        debugger;
        $scope.Cliente = data;
        CreateClienteService.Create($scope.Cliente).then(function (d) {
            alert(d.data);
            if (d.data == "Sucesso") {
                window.location.href = "/Clientes";
            }
            $scope.submitText = "Salvar";
        });
    }
})
.factory("CreateClienteService", function ($http, $q) {
    var factory = {};
    factory.Create = function (data) {
        var defer = $q.defer();
        $http({
            url: "/Clientes/Create",
            method: "POST",
            data: JSON.stringify(data),
            dataType: "json"
        }).then(function (d) {
            debugger;
            defer.resolve(d);
        }, function (e) {
            alert("Error!");
            defer.reject(e);
        });
        return defer.promise;
    }
    return factory;
});