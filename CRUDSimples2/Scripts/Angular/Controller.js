app.controller("ClientesController", function ($scope, myService) {
    
    GetAll();
    //To Get All Records 
    function GetAll() {
        var getData = myService.getAll();
        getData.then(function (result) {
            $scope.Clientes = result.data;
        }, function () {
            alert("Ocorreu um Erro ao retornar os Clientes.");
        });
    }
    $scope.AddNewCliente = function () {
        debugger;
        ClearFields();
        $scope.Action = "Add";
    }

    $scope.editCliente = function (cliente) {
        debugger;
        var getData = myService.getCliente(cliente.Id);
        getData.then(function (result) {
            $scope.Cliente = result.data;
            $scope.ClienteId = cliente.Id;
            $scope.ClienteNome = cliente.Nome;
            $scope.ClienteEmail = cliente.Email;
            $scope.ClienteData = cliente.DataNascimento;
            $scope.ClienteAtivo = cliente.Ativo;
            $scope.Action = "Update";
        },
        function () {
            alert('Error in getting records');
        });
    }

    $scope.AddUpdateCliente = function () {
        debugger;
        var Cliente = {
            Nome: $scope.ClienteNome,
            Email: $scope.ClienteEmail,
            DataNascimento: $scope.ClienteData,
            Ativo: $scope.ClienteAtivo
        };

        if ($scope.Action == "Update") {
            Cliente.Id = $scope.ClienteId;
            var getData = myService.updateCliente(Cliente);
            getData.then(function (msg) {
                GetAll();
                alert(msg.data);
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getData = myService.addCliente(Cliente);
            getData.then(function (msg) {
                alert(msg.data);
                window.location.href = "/Clientes";
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteCliente = function (cliente) {
        debugger;
        var getData = myService.deleteCliente(cliente.Id);
        getData.then(function (msg) {
            GetAll();
            alert('Cliente deletado');
        }, function () {
            alert('Erro ao deletar cliente.');
        });
    }

    function ClearFields() {
        $scope.ClienteId = "";
        $scope.ClienteNome = "";
        $scope.ClienteEmail = "";
        $scope.ClienteData = "";
        $scope.ClienteAtivo = false;
    }
});