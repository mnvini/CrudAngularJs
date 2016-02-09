app.controller("crudController", function ($scope, crudService) {
    $scope.divCelular = false;
    obterTodosCelulares();

    function obterTodosCelulares() {
        var celularesData = crudService.ObterTodosCelulares();
        celularesData.then(function (celular) {
            $scope.celulares = celular.data;
        }, function () {
            toastr["error"]("Erro ao obter os celulares", "Celulares Store")
        })
    }

    $scope.removerCelular = function (celular) {
        var celularData = crudService.RemoverCelular(celular.Id);
        celularData.then(function (data) {
            if (data.status == 200) {
                toastr["success"]("Celular excluido com sucesso!", "Celulares Store")
            }
            obterTodosCelulares();
        }, function () {
            toastr["error"]("Erro ao excluir", "Celulares Store")
        })
    }

    $scope.obterCelularPorId = function (celular) {
        var celularData = crudService.ObterCelularPorId(celular.Id);

        celularData.then(function (_celular) {
            $scope.celular = _celular.data;
            $scope.celularId = celular.Id;
            $scope.Marca = celular.Marca;
            $scope.Modelo = celular.Modelo;
            $scope.Cor = celular.Cor;
            $scope.TipoChip = celular.TipoChip;
            $scope.MemoriaInterna = celular.MemoriaInterna;
            $scope.Action = "AtualizarCelular";
            $scope.divCelular = true;
        }, function () {
            toastr["error"]("Erro ao tentar carregar o celular", "Celulares Store")
        });
    }

    $scope.AdicionarAtualizarCelular = function () {

        var celular = {
            Marca: $scope.Marca,
            Modelo: $scope.Modelo,
            Cor: $scope.Cor,
            TipoChip: $scope.TipoChip,
            MemoriaInterna: $scope.MemoriaInterna
        };
        var valorAcao = $scope.Action;

        if (valorAcao == "AtualizarCelular") {

            celular.Id = $scope.celularId;
            var celularData = crudService.AtualizarCelular(celular);
            celularData.then(function (data) {
                obterTodosCelulares();
                $scope.divCelular = false;
                if (data.status == 200) {
                    toastr["success"]("Celular alterado com sucesso!", "Celulares Store");
                }
            }, function () {
                toastr["error"]("Erro ao atualizar!", "Celulares Store");
            });
        } else {

            var celularData = crudService.AdicionarCelular(celular);
            celularData.then(function (data) {
                obterTodosCelulares();

                if (data.status == 200) {
                    toastr["success"]("Celular cadastrado com sucesso!", "Celulares Store");
                }
                $scope.divCelular = false;
            }, function () {
                toastr["error"]("Erro ao incluir!", "Celulares Store");
            });
        }
    }

    $scope.incluirCelularDiv = function () {
        limparCampos();
        $scope.Action = "AdicionarCelular";
        $scope.divCelular = true;
    }

    $scope.Cancelar = function () {
        $scope.divCelular = false;
    };

    function limparCampos() {
        $scope.celularId = "";
        $scope.Marca = "";
        $scope.Modelo = "";
        $scope.Cor = "";
        $scope.TipoChip = "";
        $scope.MemoriaInterna = "";
    }
});