app.service("myService", function ($http) {

    this.getAll = function () {
        return $http.get("/Clientes/GetAll");
    };

    this.getCliente = function (clienteId) {
        var response = $http({
            method: "post",
            url: "/Clientes/GetById",
            params: {
                id: JSON.stringify(clienteId)
            }
        });
        return response;
    }

    this.updateCliente = function (cliente) {
        var response = $http({
            method: "post",
            url: "/Clientes/Update",
            data: JSON.stringify(cliente),
            dataType: "json"
        });
        return response;
    }

    // Add Employee
    this.addCliente = function (cliente) {
        var response = $http({
            method: "post",
            url: "/Clientes/Create",
            data: JSON.stringify(cliente),
            dataType: "json"
        });
        return response;
    }

    //Delete Employee
    this.deleteCliente = function (clienteId) {
        var response = $http({
            method: "post",
            url: "/Clientes/Delete",
            params: {
                clienteId: JSON.stringify(clienteId)
            }
        });
        return response;
    }
});